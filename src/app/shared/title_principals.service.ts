import { Injectable } from '@angular/core';
import { Title_Principals } from './title_principals.models';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

interface titleprincipalsData { titlePrincipals: any[]; }

@Injectable({
  providedIn: 'root'
})
export class title_principalsService {

    public title_principals : Title_Principals[] = new Array <Title_Principals>();
    private titlePrincipalsApiUrl: string = 'https://localhost:5001/api/titleprincipals/';

    constructor(private httpClient: HttpClient) { }
  
  getTitles(tconst: string): Observable<Title_Principals[]> {
    return this.httpClient.get<titleprincipalsData>(this.titlePrincipalsApiUrl + tconst)
    .pipe(map(data =>{
      this.title_principals = new Array<Title_Principals>();
      for (var i in data.titlePrincipals){
        let c = data.titlePrincipals[i];
        this.title_principals.push( new Title_Principals(
        c["tconst"], 
        c["ordering"], 
        c["nconst"],
        c["category"], 
        c["job"], 
        c["characters"]));
        }
        return this.title_principals;
    
  }));

  }
}