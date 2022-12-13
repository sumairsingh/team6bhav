import { Component } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AuthService } from './auth/auth.service';
import { NewsService } from './news.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title="wev";
  pages=[];
  signedin:BehaviorSubject<boolean>;
  constructor(
    private news:NewsService,
    private authService:AuthService){
      this.signedin=this.authService.signedin
    }
   onTerm(term:any){
    this.news.search(term).subscribe((response:any)=>{
     this.pages=response.articles;
     console.log(response);
    });
   }
   ngOnInit(){
     this.authService.checkAuth().subscribe(()=>{});
   }
}
