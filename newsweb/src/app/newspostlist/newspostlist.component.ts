import { Component, OnInit,Input } from '@angular/core';

@Component({
  selector: 'app-newspostlist',
  templateUrl: './newspostlist.component.html',
  styleUrls: ['./newspostlist.component.css']
})
export class NewspostlistComponent implements OnInit {
  @Input() pages=[];
  constructor() { }

  ngOnInit(): void {
  }

}
