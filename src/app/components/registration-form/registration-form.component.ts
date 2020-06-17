import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatSnackBar} from '@angular/material';
import {FormControl, Validators} from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import {DataSource} from '@angular/cdk/collections';
import {User, UserIface} from '../../shared/user.model';
import {UsersService} from '../../shared/users.service';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements OnInit {

public userIdInput = new FormControl({value: '', disabled: true} ,[Validators.required]);
  public userNameInput = new FormControl('',[Validators.required]);
  public fullNameInput = new FormControl('',[Validators.required]);
  public passwordInput = new FormControl('',[Validators.required]);
  public createdInput = new FormControl('',[Validators.required]);

public users: User[] = new Array<User>();

public index: number = 0;
public lastIndex:number = 1;
public creatingNew: boolean = false;

  constructor(private usersService: UsersService,
    private snackBar: MatSnackBar) { }

  ngOnInit() { }

  displayUser1(): void {
    this.userIdInput.setValue(this.users[this.index].userId);
    this.userNameInput.setValue(this.users[this.index].userName);
    this.fullNameInput.setValue(this.users[this.index].fullName);
    this.passwordInput.setValue(this.users[this.index].password);
    this.createdInput.setValue(this.users[this.index].created);
  }


  updateUserFromForm()  : void {
    this.users[0] = new User(0,"","","", new Date());
    this.users[this.index].userName = this.userNameInput.value;
    this.users[this.index].fullName = this.fullNameInput.value;
    this.users[this.index].password = this.passwordInput.value;
    console.log(this.users[this.index]);
  }
    
saveButtonClick() {
  this.updateUserFromForm();
    this.usersService.newUser(this.users[this.index]).subscribe(
      response => {
        console.log(response);
        this.users[this.index] = response;
        this.displayUser1();
        this.creatingNew = false;
        this.snackBar.open(this.users[this.index].userName, "Saved", {duration: 2000,});

      },
    error => console.log(error)
    );
  }

  cancelButtonClick() {
    let i: number = this.index;
    this.index--;
    this.users.splice(i, 1);
    this.lastIndex = this.users.length -1;
    this.creatingNew = false;
    this.displayUser1();
  }
}

  