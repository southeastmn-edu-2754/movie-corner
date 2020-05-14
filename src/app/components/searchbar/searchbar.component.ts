import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatOptionSelectionChange, MatDialog, MatDialogRef } from '@angular/material';
import { Movie } from 'src/app/shared/movie.model';
import { Observable } from 'rxjs';
import { MovieService } from 'src/app/shared/movie.service';
import { TvShowService } from 'src/app/shared/tv-show.service';
import { startWith, debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';

interface Filter { value: string; viewValue: string; }

@Component({ selector: 'app-searchbar', templateUrl: './searchbar.component.html', styleUrls: ['./searchbar.component.css'] })
export class SearchbarComponent implements OnInit {
  public searchFilterInput: FormControl = new FormControl();
  public searchBarInput: FormControl = new FormControl();
  public filteredMovies: Observable<Movie[]> = null;

  searchFilter: Filter[] = [
    {value: 'all', viewValue: 'All'},
    {value: 'movie', viewValue: 'Movie Titles'},
    {value: 'television', viewValue: 'TV Episodes'},
    {value: 'celeb', viewValue: 'Celebrities'},
    {value: 'date', viewValue: 'Date'},
  ];

  constructor(
    private movieService: MovieService,
    private tvShowService: TvShowService
  ) { }

  ngOnInit() {
    this.filteredMovies = this.searchFilterInput.valueChanges.pipe(
      startWith(this.searchFilterInput.value),
      debounceTime(250),
      distinctUntilChanged(),
      switchMap(val => this.movieService.getMovies(val || 'A'))
    );
  }

  displaySearchFn(movie: Movie): string {
    return movie ? movie.primaryTitle + ' (' + movie.startYear + ')' : '';
  }

  searchButtonClick(): void {

  }

}
