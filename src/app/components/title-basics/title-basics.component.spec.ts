import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TitleBasicsComponent } from './title-basics.component';

describe('TitleBasicsComponent', () => {
  let component: TitleBasicsComponent;
  let fixture: ComponentFixture<TitleBasicsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TitleBasicsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TitleBasicsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
