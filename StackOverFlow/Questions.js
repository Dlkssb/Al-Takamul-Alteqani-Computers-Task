export class Item {
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
  
  export class Owner {
    constructor(owner) {
      this.reputation = owner.reputation;
      this.user_id = owner.user_id;
      this.user_type = owner.user_type;
      this.accept_rate = owner.accept_rate;
      this.profile_image = owner.profile_image;
      this.display_name = owner.display_name;
      this.link = owner.link;
    }
  }
  
 export class Root {
    constructor(data) {
      this.items = data.items.map(item => new Item(item));
      this.has_more = data.has_more;
      this.quota_max = data.quota_max;
      this.quota_remaining = data.quota_remaining;
    }
  }

  export { Item, Owner, Root };