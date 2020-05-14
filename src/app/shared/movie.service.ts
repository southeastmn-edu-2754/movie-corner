import { Injectable } from '@angular/core';
import { Movie } from './movie.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

interface MovieServerData { movies: any[]; }

@Injectable()
export class MovieService {
  private titleBasicsApiUrl : string = 'https://localhost:5001/api/TitleBasics/';
  public movies: Movie[] = new Array<Movie>();

  constructor(private httpClient: HttpClient) { }

  getMovies(movieId: number): Observable<Movie[]> {
    return this.httpClient
    .get<MovieServerData>(this.titleBasicsApiUrl + movieId)
    .pipe(map(data => {
      this.movies = new Array<Movie>();
      for (var i in data.movies) {
        let s = data.movies[i];
        this.movies.push(new Movie(
          s["tconst"],
          s["primaryTitle"],
          s["originalTitle"],
          s["isAdult"],
          s["startYear"],
          s["endYear"],
          s["runtimeMinutes"],
          s["genres"]));
      }
      return this.movies;
    }));
  }
}
