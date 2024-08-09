import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TicketVm } from 'src/ViewModels/ticket-vm';
import { TicketService } from 'src/app/Services/ticket.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  constructor(private router:Router,private ticketService:TicketService){}
  ngOnInit(): void {
    this.getTickets();
    this.getTicketsSize();
  }
  page:number = 1;
  pageSize:number = 5;
  ticketsSize: number = 0;
  tickets:TicketVm[] = [];
  getTickets(){
    this.ticketService.getTickets(this.page,this.pageSize).subscribe({
      next:(data:any)=>{console.log(data);this.tickets = data},
      error:(err)=>{console.log(err);
      }
    })
  }
  handleTicket(id:number){
    this.ticketService.handleTicket(id).subscribe({
      next:(data:any)=>{console.log(data);},
      error:(err)=>{console.log(err);},
      complete:()=>{this.getTickets()}
    })
  }
  handlePageEvent(event:any){
    console.log(event);
    //{previousPageIndex: 1, pageIndex: 0, pageSize: 5, length: 7}
    this.page = event.pageIndex+1;
    this.getTickets()
  }
  getTicketsSize(){
    this.ticketService.getTicketsSize().subscribe({
      next:(data:any)=>{console.log(data);this.ticketsSize = data}
    })
  }
  getTicketColor(dateTime:Date):string{
    let ticketCreationTime = new Date(dateTime);
    let timeNow = new Date(Date.now());    
    const differenceInMilliseconds = timeNow.getTime() - ticketCreationTime.getTime();
    const differenceInMinutes = Math.floor(differenceInMilliseconds / (1000 * 60));
    
    if(differenceInMinutes<30)
      return "#ffc107"; // yeloow
    else if(differenceInMinutes>=30 && differenceInMinutes <45)
      return "#28a745"; // green
    else if (differenceInMinutes>=45 && differenceInMinutes <60)
      return "#007bff";// blue
    return "#dc3545";// red
  }
  routeToGenerateTicket(){
    this.router.navigate(["/generateTicket"])
  }
}
