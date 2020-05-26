import { Component, OnInit, Input } from '@angular/core';
import { MatOptionSelectionChange, MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatSnackBar} from '@angular/material';
import { FormControl, Validators} from '@angular/forms';
import { Title_Principals } from 'src/app/shared/title_principals.model';
import { title_principalsService } from 'src/app/shared/title_principals.service';
import { Title_Basics} from 'src/app/shared/title_basics.model';
import { titlebasicsService } from 'src/app/shared/titlebasics.service';
import { Observable, throwError } from 'rxjs';
import { startWith, distinctUntilChanged, debounceTime, switchMap, catchError} from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-title-principals',
  templateUrl: './title-principals.component.html',
  styleUrls: ['./title-principals.component.css'],
})
export class TitlePrincipalsComponent implements OnInit {
  @Input() Title_Principals :Title_Principals;
  
  public titlebasics: Title_Basics[] = new Array<Title_Basics>();

  constructor(private title_principalsService: title_principalsService,
    private titlebasicsService: titlebasicsService) { }

  ngOnInit(){

    this.titlebasicsService.getTitles(this.Title_Principals.tconst).pipe(catchError(this.handleError)).subscribe(data =>{
      this.titlebasics = data;
      console.log(this.titlebasics);
    })

  }

  handleError(err){
    if(err instanceof HttpErrorResponse){
      console.log("Serverside Error");
    } else {
      console.log("Client side Error");
    }
    return throwError(err);
  }

}
