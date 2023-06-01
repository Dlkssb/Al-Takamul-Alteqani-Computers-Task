

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
      this.body = item.body; // Add the body property
      this.accepted_answer_id = item.accepted_answer_id;
      this.last_edit_date = item.last_edit_date;
      this.protected_date = item.protected_date;
      this.closed_date = item.closed_date;
      this.closed_reason = item.closed_reason;
    }
  }

  function fetchQuestionDetails() {
    const urlParams = new URLSearchParams(window.location.search);
    const questionId = urlParams.get('questionId');
  
    fetch(`https://api.stackexchange.com/2.2/questions/${questionId}?order=desc&sort=activity&site=stackoverflow`)
      .then(response => response.json())
      .then(data => {
        console.log(data);
        const questionDetails = document.getElementById('question-details');
        const question = new Item(data.items[0]);
  
        const isAnswered = question.is_answered ? 'Yes' : 'No'; // Determine if the question is answered or not
  
        questionDetails.innerHTML = `
          <div class="card text-center">
            <div class="card-header">
              <h3 class="text-danger mb-3">${question.title}</h1>
            </div>
            <div class="card-body">
              <h3 class="text-center">Author: ${question.owner.display_name}</h3>
              <h3 class="text-center">Score: ${question.score}</h3>
              <h3 class="text-center">Tags: ${question.tags.join(', ')}</h3>
              <a href="${question.link}" class="btn btn-primary">Go To The Question </a>
            </div>
            <div class="card-footer text-muted">
              <h3 class="text-center"><code>Answered: ${isAnswered}</code></h3>
            </div>
          </div>  
        `;
      })
      .catch(error => console.log(error));
  }
  
  window.onload = fetchQuestionDetails;