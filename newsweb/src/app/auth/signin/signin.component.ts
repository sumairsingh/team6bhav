import { Component, OnInit } from '@angular/core';
import { FormGroup,FormControl,Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
  authForm=new FormGroup({
    username:new FormControl('',[Validators.required,
      Validators.minLength(3),
      Validators.maxLength(20),
      Validators.pattern(/^[a-zA-Z0-9]+$/)]),
    password:new FormControl('',[
      Validators.required,
      Validators.minLength(6),
      Validators.maxLength(20),
    ])
  })
    hide=true;
  constructor(private authService:AuthService,
              private router:Router
    ) { }

  ngOnInit(): void {
   
  }
  onSubmit(){
    if(this.authForm.controls.password.status==='VALID' && this.authForm.controls.username.status==='VALID')
      this.authService.signin(this.authForm.value).subscribe(
        {
          next:()=>{
            this.router.navigateByUrl('/');
          },
          error:({error})=>{
            if(error.username||error.password)
              this.authForm.setErrors({credentials:true as any})
          }
        }
      )
  }
}
