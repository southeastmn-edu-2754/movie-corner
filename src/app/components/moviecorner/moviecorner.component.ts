import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import {FormControl, Validators} from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import {DataSource} from '@angular/cdk/collections';
import {User, UserIface} from '../../shared/user.model';
import {UsersService} from '../../shared/users.service';

@Component({
  selector: 'app-moviecorner',
  templateUrl: './moviecorner.component.html',
  styleUrls: ['./moviecorner.component.css'],
})
export class MoviecornerComponent implements OnInit {
  public userIdInput = new FormControl({value: '', disabled: true} ,[Validators.required]);
  public userNameInput = new FormControl('',[Validators.required]);
  public fullNameInput = new FormControl('',[Validators.required]);
  public passwordInput = new FormControl('',[Validators.required]);
  public createdInput = new FormControl('',[Validators.required]);


//public user: User = null;
//public users = [
 // {"userId":6,"userName":"Mason.Thomas","fullName":"Mason Thomas","password":"","created":"2020-03-08T19:23:00"},
 // {"userId":7,"userName":"Mason.Tdfhfdfdh","fullName":"Mason Thomas","password":"","created":"2020-03-08T19:23:00"}];

public users: any[] = []; 
public index: number = 0;
public lastIndex:number = 1;
public creatingNew: boolean = false;

  constructor(private usersService: UsersService) { }

  ngOnInit() {
    //this.usersService.getUser(1).subscribe(data => {
   // var data = this.usersService.getUser(1).subscribe(data => {
     // this.users = data;
     this.usersService.getUsers().subscribe(data => { 
       this.users = data;
       this.lastIndex - this.users.length - 1;
     this.displayUser();
    });
  }

   displayUser(): void {
     this.userIdInput.setValue(this.users[this.index].userId);
     this.userNameInput.setValue(this.users[this.index].userName);
     this.fullNameInput.setValue(this.users[this.index].fullName);
    this.passwordInput.setValue(this.users[this.index].password);
     this.createdInput.setValue(this.users[this.index].created);
   }

   updateUserFromForm()  : void {
     this.users[this.index].userId = parseInt(this.userIdInput.value);
     this.users[this.index].userName = this.userNameInput.value;
     this.users[this.index].fullName = this.fullNameInput.value;
     this.users[this.index].password = this.passwordInput.value;
     this.users[this.index].created = this.createdInput.value;

    }

  getPreviousButtonClick(): void {
     this.index--;
     this.displayUser();
   }

   getNextButtonClick(): void {
    this.index++;
    this.displayUser();
  }


// getUser1Button() :void {
//   this.usersService.getUser(1).subscribe(data => {
//     this.user = data;
//     this.displayUser();
//   });
//   }


//   getUser2Button() :void {
//     this.usersService.getUser(2).subscribe(data => {
//       this.user = data;
//       this.displayUser();
//     });
//     }
  

//     getUser3Button():void {
//       this.usersService.getUser(3).subscribe(data => {
//         this.user = data;
//         this.displayUser();
//       });
//       }
    
      newButtonClick() {

         this.usersService.newUser().subscribe(
           response => console.log(response),
          error => console.log(error)
         );
        
       }


  }
  