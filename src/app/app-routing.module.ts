import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { Ex2aCountryComponent } from './components/ex2a-country/ex2a-country.component';
import { TitleBasicsComponent } from './components/title-basics/title-basics.component';
import { TitlePrincipalsComponent } from './components/title-principals/title-principals.component';

const routes: Routes =  [
    { path: '', redirectTo: 'home', pathMatch: 'full'},
    { path: 'home', component: HomeComponent },
    { path: 'ex2a1', component: Ex2aCountryComponent},
    { path: 'titleprincipals', component: TitlePrincipalsComponent},
    { path: '**', redirectTo: 'home' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }