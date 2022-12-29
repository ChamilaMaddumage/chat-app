import { Component, OnInit } from "@angular/core";
import { Message, MessagesRequestModel } from "src/app/models/message";
import { ChatRoomsService } from "src/app/services/chat-rooms.service";
import { MessagesService } from "src/app/services/messages.service";
import { SpinnerService } from "src/app/services/spinner.service";

@Component({
  selector: "app-chat-room",
  templateUrl: "./chat-room.component.html",
  styleUrls: ["./chat-room.component.css"],
})
export class ChatRoomComponent implements OnInit {
  public messages: Message[];
  public loggedInUserId: number;
  public loggedInDisplayName: string;
  public messageContent: string;

  constructor(
    private messagesService: MessagesService,
    public spinnerService: SpinnerService,
    private chatRoomService: ChatRoomsService
  ) {}

  ngOnInit() {
    this.loggedInUserId = Number(sessionStorage.getItem("userId"));
    this.loggedInDisplayName = sessionStorage.getItem("displayName");
    this.getMessage();
    this.getMessagesByChatRoomId(1);
  }

  getMessagesByChatRoomId(chatRoomId: number) {
    this.spinnerService.IsVisible(true);
    this.messagesService.getMessagesByChatRoomId(chatRoomId).subscribe(
      (data) => {
        if (data.messagesDTOs) {
          this.messages = data.messagesDTOs;
        }
        this.spinnerService.IsVisible(false);
      },
      (error) => {
        this.spinnerService.IsVisible(false);
        //this.toast.show('Error occured while retrieving record', ToastType.Error)
      }
    );
  }

  onSendMessage() {
    if (this.messageContent) {
      let messagesRequestModel = new MessagesRequestModel();
      messagesRequestModel.messageContent = this.messageContent;
      messagesRequestModel.messageBy = this.loggedInUserId;
      messagesRequestModel.messageDateAndTime = new Date();
      messagesRequestModel.chatRoomId = 1; // This will be dynamic with upcoming releases

      this.chatRoomService.sendMessage(messagesRequestModel);
      this.messageContent = "";
    }
  }

  private getMessage(): void {
    this.chatRoomService.messageReceived.subscribe(() => {
      this.getMessagesByChatRoomId(1);
    });
  }
}
