import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TicketService } from 'src/app/Services/ticket.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-generate-ticket',
  templateUrl: './generate-ticket.component.html',
  styleUrls: ['./generate-ticket.component.css']
})
export class GenerateTicketComponent implements OnInit {
  constructor(private formBuilder:FormBuilder,private ticketService:TicketService){}
  ngOnInit(): void {
    this.initForm();
  }
  form!:FormGroup;
  governorates:string[] = ["Alexandria", "Aswan","Cairo","Giza"];
  cities:string [] = ["6th of October","El Shorouk","Sharm El Sheikh"];
  districts:string[] = ["13","27","33"]; 
  initForm(){
    this.form = this.formBuilder.group({
      phoneNumber:['',Validators.required ],
      governorate:['',Validators.required],
      district:['',Validators.required],
      city:['',Validators.required],
    })
  }
  submitForm(){
    this.ticketService.createTicket(this.form.value).subscribe({
      next:(data:any)=>{},
      error:(err)=>{console.log(err),
        Swal.fire({
          icon:"error",
          title:"Something went wrong",
          text: err.error.errors.PhoneNumber || err.error 
        })
      },
      complete:()=>{
        Swal.fire({
        icon:"success",
        title:"Ticket Created Successfully",
        showConfirmButton:false,
        timer:2000
      })}
    })
  }
}
