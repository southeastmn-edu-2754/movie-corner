import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MoviecornerComponent } from './moviecorner.component';

describe('MoviecornerComponent', () => {
  let component: MoviecornerComponent;
  let fixture: ComponentFixture<MoviecornerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MoviecornerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MoviecornerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
