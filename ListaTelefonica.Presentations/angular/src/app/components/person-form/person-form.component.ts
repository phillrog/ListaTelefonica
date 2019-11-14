import { Component, OnInit, ViewChild, AfterViewInit, Input } from '@angular/core';
import { FormBuilder} from '@angular/forms';
import { Person, Phone } from 'src/app/models/person';
import { MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.scss']
})
export class PersonFormComponent implements OnInit {
 
  dataSource = new MatTableDataSource<any>();
  personForm: Person;
  phone: Phone;
  requiredFieldMsg: string = 'Este campo é obrigatório';
  displayedColumns: string[] = ['Description', 'Number', 'delete'];
  
  @Input()
  type: number;

  @Input()
  person: Person;
 
  constructor() { 
    
  }

  ngOnInit() {
    if(this.type == 0) {
      this.newPerson();
      this.newPhone();
    } else {
      this.editPerson()
    }
    
  }

  newPerson() {
    this.personForm = new Person();
    this.personForm.Phones = this.dataSource.data;
  }

  editPerson() {
    debugger;
    this.personForm = {...this.person };
    this.phone = new Phone();

    this.dataSource = new MatTableDataSource<any>([...this.person.Phones]);;
  }

  newPhone() {
    this.phone = new Phone ();
  }

  addNewPhone(){
    const {data} = this.dataSource;

    data.push(this.phone);

    this.dataSource.connect().next([...data]);
    this.newPhone();
  }

  deletePhone(row) {
    const {data} = this.dataSource;

    const rowIdx = data.indexOf(row);

    data.splice(rowIdx, 1);

    this.dataSource.connect().next([...data]);
  }

}
