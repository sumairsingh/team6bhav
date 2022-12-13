import { Component, OnInit } from '@angular/core';
import { FormGroup,FormControl,Validators } from '@angular/forms';
import { MatchPassword } from '../validators/match-password';
import { UniqueUsername } from '../validators/unique-username';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  authForm:any =new FormGroup(
    {
      username:new FormControl("",[
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(20),
        Validators.pattern(/^[a-zA-Z0-9]+$/)
      ],[this.uniqueUsername.validate as any]),
      password:new FormControl("",
      [
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(20),
      ]),
      passwordConfirmation:new FormControl("",[
        Validators.required,
      ])
    },{validators:[this.matchPassword.validate as any]}
  )

  constructor(private matchPassword:MatchPassword,
              private uniqueUsername:UniqueUsername,
              private authService:AuthService,
              private router:Router) { }
  hide = true;
  ngOnInit(): void {
  }
  onSubmit(){
    console.log(this.authForm)
    if(this.authForm.controls.password.status==='VALID' && this.authForm.controls.passwordConfirmation.status==='VALID'&&this.authForm.controls.username.status==='VALID')
    {
      this.authService.signup(this.authForm.value).
      subscribe(
        {
          next:response=>{
            this.router.navigateByUrl('/')
          }
        }
      )
    }
    return;
  }
}
