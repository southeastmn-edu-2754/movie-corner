import { Injectable } from '@angular/core';
import { TvShow } from './tv-show.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

interface TvShowServerData { tvShows: any[]; }

@Injectable()
export class TvShowService {
  private titleEpisodeApiUrl : string = 'https://localhost:5001/api/TitleEpisode/';
  public tvShows: TvShow[] = new Array<TvShow>();

  constructor(private httpClient: HttpClient) { }

  getTvShows(showId: number): Observable<TvShow[]> {
    return this.httpClient
    .get<TvShowServerData>(this.titleEpisodeApiUrl + showId)
    .pipe(map(data => {
      this.tvShows = new Array<TvShow>();
      for (var i in data.tvShows) {
        let s = data.tvShows[i];
        this.tvShows.push(new TvShow(
          s["tconst"],
          s["parentTconst"],
          s["seasonNumber"],
          s["episodeNumber"]));
      }
      return this.tvShows;
    }));
  }
}
