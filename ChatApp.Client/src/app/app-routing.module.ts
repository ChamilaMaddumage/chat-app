import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { ChatRoomComponent } from "./components/chat-room/chat-room.component";
import { HomeComponent } from "./components/home/home.component";
import { RegisterUserComponent } from "./components/register-user/register-user.component";

const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "registerUser", component: RegisterUserComponent },
  { path: "chatRoom", component: ChatRoomComponent },
  { path: "**", redirectTo: "" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
