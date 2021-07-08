import { Component } from '@angular/core';
import * as signalR from "@microsoft/signalr";
import { UserMessage } from './models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'SignalRClient';
  connection: signalR.HubConnection;
  userMessages: UserMessage[] = [];

  constructor() {
    this.createConnection();

  }

  createConnection() {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl("http://localhost:5000/messageHub")
      .build();

    this.connection.on("Connected", (message: string) => {
      console.log(message);
    });
    this.connection.on("ReceiveMessage", (message: UserMessage) => {
      console.log("received");
      this.userMessages.push(message);
    });
    this.connection.start().catch(err => document.write(err));
  }
  testRegister(e) {
    console.log("Registered successfully");
  }

  messageEntered(data: UserMessage) {
    this.connection.invoke("SendMessage", data);
    data.name = 'You';
    this.userMessages.push(data);
  }
}
