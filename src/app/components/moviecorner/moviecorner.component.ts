import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import {FormControl, Validators} from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import {DataSource} from '@angular/cdk/collections';
import {User} from '../../shared/user.model';

@Component({
  selector: 'app-moviecorner',
  templateUrl: './moviecorner.component.html',
  styleUrls: ['./moviecorner.component.css'],
})
export class MoviecornerComponent implements OnInit {
  public userIdInput = new FormControl('',[Validators.required]);
  public userNameInput = new FormControl('',[Validators.required]);
  public fullNameInput = new FormControl('',[Validators.required]);
  public passwordInput = new FormControl('',[Validators.required]);
  public createdInput = new FormControl('',[Validators.required]);
  public user: User = null;


  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/user/1').subscribe(data => {
      this.user = new User(
        data["userId"], 
        data["userName"], 
        data["fullName"], 
        data["password"], 
        data["created"]);
        this.userIdInput.setValue(this.user.userId);
        this.userNameInput.setValue(this.user.userName);
        this.fullNameInput.setValue(this.user.fullName);
        this.passwordInput.setValue(this.user.password);
        this.createdInput.setValue(this.user.created);

      });
   
    }
  
  }