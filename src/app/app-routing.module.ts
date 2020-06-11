import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { Ex2aCountryComponent } from './components/ex2a-country/ex2a-country.component';
import { MoviecornerComponent } from './components/moviecorner/moviecorner.component';

// 2754 JoshuaSeppa
import { SearchbarComponent } from './components/searchbar/searchbar.component';
import { TitleBasicsComponent } from './components/title-basics/title-basics.component';
import { TitlePrincipalsComponent } from './components/title-principals/title-principals.component';
import { NameBasicsComponent } from './components/name-basics/name-basics.component';

const routes: Routes =  [
    { path: '', redirectTo: 'home', pathMatch: 'full'},
    { path: 'home', component: HomeComponent },
    { path: 'ex2a1', component: Ex2aCountryComponent},
    { path: 'searchbar', component: SearchbarComponent},
    { path: 'moviecorner', component: MoviecornerComponent },
    { path: 'titlebasics', component: TitleBasicsComponent},
    { path: 'titleprincipals', component: TitlePrincipalsComponent},
    { path: 'namebasics', component: NameBasicsComponent},
    { path: '**', redirectTo: 'home' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }