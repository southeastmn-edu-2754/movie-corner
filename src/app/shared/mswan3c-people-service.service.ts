import { Injectable } from '@angular/core';
import { Person } from './person.model';

@Injectable()
export class Mswan3cPeopleService {
  public index: number = 0;
  public creatingNew: boolean = false;

  public people: Person[] = [
    new Person("308 Pioneer Rd", "Red Wing", "MN", "55066", 
      "mswanson@southeastmn.edu", "123", "45", "6789", 12345.67), 
    new Person("1111 11th St", "Red Wing", "MN", "55066", 
      "aaaa@email.com", "111", "11", "1111", 11111.11), 
  ];

  constructor() { }

  getCurrent(): Person {
    return this.people[this.index];
  }

  getNext(): Person {
    if (this.index < this.people.length - 1) {
      this.index++;
    }
    return this.people[this.index];
  }
  
  getPrevious(): Person {
    if (this.index > 0) {
      this.index--;
    }
    return this.people[this.index];
  }

  isFirst(): boolean {
    return this.index == 0;
  }

  isLast(): boolean {
    return this.index == this.people.length - 1;
  }

  createNew(): Person {
    this.creatingNew = true;
    return new Person("", "", "", "", "", "", "", "", 0.0);
  }

  add(person: Person): Person {
    this.index = this.people.push(person) - 1;
    this.creatingNew = false;
    return this.people[this.index];
  }
}
