export class Message {
  messageId: number;
  messageContent: string;
  messageBy: string;
  messageDateAndTime: Date;
  chatRoomId: number;
  userId: number;
}

export class MessagesByChatRoomIdResponseModel{
    messagesDTOs: Message[];
}

export class MessagesRequestModel{
  messageContent: string;
  messageBy: number;
  messageDateAndTime: Date;
  chatRoomId: number;
}
