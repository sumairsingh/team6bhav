import { Component, OnInit,Input } from '@angular/core';

@Component({
  selector: 'app-newspost',
  templateUrl: './newspost.component.html',
  styleUrls: ['./newspost.component.css']
})
export class NewspostComponent implements OnInit {
 @Input() post:any;
  constructor() { }

  ngOnInit(): void {
  }

}
