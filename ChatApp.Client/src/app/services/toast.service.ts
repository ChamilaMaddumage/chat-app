import { Injectable } from '@angular/core';
import { ToastType } from '../enums/toast-enum';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  // constructor(private toastr: ToastrService) { }

  // toastrConfig = {
  //     toastClass: 'ngx-toastr',
  //     toastComponent: Toast,
  //     easing: 'ease-in',
  //     titleClass: 'toast-title',
  //     messageClass: 'toast-message',
  //     tapToDismiss: true,
  //     timeOut: 3000,
  //     positionClass: 'toast-top-center',
  //     closeButton: true
  // }

  // toastType: string;
  // messageTitle: string = 'Notification';

  // public show(message: string, toastType: ToastType, title: string = null, timeOut?: number) {
  //     if (timeOut) {
  //         this.toastrConfig.timeOut = timeOut
  //     }

  //     switch (toastType) {
  //         case ToastType.Error:
  //             this.toastType = 'toast-error'
  //             break;
  //         case ToastType.Info:
  //             this.toastType = 'toast-info'
  //             break;
  //         case ToastType.Success:
  //             this.toastType = 'toast-success'
  //             break;
  //         case ToastType.Warning:
  //             this.toastType = 'toast-warning'
  //             break;
  //     }

  //     this.messageTitle = (typeof (title) != 'undefined' && title) ? title : this.messageTitle;
  //     this.toastr.show(message, this.messageTitle, this.toastrConfig, this.toastType);
  //}
}
