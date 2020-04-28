import { Injectable } from '@angular/core';
import { Title_Basics} from './title_basics.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class titlebasicsService {

    public title_basics : Title_Basics = null;
    private titlebasicsApiUrl: string = 'https://localhost:5001/api/titlebasics/';
  
    constructor(private httpClient: HttpClient) { }
  
    getTitle(id: number) : Observable<Title_Basics> {
      return this.httpClient.get(this.titlebasicsApiUrl + id.toString())
      .pipe(map(data => {
        var title_basics: Title_Basics = new Title_Basics(
            data["tconst"], 
            data["titleType"], 
            data["primaryTitle"], 
            data["originalTitle"], 
            data["isAudit"],
            data["startYear"],
            data["endYear"],
            data["runtimeMinutes"],
            data["genres"]);

            console.log(title_basics);
            return title_basics;
    }));
  
  }
  
  getTitles(): Observable<Title_Basics[]> {
    return this.httpClient.get<Title_Basics[]>('https://localhost:5001/api/titlebasics/')
    .pipe(map(data =>{
      let title_basics : Title_Basics[] = new Array<Title_Basics>();
      let c = data[0];
      title_basics.push( new Title_Basics(
        c["tconst"], 
        c["titleType"], 
        c["primaryTitle"], 
        c["originalTitle"], 
        c["isAudit"],
        c["startYear"],
        c["endYear"],
        c["runtimeMinutes"],
        c["genres"]));
  
        return title_basics;
    
  }));
  }
  
}