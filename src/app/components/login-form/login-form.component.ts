import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatSnackBar} from '@angular/material';
import {FormControl, Validators} from '@angular/forms';
import { Router } from "@angular/router";
import {HttpClient} from '@angular/common/http';
import {DataSource} from '@angular/cdk/collections';
import {User, UserIface} from '../../shared/user.model';
import {UsersService} from '../../shared/users.service';
import {AutofillMonitor} from '@angular/cdk/text-field';
import {AfterViewInit, ElementRef, OnDestroy, ViewChild} from '@angular/core';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  public userNameInput = new FormControl('',[Validators.required]);
  public passwordInput = new FormControl('',[Validators.required]);


public users: User[] = null;
public index: number = 0;
public lastIndex:number = 1;
public creatingNew: boolean = false;

  constructor(private usersService: UsersService,
    private snackBar: MatSnackBar,
    private _snackBar: MatSnackBar,
    private router: Router) { }

    openSnackBar(message: string, action: string) {
      this._snackBar.open(message, action, {
        duration: 2000,
      });
    }
  

  ngOnInit() {

  }


    
      loginButtonClick() {
        var userName: string = this.userNameInput.value;
        var password: string = this.passwordInput.value;
        this.usersService.login(userName,password).subscribe(data => {
     if (data["authenticated"])
     this.router.navigate(['/namebasics']);
     else
       this.snackBar.open("User name or password is incorrect. ", " Login Error", {duration: 2000,});
        });

            // this.snackBar.open(this.users[this.index].userName, "Saved", {duration: 2000,});
            
      
       }

       cancelButtonClick() {
        // let i: number = this.index;
       //  this.index--;
        // this.users.splice(i, 1);
       //  this.lastIndex = this.users.length -1;
       //  this.creatingNew = false;
       //  this.displayUser();
       }
      }



