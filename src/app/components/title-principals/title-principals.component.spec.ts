import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TitlePrincipalsComponent } from './title-principals.component';

describe('TitlePrincipalsComponent', () => {
  let component: TitlePrincipalsComponent;
  let fixture: ComponentFixture<TitlePrincipalsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TitlePrincipalsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TitlePrincipalsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
