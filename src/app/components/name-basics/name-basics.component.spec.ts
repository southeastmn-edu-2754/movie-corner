import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NameBasicsComponent } from './name-basics.component';

describe('NameBasicsComponent', () => {
  let component: NameBasicsComponent;
  let fixture: ComponentFixture<NameBasicsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NameBasicsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NameBasicsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
