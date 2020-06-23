import { Injectable } from '@angular/core';
import { Name_Basics } from './namebasics.model';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

interface namebasicsData { nameBasics: any[]; }

@Injectable({
  providedIn: 'root'
})
export class NameBasicsService {

    public name_basics : Name_Basics[] = new Array <Name_Basics>();
    private nameBasicsApiUrl: string = 'https://localhost:5001/api/namebasics/';

    constructor(private httpClient: HttpClient) { }
  
  getNames(primaryName: string): Observable<Name_Basics[]> {
    return this.httpClient.get<namebasicsData>(this.nameBasicsApiUrl + primaryName)
    .pipe(map(data =>{
      this.name_basics = new Array<Name_Basics>();
      for (var i in data.nameBasics){
        let c = data.nameBasics[i];
        this.name_basics.push( new Name_Basics(
        c["nconst"], 
        c["primaryName"], 
        c["birthYear"],
        c["deathYear"], 
        c["primaryProfession"], 
        c["knownForTitles"]));
        }
        return this.name_basics;
    
  }));

  }
}