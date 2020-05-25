import {Component, OnInit, Input } from '@angular/core';
import { MatOptionSelectionChange, MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatSnackBar} from '@angular/material';
import {FormControl, Validators} from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import {DataSource} from '@angular/cdk/collections';
import { Observable } from 'rxjs';
import { Title_Basics } from 'src/app/shared/title_basics.model';
import { titlebasicsService } from 'src/app/shared/titlebasics.service';


@Component({
  selector: 'app-title-basics',
  templateUrl: './title-basics.component.html',
  styleUrls: ['./title-basics.component.css']
})
export class TitleBasicsComponent implements OnInit {
  @Input() Title_Basics :Title_Basics;

  constructor(private titlebasics: titlebasicsService) { }

  ngOnInit(): void {

 }
}
