import { Component, OnInit, Input } from '@angular/core';
import { MatOptionSelectionChange, MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatSnackBar} from '@angular/material';
import { FormControl, Validators} from '@angular/forms';
import { Title_Principal } from 'src/app/shared/title_principal.model';
import { Title_PrincipalsService } from 'src/app/shared/title_principals.service';
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
  // @Input() Title_Principals :Title_Principals;
  @Input() title_Principal: Title_Principal;
  
  public titlebasics: Title_Basics[] = new Array<Title_Basics>();

  constructor(private title_principalsService: Title_PrincipalsService,
    private titlebasicsService: titlebasicsService) { }

  ngOnInit(){
    console.log(this.title_Principal);
    this.titlebasicsService.getTitles(this.title_Principal.tconst).pipe(catchError(this.handleError)).subscribe(data =>{
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
