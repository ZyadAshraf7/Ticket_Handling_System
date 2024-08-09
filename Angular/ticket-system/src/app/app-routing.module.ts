import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Pages/home/home.component';
import { GenerateTicketComponent } from './Pages/generate-ticket/generate-ticket.component';

const routes: Routes = [
  {path:"",component:HomeComponent,pathMatch:"full"},
  {path:"Home",component:HomeComponent},
  {path:"generateTicket",component:GenerateTicketComponent},
  {path:"**",component:HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
