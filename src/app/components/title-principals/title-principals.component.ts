import { Component, OnInit } from '@angular/core';
import { MatOptionSelectionChange, MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatSnackBar} from '@angular/material';
import { FormControl, Validators} from '@angular/forms';
import { Title_Principals } from 'src/app/shared/title_principals.models';
import { title_principalsService } from 'src/app/shared/title_principals.service';
import { Observable } from 'rxjs';
import { startWith, distinctUntilChanged, debounceTime, switchMap} from 'rxjs/operators';

@Component({
  selector: 'app-title-principals',
  templateUrl: './title-principals.component.html',
  styleUrls: ['./title-principals.component.css'],
})
export class TitlePrincipalsComponent implements OnInit {
  
  public filtered: FormControl = new FormControl();
  public filteredPrincipals: Observable<Title_Principals[]> = null;

  public TconstTitleInput = new FormControl({value: '', disabled: true});
  public OrderingInput = new FormControl({value: '', disabled: true});
  public NconstTitleInput = new FormControl({value: '', disabled: true});
  public CategoryTitleInput = new FormControl('', [Validators.required]);
  public JobInput = new FormControl('', [Validators.required]);
  public CharactersInput = new FormControl('', [Validators.required]);

  public selectedPrincipal: Title_Principals = new Title_Principals("",0,"","","","");
  public index: number = 0;

  constructor(private title_principalsService: title_principalsService) { }

  ngOnInit(){

    this.filteredPrincipals = this.filtered.valueChanges
    .pipe(
      startWith(this.filtered.value),
      debounceTime(250),
      distinctUntilChanged(),
      switchMap(val => this.title_principalsService.getTitles(val || 't'))
    );

  }

  displayTitleFn(title_principals: Title_Principals): string{
    return title_principals ? title_principals.tconst + ', ' + title_principals.ordering + ', ' + title_principals.nconst + ', ' + title_principals.category + ', ' + title_principals.job + ', ' + title_principals.characters : '';
  }

  title_principalsSelected(evt: MatOptionSelectionChange, title_principals: Title_Principals){
    if(evt.source.selected && title_principals){
      this.selectedPrincipal = title_principals;
    }
    else{
      this.selectedPrincipal = new Title_Principals("",0,"","","","");
    }
}}
