import { Injectable } from '@angular/core';
import { Title_Principal } from './title_principal.model';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Title_Basics } from './title_basics.model';

interface titleprincipalsData { titlePrincipals: any[]; }

@Injectable({
  providedIn: 'root'
})
export class Title_PrincipalsService {

    private titlePrincipalsApiUrl: string = 'https://localhost:5001/api/titleprincipals/';
    public title_principals : Title_Principal[] = new Array <Title_Principal>();

    constructor(private httpClient: HttpClient) { }
  
  getTitles(nconst): Observable<Title_Principal[]> {
    return this.httpClient.get<titleprincipalsData>(this.titlePrincipalsApiUrl + nconst)
    .pipe(map(data =>{
      this.title_principals = new Array<Title_Principal>();
      for (var i in data.titlePrincipals){
        let c = data.titlePrincipals[i];
        console.log(c);
        this.title_principals.push( new Title_Principal(
        c["tconst"].replace(" ", ""), 
        c["ordering"], 
        c["nconst"].replace(" ", ""),
        c["category"], 
        c["job"], 
        c["characters"],
        ));
        }
        return this.title_principals;
  }));
  }
}