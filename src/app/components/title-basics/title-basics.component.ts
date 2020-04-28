import {Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import {FormControl, Validators} from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import {DataSource} from '@angular/cdk/collections';
import { Title_Basics } from 'src/app/shared/title_basics.model';
import { titlebasicsService } from 'src/app/shared/titlebasics.service';

@Component({
  selector: 'app-title-basics',
  templateUrl: './title-basics.component.html',
  styleUrls: ['./title-basics.component.css']
})
export class TitleBasicsComponent implements OnInit {

  public TconstIdInput = new FormControl({value: '', disabled: true} ,[Validators.required]);
  public TitleTypeInput = new FormControl({value: '', disabled: true},[Validators.required]);
  public PrimaryTitleInput = new FormControl({value: '', disabled: true},[Validators.required]);
  public OriginalTitleInput = new FormControl({value: '', disabled: true},[Validators.required]);
  public IsAuditInput = new FormControl({value: '', disabled: true},[Validators.required]);
  public StartYearInput = new FormControl({value: '', disabled: true},[Validators.required]);
  public EndYearInput = new FormControl({value: '', disabled: true},[Validators.required]);
  public RunTimeInput = new FormControl({value: '', disabled: true},[Validators.required]);
  public GenreInput = new FormControl({value: '', disabled: true},[Validators.required]);


  public title_basics: Title_Basics[] = null;
  public index: number = 0;
  public lastIndex:number = 1;

  constructor(private titlebasics: titlebasicsService) { }

  ngOnInit(): void {

    this.titlebasics.getTitles().subscribe(data => {
      this.title_basics = data;
      this.lastIndex = this.title_basics.length - 1;
    this.displayMovie();
  })
  }

  displayMovie(): void {
    this.TconstIdInput.setValue(this.title_basics[this.index].tconst);
    this.TitleTypeInput.setValue(this.title_basics[this.index].titleType);
    this.PrimaryTitleInput.setValue(this.title_basics[this.index].primaryTitle);
    this.OriginalTitleInput.setValue(this.title_basics[this.index].originalTitle);
    this.IsAuditInput.setValue(this.title_basics[this.index].isAudit);
    this.StartYearInput.setValue(this.title_basics[this.index].startYear);
    this.EndYearInput.setValue(this.title_basics[this.index].endYear);
    this.RunTimeInput.setValue(this.title_basics[this.index].runtimeMinutes);
    this.GenreInput.setValue(this.title_basics[this.index].genres);
  }

  getPreviousButtonClick(): void {
    this.index--;
    this.displayMovie();
  }

  getNextButtonClick(): void {
   this.index++;
   this.displayMovie();
 }

}
