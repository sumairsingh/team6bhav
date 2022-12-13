import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {BehaviorSubject} from 'rxjs'
import {tap} from 'rxjs/operators';
interface SignUpCredentials{
  username:string;
  password:string;
  passwordConfirmation:string;
}
interface SignUpResponse{
  username:string;
}
interface SignedInResponse{
  authenticated:boolean;
  username:string;
}
interface SigninCredentials{
  username:string,
  password:string
}
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  rootUrl='https://api.angular-email.com';
  signedin=new BehaviorSubject(false);

  constructor(private http:HttpClient) { }
  usernameAvailable(username:string){
   return this.http.post<{available:boolean}>(`${this.rootUrl}/auth/username`,{
            username:username
        });
  }
  signup(credentials:SignUpCredentials){
          return this.http.post<SignUpResponse>(`${this.rootUrl}/auth/signup`,credentials,{withCredentials:true}).pipe(
            tap(()=>{
              this.signedin.next(true);
            })
          )
  }
 checkAuth(){
  return this.http.get<SignedInResponse>(`${this.rootUrl}/auth/signedin`,{withCredentials:true})
   .pipe(
     tap(({authenticated})=>{
       this.signedin.next(authenticated);
     })
   )
 }
 signout(){
   return this.http.post(`${this.rootUrl}/auth/signout`,{},{withCredentials:true})
   .pipe(
     tap(()=>{
      this.signedin.next(false);
     })
   )
 }
 signin(credentials:SigninCredentials){
   return this.http.post(`${this.rootUrl}/auth/signin`,credentials,{withCredentials:true})
   .pipe(
     tap(()=>{
       this.signedin.next(true);
     })
   )
 }
}

