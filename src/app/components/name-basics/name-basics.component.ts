import { Component, OnInit } from '@angular/core';
import { MatOptionSelectionChange, MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatSnackBar} from '@angular/material';
import { FormControl, Validators} from '@angular/forms';
import { Observable, throwError } from 'rxjs';
import { Name_Basics } from 'src/app/shared/namebasics.model';
import { Title_Basics } from 'src/app/shared/title_basics.model';
import { titlebasicsService } from 'src/app/shared/titlebasics.service';
import { NameBasicsService } from 'src/app/shared/namebasics.service';
import { Title_Principal } from 'src/app/shared/title_principal.model';
import { Title_PrincipalsService } from 'src/app/shared/title_principals.service';
import { startWith, distinctUntilChanged, debounceTime, switchMap, catchError} from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-name-basics',
  templateUrl: './name-basics.component.html',
  styleUrls: ['./name-basics.component.css']
})

export class NameBasicsComponent implements OnInit {


  public filtered: FormControl = new FormControl();
  public NconstNameInput = new FormControl({value: '', disabled: true});
  public PrimaryNameInput = new FormControl('', [Validators.required]);
  public BirthYearInput = new FormControl('', [Validators.required]);
  public DeathYearInput = new FormControl('', [Validators.required]);
  public PrimaryProfessionInput = new FormControl('', [Validators.required]);
  public KnownForTitlesInput = new FormControl('', [Validators.required]);

  public selectedName: Name_Basics = new Name_Basics("","",0,0,"","");
  public filteredName: Observable<Name_Basics[]> = null;
  public titleprincipals: Title_Principal[] = new Array<Title_Principal>();

  constructor(private namebasicsService: NameBasicsService, 
    private titleprincipalsService: Title_PrincipalsService,
    private titlebasicsService: titlebasicsService) { }

  ngOnInit(){

    this.filteredName = this.filtered.valueChanges
    .pipe(
      startWith(this.filtered.value),
      debounceTime(250),
      distinctUntilChanged(),
      switchMap(val => this.namebasicsService.getNames(val || "A"))
    );

  }

  displayTitleFn(namebasics: Name_Basics): string{
    return namebasics ? namebasics.primaryName + ', ' + namebasics.birthYear + ', ' + namebasics.deathYear + ', ' + namebasics.primaryProfession : '';
  }

  namebasicsSelected(evt: MatOptionSelectionChange, namebasics: Name_Basics){
    if(evt.source.selected && namebasics){
      this.selectedName = namebasics;
      
      this.titleprincipalsService.getTitles(this.selectedName.nconst).pipe(catchError(this.handleError)).subscribe(data =>{
        this.titleprincipals = data
        console.log(this.titleprincipals);     
      })
    
    }
    else{
      this.selectedName = new Name_Basics("","",0,0,"","");
    } 
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