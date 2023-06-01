using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Pages.ModelPages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<BookModel> Books { get; set; }
        public List<BookModel> FilteredBooks { get; set; }
        public List<SelectListItem> MainCategoryOptions { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> SubcategoryOptions { get; set; } = new List<SelectListItem>();

        [BindProperty]
        public string SelectedMainCategory { get; set; }

        [BindProperty]
        public string SelectedSubcategory { get; set; }

        public async Task OnGetAsync()
        {
            
            var apiUrl = "http://localhost:5000/api/Books";
            var response = await _httpClient.GetAsync(apiUrl);
            var json = await response.Content.ReadAsStringAsync();
            Books = JsonConvert.DeserializeObject<List<BookModel>>(json);

            // Populate the dropdown lists with unique main categories and subcategories
            MainCategoryOptions = Books.Select(b => b.Category).Distinct()
                .Select(c => new SelectListItem { Value = c, Text = c }).ToList();

            SubcategoryOptions = Books.Select(b => b.Subcategory).Distinct()
                .Select(s => new SelectListItem { Value = s, Text = s }).ToList();

            MainCategoryOptions.Insert(0,new SelectListItem { Selected = true, Value = "", Text = "  " });
           
            SubcategoryOptions.Insert(0,new SelectListItem { Selected = true, Value = "", Text = "  " });

            FilterBooks();
        }

        public void OnPost()
        {
            FilterBooks();
        }

        private void FilterBooks()
        {
            FilteredBooks = Books;

            if (!string.IsNullOrEmpty(SelectedMainCategory))
                FilteredBooks = FilteredBooks.Where(b => b.Category == SelectedMainCategory).ToList();

            if (!string.IsNullOrEmpty(SelectedSubcategory))
                FilteredBooks = FilteredBooks.Where(b => b.Subcategory == SelectedSubcategory).ToList();
        }
    }
}
