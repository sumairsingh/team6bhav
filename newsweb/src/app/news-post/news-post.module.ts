import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material/material.module';
import { NewsPostRoutingModule } from './news-post-routing.module';
import { HomeComponentComponent } from './home-component/home-component.component';


@NgModule({
  declarations: [
    HomeComponentComponent
  ],
  imports: [
    CommonModule,
    NewsPostRoutingModule,
    MaterialModule
  ]
})
export class NewsPostModule { }
