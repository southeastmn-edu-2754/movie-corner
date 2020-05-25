import { Component, OnInit, Input } from '@angular/core';
import { MatOptionSelectionChange, MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatSnackBar} from '@angular/material';
import { FormControl, Validators} from '@angular/forms';
import { Title_Principals } from 'src/app/shared/title_principals.model';
import { title_principalsService } from 'src/app/shared/title_principals.service';
import { Title_Basics} from 'src/app/shared/title_basics.model';
import { titlebasicsService } from 'src/app/shared/titlebasics.service';
import { Observable } from 'rxjs';
import { startWith, distinctUntilChanged, debounceTime, switchMap} from 'rxjs/operators';

@Component({
  selector: 'app-title-principals',
  templateUrl: './title-principals.component.html',
  styleUrls: ['./title-principals.component.css'],
})
export class TitlePrincipalsComponent implements OnInit {
  @Input() Title_Principals :Title_Principals;
  
  public filtered: FormControl = new FormControl();
  public filteredPrincipals: Observable<Title_Principals[]> = null;

  public TconstTitleInput = new FormControl({value: '', disabled: true});
  public OrderingInput = new FormControl({value: '', disabled: true});
  public NconstTitleInput = new FormControl({value: '', disabled: true});
  public CategoryTitleInput = new FormControl('', [Validators.required]);
  public JobInput = new FormControl('', [Validators.required]);
  public CharactersInput = new FormControl('', [Validators.required]);

  public selectedPrincipal: Title_Principals = new Title_Principals("",0,"","","","");
  public selectedTitleBasics: Title_Basics = new Title_Basics("","","","",0,0,0,0,"");

  public titlebasics: Title_Basics[] = new Array<Title_Basics>();

  constructor(private title_principalsService: title_principalsService,
    private titlebasicsService: titlebasicsService) { }

  ngOnInit(){

    // this.filteredPrincipals = this.filtered.valueChanges
    // .pipe(
    //   startWith(this.filtered.value),
    //   debounceTime(250),
    //   distinctUntilChanged(),
    //   switchMap(val => this.title_principalsService.getTitles(val || 't'))
    // );
    

    this.titlebasicsService.getTitles(this.Title_Principals.tconst).subscribe(data =>{
      this.titlebasics = data;
      console.log(this.titlebasics);
    })

  }

  // displayTitleFn(title_principals: Title_Principals): string{
  //   return title_principals ? title_principals.tconst + ', ' + title_principals.ordering + ', ' + title_principals.nconst + ', ' + title_principals.category + ', ' + title_principals.job + ', ' + title_principals.characters : '';
  // }

//   title_principalsSelected(evt: MatOptionSelectionChange, title_principals: Title_Principals){
//     if(evt.source.selected && title_principals){
//       this.selectedPrincipal = title_principals;
//     }
//     else{
//       this.selectedPrincipal = new Title_Principals("",0,"","","","");
//     }
// }
}
