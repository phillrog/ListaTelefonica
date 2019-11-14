import { Component, OnInit, ViewChild, AfterViewInit, Input } from '@angular/core';
import { FormBuilder} from '@angular/forms';
import { Person, Phone } from 'src/app/models/person';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.scss']
})
export class PersonFormComponent implements OnInit {
 
  dataSource = [
   
      {
          Id: 69,
          Description: "1HEHEHE",
          Number: "993320555123"
      },
      {
        Id: 69,
        Description: "1HEHEHE",
        Number: "993320555123"
    },
    {
      Id: 69,
      Description: "1HEHEHE",
      Number: "993320555123"
  },
  {
    Id: 69,
    Description: "1HEHEHE",
    Number: "993320555123"
},
{
  Id: 69,
  Description: "1HEHEHE",
  Number: "993320555123"
},
{
  Id: 69,
  Description: "1HEHEHE",
  Number: "993320555123"
},
{
  Id: 69,
  Description: "1HEHEHE",
  Number: "993320555123"
},
{
  Id: 69,
  Description: "1HEHEHE",
  Number: "993320555123"
},
{
  Id: 69,
  Description: "1HEHEHE",
  Number: "993320555123"
}
  
  ];
  personForm: Person;
  phone: Phone;
  requiredFieldMsg: string = 'Este campo é obrigatório';
  displayedColumns: string[] = ['Id', 'Description', 'Number', 'delete'];
  
  @Input()
  type: number;
 
  constructor() { 
    
  }

  ngOnInit() {
    if(this.type == 0) {
      this.createPerson();
    }
    
  }

  createPerson() {
    this.personForm = new Person();
    this.phone = new Phone ();
  }

}
