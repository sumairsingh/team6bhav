import { Component, OnInit } from '@angular/core';
import { NewsService } from 'src/app/news.service';
@Component({
  selector: 'app-home-component',
  templateUrl: './home-component.component.html',
  styleUrls: ['./home-component.component.css']
})
export class HomeComponentComponent implements OnInit {
  news:any=[]
  constructor(private newsService:NewsService) { }

  ngOnInit(): void {
    this.newsService.defaultnews().subscribe((response : any)=>{
     this.news=response.articles;
     console.log(this.news);
    })
  }

}
