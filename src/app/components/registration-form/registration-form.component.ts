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


//public user: User = null;
//public users = [
 // {"userId":6,"userName":"Mason.Thomas","fullName":"Mason Thomas","password":"","created":"2020-03-08T19:23:00"},
 // {"userId":7,"userName":"Mason.Tdfhfdfdh","fullName":"Mason Thomas","password":"","created":"2020-03-08T19:23:00"}];

public users: User[] = null;
public index: number = 0;
public lastIndex:number = 1;
public creatingNew: boolean = false;

  constructor(private usersService: UsersService,
    private snackBar: MatSnackBar) { }

  ngOnInit() {
    //this.usersService.getUser(1).subscribe(data => {
   // var data = this.usersService.getUser(1).subscribe(data => {
     // this.users = data;
     this.usersService.getUsers().subscribe(data => { 
       this.users = data;
       this.lastIndex = this.users.length - 1;
     this.displayUser();
    });
  }

   displayUser(): void {
     this.userIdInput.setValue(this.users[this.index].userId);
     this.userNameInput.setValue(this.users[this.index].userName);
     this.fullNameInput.setValue(this.users[this.index].fullName);
     this.passwordInput.setValue(this.users[this.index].password);
     this.createdInput.setValue(this.users[this.index].created);
     let u: User = this.users[this.index];
     this.users.push(new User(0,"","","", new Date()));
     this.index = this.users.length -1;
     this.lastIndex = this.users.length -1;
     this.creatingNew = true;
     this.displayUser();
   }

   displayUser1(): void {
    this.userIdInput.setValue(this.users[this.index].userId);
    this.userNameInput.setValue(this.users[this.index].userName);
    this.fullNameInput.setValue(this.users[this.index].fullName);
   this.passwordInput.setValue(this.users[this.index].password);
    this.createdInput.setValue(this.users[this.index].created);
    this.displayUser1();
  }


   updateUserFromForm()  : void {
     this.users[this.index].userId = parseInt(this.userIdInput.value);
     this.users[this.index].userName = this.userNameInput.value;
     this.users[this.index].fullName = this.fullNameInput.value;
     this.users[this.index].password = this.passwordInput.value;
     this.users[this.index].created = this.createdInput.value;

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

createNewButtonClick() {
  let u: User = this.users[this.index];
  this.users.push(new User(0,"","","", new Date()));
  this.index = this.users.length -1;
  this.lastIndex = this.users.length -1;
  this.creatingNew = true;
  this.displayUser();
}
    
      saveButtonClick() {
        if(this.creatingNew){
        this.updateUserFromForm();
         this.usersService.newUser(this.users[this.index]).subscribe(
           response => {
             //console.log(response);
             this.users[this.index] = response;
             this.displayUser1();
             this.creatingNew = false;
             this.snackBar.open(this.users[this.index].userName, "Saved", {duration: 2000,});
  
            },
          error => console.log(error)
         );
          }
          else {
            this.updateUserFromForm();
            this.usersService.updateUser(this.users[this.index]).subscribe(
              response => {
                console.log(response)
                this.snackBar.open(this.users[this.index].userName, "Saved", {duration: 2000,});
              },
              error => console.log(error)
            );

            
          }
       }

       cancelButtonClick() {
         let i: number = this.index;
         this.index--;
         this.users.splice(i, 1);
         this.lastIndex = this.users.length -1;
         this.creatingNew = false;
         this.displayUser();
       }

       deleteButtonClick() {
         this.usersService.deleteCountry(this.users[this.index].userId).subscribe(
          response => {
            let i: number = this.index;
            this.index--;
            this.users.splice(i, 1);
            this.lastIndex = this.users.length - 1;
            this.displayUser();
            this.users[this.index] = response;
            this.snackBar.open(this.users[this.index].userName, "Deleted", {duration: 2000,});
          
          },
          error => console.log(error)
        );

           }
       }

  