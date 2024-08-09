import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TicketVm } from 'src/ViewModels/ticket-vm';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  constructor(private http:HttpClient) { }
  private baseLink = "https://localhost:7026/api/Tickets/"
  
  getTickets(page:number,pageSize:number):Observable<TicketVm[]> {
    return this.http.get<TicketVm[]>(this.baseLink+"GetTickets",{
      params:{
        "page":page,
        "pageSize":pageSize
      }
    })
  }
  getTicketsSize():Observable<number> {
    return this.http.get<number>(this.baseLink+"GetTicketsSize")
  }
  handleTicket(id:number):Observable<void>{
    return this.http.post<void>(this.baseLink+`${id}`+"/handle",{})
  }
  createTicket(ticket:TicketVm){
    return this.http.post(this.baseLink+"CreateTicket",ticket)
  }
}
