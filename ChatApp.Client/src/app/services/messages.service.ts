import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MessagesByChatRoomIdResponseModel } from '../models/message';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class MessagesService extends BaseService {
  public getMessagesByChatRoomId(chatRoomId: number): Observable<MessagesByChatRoomIdResponseModel> {
    return this.http.get<MessagesByChatRoomIdResponseModel>(
      `${this.baseURL}api/messages/get-messages-by-chat-room-id/${chatRoomId}`
    );
  }
}
