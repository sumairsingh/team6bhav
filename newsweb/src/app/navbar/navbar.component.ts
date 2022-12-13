import { Component, OnInit,EventEmitter,Output,Input   } from '@angular/core';
import { FormControl,FormGroup,Validators } from '@angular/forms';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  @Input() signedin:any;
  @Output() submitted=new EventEmitter<string>();
  term=""
 menus={
    username:"abkech",
    userUrl:"https://material.angular.io/assets/img/examples/shiba2.jpg",
  }

  constructor() { }

  ngOnInit(): void {
  }
  onInput(event:Event)
  {
    this.term=(event.target as HTMLInputElement).value;
  }
  onFormSubmit(event:any)
  {
    event.preventDefault();
    this.submitted.emit(this.term);
  }
  signOut(){
    console.log("signout")
  }

}
