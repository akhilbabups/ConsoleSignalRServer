import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {
  userName: string;
  message: string;
  show = false;
  @Output() resgister = new EventEmitter();
  @Output() messageEntered = new EventEmitter<{ name: string, message: string }>();
  constructor() { }

  ngOnInit(): void {

  }

  registerUser($event) {
    this.resgister.emit(this.userName);
    this.show = true;
  }
  submitMessage($event) {
    this.messageEntered.emit({ name: this.userName, message: this.message });
    this.message = '';
  }
}
