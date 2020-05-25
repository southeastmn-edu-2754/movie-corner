import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
//import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatToolbarModule, MatButtonModule, MatIconModule, MatMenuModule,
          MatCardModule, MatFormFieldModule, MatInputModule,
          MatDialogModule, MatGridListModule, MatAutocompleteModule
      } from '@angular/material';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { Mswan3cPeopleService } from './shared/mswan3c-people-service.service';

// Ex3D
import {HttpClientModule} from '@angular/common/http';
import { Ex2aCountryComponent } from './components/ex2a-country/ex2a-country.component';
import { TitleBasicsComponent } from './components/title-basics/title-basics.component';
import { TitlePrincipalsComponent } from './components/title-principals/title-principals.component';
import { NameBasicsComponent } from './components/name-basics/name-basics.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavBarComponent,
    Ex2aCountryComponent,
    TitleBasicsComponent,
    TitlePrincipalsComponent,
    NameBasicsComponent,
    
  ],
  imports: [
    BrowserModule,
    FormsModule, ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule, MatIconModule, MatButtonModule, MatCardModule, 
    MatFormFieldModule, MatInputModule, MatMenuModule,
    MatDialogModule, MatGridListModule, MatAutocompleteModule,
    HttpClientModule,
  ],
  entryComponents: [
    HomeComponent
  ],
  providers: [Mswan3cPeopleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
