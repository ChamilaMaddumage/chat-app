import { HttpClient } from "@angular/common/http";
import { EventEmitter, Injectable } from "@angular/core";
import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import { Message, MessagesRequestModel } from "../models/message";
import { BaseService } from "./base.service";

@Injectable({
  providedIn: "root",
})
export class ChatRoomsService extends BaseService {
  private hubConnection: HubConnection;
  messageReceived = new EventEmitter<Message>();

  constructor(public httpClient: HttpClient) {
    super(httpClient);
    this.init();
  }

  public sendMessage(messagesRequestModel: MessagesRequestModel): void {
    this.hubConnection.onclose(() => {
      this.init();
    });
    this.hubConnection.invoke("CreateMessageAsync", messagesRequestModel);
  }

  private init(): void {
    this.createConnection();
    this.startConnection();
  }

  private createConnection(): void {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(`${this.baseURL}hubs`)
      .build();
  }

  private startConnection(): void {
    this.hubConnection
      .start()
      .then(() => {
        this.registerOnServerEvents();
      })
      .catch((error) => {
        setTimeout(function () {
          this.startConnection();
        }, 5000);
      });
  }

  private registerOnServerEvents(): void {
    this.hubConnection.on("MessageBroadcaster", () => {
      this.messageReceived.emit();
    });
  }
}
