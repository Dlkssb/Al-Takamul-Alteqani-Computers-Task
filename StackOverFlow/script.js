
class Item {
    constructor(item) {
      this.tags = item.tags;
      this.owner = item.owner;
      this.is_answered = item.is_answered;
      this.view_count = item.view_count;
      this.answer_count = item.answer_count;
      this.score = item.score;
      this.last_activity_date = item.last_activity_date;
      this.creation_date = item.creation_date;
      this.question_id = item.question_id;
      this.content_license = item.content_license;
      this.link = item.link;
      this.title = item.title;
      this.accepted_answer_id = item.accepted_answer_id;
      this.last_edit_date = item.last_edit_date;
      this.protected_date = item.protected_date;
      this.closed_date = item.closed_date;
      this.closed_reason = item.closed_reason;
    }
  }
  class Root {
    constructor(data) {
      this.items = data.items.map(item => new Item(item));
      this.has_more = data.has_more;
      this.quota_max = data.quota_max;
      this.quota_remaining = data.quota_remaining;
    }
  }



  function fetchQuestions() {
    fetch('https://api.stackexchange.com/2.3/questions?pagesize=100&order=desc&sort=activity&site=stackoverflow')
      .then(response => response.json())
      .then(data => {
        const root = new Root(data);
        const questions = root.items.slice(0, 101); // Get the first 100 questions
        const questionsList = document.getElementById('questions-list');
const table = document.createElement('table');
table.classList.add('table', 'table-hover', 'table-bordered');

// Create the table headers
const thead = document.createElement('thead');
thead.classList.add('thead-dark');
const headerRow = document.createElement('tr');
const headers = ['Title', 'Author', 'Score', 'Tags'];

headers.forEach(headerText => {
  const th = document.createElement('th');
  th.classList.add('text-center');
  th.textContent = headerText;
  headerRow.appendChild(th);
});

thead.appendChild(headerRow);
table.appendChild(thead);

// Create the table body
const tbody = document.createElement('tbody');

if (questions && questions.length > 0) {
  questions.forEach(question => {
    const row = document.createElement('tr');
    const title = document.createElement('td');
    const author = document.createElement('td');
    const score = document.createElement('td');
    const tags = document.createElement('td');

    const questionLink = document.createElement('a');
    questionLink.href = `question.html?questionId=${question.question_id}`;
    questionLink.classList.add('question-link');
    questionLink.dataset.id = question.question_id;
    questionLink.textContent = question.title;

    title.appendChild(questionLink);
    author.textContent = question.owner.display_name;
    score.textContent = question.score;
    tags.textContent = question.tags.join(', ');

    row.appendChild(title);
    row.appendChild(author);
    row.appendChild(score);
    row.appendChild(tags);
    tbody.appendChild(row);
  });
} else {
  const emptyRow = document.createElement('tr');
  const emptyData = document.createElement('td');
  emptyData.setAttribute('colspan', headers.length);
  emptyData.classList.add('text-center', 'font-italic');
  emptyData.textContent = 'No questions found.';
  emptyRow.appendChild(emptyData);
  tbody.appendChild(emptyRow);
}

table.appendChild(tbody);
questionsList.appendChild(table)})
      .catch(error => console.log(error));
  }
  
 
  
  window.onload = fetchQuestions;
