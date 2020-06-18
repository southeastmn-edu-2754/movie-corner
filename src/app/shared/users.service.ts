import { Injectable } from '@angular/core';
import {User, UserIface} from './user.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  public user : User = null;
  private movieApiUrl: string = 'https://localhost:5001/api/user/';

  constructor(private httpClient: HttpClient) { }

  getUser(id: number) : Observable<User> {
    return this.httpClient.get(this.movieApiUrl + id.toString())
    .pipe(map(data => {
        var user: User = new User(
          data["userId"], 
          data["userName"], 
          data["fullName"], 
          data["password"], 
          data["created"]);

          console.log(user);
          return user;
  }));

}

getUsers(): Observable<User[]> {
  return this.httpClient.get<User[]>('https://localhost:5001/api/user/')
  map(data =>{
    let users : User[] = new Array<User>();

    let c = data[0];
    users.push( new User(
    //var country: Country = new Country(
      c["userId"], 
      c["userName"], 
      c["fullName"],
      c["password"], 
      c["created"]));

      return users;
  
});
}



newUser(user: User): Observable<User>{
 //let user2 = {"userName":"Ummer.Siddique","fullName":"Ummer Siddique","password":"12345","created":"2020-04-17T19:23:00"};
 let strUser: string = JSON.stringify(user);
 let regex = /"userId":\d+,/;
 strUser = strUser.replace(regex, "");
 let jsonUser = JSON.parse(strUser);
 return this.httpClient.post(this.movieApiUrl, jsonUser)
  .pipe(map(data => {
    var user: User = new User(
      data["userId"], 
      data["userName"], 
      data["fullName"], 
      data["password"], 
      data["created"]);

      console.log(user);
      return user;
}));
}

deleteCountry(userId: number): Observable<User> {
  return this.httpClient.delete(this.movieApiUrl + userId.toString())
    .pipe(map(data => {
        var user: User = new User(
          data["userId"], 
          data["userName"], 
          data["fullName"], 
          data["password"], 
          data["created"]);

          console.log(user);
          return user;
        }));

}

updateUser(user: User) {
  let strUser: string = JSON.stringify(user);
  let jsonUser= JSON.parse(strUser);
  return this.httpClient.put(this.movieApiUrl + user.userId, jsonUser);
}


login(username: string, password: string) : Observable<boolean> {
  return this.httpClient.get(this.movieApiUrl + username + "/" + password);


}
}
