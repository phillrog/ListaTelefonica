import { Component, OnInit, ViewChild, AfterViewInit, Input, EventEmitter } from '@angular/core';
import { FormBuilder} from '@angular/forms';
import { Person, Phone } from 'src/app/models/person';
import { MatTableDataSource } from '@angular/material';
import { PersonCrudService } from 'src/app/services/person-crud.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.scss']
})
export class PersonFormComponent implements OnInit, AfterViewInit {

 
  dataSource = new MatTableDataSource<any>();
  personForm: Person;
  phone: Phone;
  requiredFieldMsg: string = 'Este campo é obrigatório';
  displayedColumns: string[] = ['Description', 'Number', 'delete'];
  
  @Input()
  type: number;

  @Input()
  person: Person;
  
  @Input()
  onClickSaveEvent: EventEmitter<boolean>;
 
  constructor(private personCrudService: PersonCrudService) { 
    
  }

  ngOnInit() {
    if(this.type == 0) {
      this.newPerson();
      this.newPhone();
    } else if (this.type == 1) {
      this.editPerson();
    }
  }

  ngAfterViewInit(): void {
    if (this.onClickSaveEvent) {
      this.onClickSaveEvent.subscribe(data => {
        this.save(this.personForm).subscribe(data => {   
          
          this.personCrudService.subject.next(true);
          
        });
      });
    }
  }

  newPerson() {
    this.personForm = new Person();
    this.personForm.phones = this.dataSource.data;
  }

  editPerson() {
    this.personForm = {...this.person };
    this.phone = new Phone();

    this.dataSource = new MatTableDataSource<any>([...this.person.phones]);;
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

  save(row: Person): Observable<any> {
    const {id} = row;

    if (id) {
      return this.personCrudService.put(row);
    } else {
     
      const {data} = this.dataSource;

      row.phones = data 
      
      return this.personCrudService.post(row);
    }
  }

}
