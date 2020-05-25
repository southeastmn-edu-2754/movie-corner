import { Injectable } from '@angular/core';
import { Title_Principals } from './title_principals.model';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Title_Basics } from './title_basics.model';

interface titleprincipalsData { titlePrincipals: any[]; }

@Injectable({
  providedIn: 'root'
})
export class title_principalsService {

    private titlePrincipalsApiUrl: string = 'https://localhost:5001/api/titleprincipals/';
    public title_principals : Title_Principals[] = new Array <Title_Principals>();

    constructor(private httpClient: HttpClient) { }
  
  getTitles(nconst): Observable<Title_Principals[]> {
    return this.httpClient.get<titleprincipalsData>(this.titlePrincipalsApiUrl + nconst)
    .pipe(map(data =>{
      this.title_principals = new Array<Title_Principals>();
      for (var i in data.titlePrincipals){
        let c = data.titlePrincipals[i];
        console.log(c);
        this.title_principals.push( new Title_Principals(
        c["tconst"], 
        c["ordering"], 
        c["nconst"],
        c["category"], 
        c["job"], 
        c["characters"],
        // null, null
        // c["tconstNavigation"]
        // new Title_Basics(
        //   t["tconst"], 
        //   t["titleType"], 
        //   t["primaryTitle"], 
        //   t["originalTitle"], 
        //   t["isAudit"],
        //   t["startYear"],
        //   t["endYear"],
        //   t["runtimeMinutes"],
        //   t["genres"])
        ));
        }
        return this.title_principals;
  }));
  }
}