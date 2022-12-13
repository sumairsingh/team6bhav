import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewspostlistComponent } from './newspostlist.component';

describe('NewspostlistComponent', () => {
  let component: NewspostlistComponent;
  let fixture: ComponentFixture<NewspostlistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewspostlistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewspostlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
