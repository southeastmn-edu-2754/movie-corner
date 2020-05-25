import { Component, OnInit } from '@angular/core';
import { MatOptionSelectionChange, MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatSnackBar} from '@angular/material';
import { FormControl, Validators} from '@angular/forms';
import { Observable } from 'rxjs';
import { Name_Basics } from 'src/app/shared/namebasics.model';
import { Title_Basics } from 'src/app/shared/title_basics.model';
import { titlebasicsService } from 'src/app/shared/titlebasics.service';
import { namebasicsService } from 'src/app/shared/namebasics.service';
import { Title_Principals } from 'src/app/shared/title_principals.model';
import { title_principalsService } from 'src/app/shared/title_principals.service';
import { startWith, distinctUntilChanged, debounceTime, switchMap} from 'rxjs/operators';

@Component({
  selector: 'app-name-basics',
  templateUrl: './name-basics.component.html',
  styleUrls: ['./name-basics.component.css']
})

export class NameBasicsComponent implements OnInit {


  public filtered: FormControl = new FormControl();
  // public NconstNameInput = new FormControl({value: '', disabled: true});
  public PrimaryNameInput = new FormControl();
  public BirthYearInput = new FormControl();
  public DeathYearInput = new FormControl();
  public PrimaryProfessionInput = new FormControl();
  // public KnownForTitlesInput = new FormControl('', [Validators.required]);

  public selectedName: Name_Basics = new Name_Basics("","",0,0,"","");
  public filteredName: Observable<Name_Basics[]> = null;
  public titleprincipals: Title_Principals[] = new Array<Title_Principals>();
  // public title_basics: Title_Basics[] = new Array<Title_Basics>();

  constructor(private namebasicsService: namebasicsService, 
    private titleprincipalsService: title_principalsService,
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

      this.titleprincipalsService.getTitles(this.selectedName.nconst).subscribe(data =>{
        this.titleprincipals = data
        console.log(this.titleprincipals);     
      })
      
    }
    else{
      this.selectedName = new Name_Basics("","",0,0,"","");
    }
}}
