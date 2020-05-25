import { Injectable } from '@angular/core';
import { Title_Basics} from './title_basics.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

interface titlebasicsData { titleBasics: any[]; 
}

@Injectable({
  providedIn: 'root'
})
export class titlebasicsService {

    private titlebasicsApiUrl: string = 'https://localhost:5001/api/titlebasics/';
    public title_basics : Title_Basics[] = new Array <Title_Basics>();

    constructor(private httpClient: HttpClient) { }

    getTitles(tconst): Observable<Title_Basics[]> {
      return this.httpClient.get<titlebasicsData>(this.titlebasicsApiUrl + tconst)
      .pipe(map(data =>{
        this.title_basics = new Array<Title_Basics>();
        for (var i in data.titleBasics){
          let c = data.titleBasics[i];
          //console.log(c);
          this.title_basics.push( new Title_Basics(
            c["tconst"], 
            c["titleType"], 
            c["primaryTitle"], 
            c["originalTitle"], 
            c["isAudit"],
            c["startYear"],
            c["endYear"],
            c["runtimeMinutes"],
            c["genres"]));
          }
          return this.title_basics;
      
    }));
  }
}

//   getTitles(): Observable<Title_Basics[]> {
//     return this.httpClient.get<Title_Basics[]>('https://localhost:5001/api/titlebasics/')
//     .pipe(map(data =>{
//       let title_basics : Title_Basics[] = new Array<Title_Basics>();
//       let c = data[0];
//       title_basics.push( new Title_Basics(
//         c["tconst"], 
//         c["titleType"], 
//         c["primaryTitle"], 
//         c["originalTitle"], 
//         c["isAudit"],
//         c["startYear"],
//         c["endYear"],
//         c["runtimeMinutes"],
//         c["genres"]));
  
//         return title_basics;
    
//   }));
//   }
  
// }