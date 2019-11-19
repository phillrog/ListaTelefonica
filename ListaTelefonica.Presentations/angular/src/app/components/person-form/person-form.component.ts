import { Component, OnInit, ViewChild, AfterViewInit, Input, EventEmitter } from '@angular/core';
import { FormBuilder} from '@angular/forms';
import { Person, Phone } from 'src/app/models/person';
import { MatTableDataSource, MatTabGroup } from '@angular/material';
import { PersonCrudService } from 'src/app/services/person-crud.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.scss']
})
export class PersonFormComponent implements OnInit, AfterViewInit {
  @ViewChild(MatTabGroup) tabGroup: MatTabGroup;
 
  dataSource = new MatTableDataSource<any>();
  personForm: Person;
  phone: Phone;
  phoneBkp: Phone;
  requiredFieldMsg: string = 'Este campo é obrigatório';
  displayedColumns: string[] = ['Description', 'Number', 'edit', 'delete'];
  showEdit = false;

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
    this.updatePerson();
  }

  updatePerson() {

    this.personForm.phones = this.dataSource.data;
  }

  editPerson() {
    this.personForm = {...this.person };
    this.newPhone();
    
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
    if (!row.id) { 
      this.removePhoneFromTab(row); 
      return;
    }

    this.personCrudService.deletePhone(row.id).subscribe(() => {
      this.removePhoneFromTab(row);
    });
  }

  editPhone(row) {
    this.phone = row;
    this.phoneBkp = {...row};
    this.showEdit = true;
    this.tabGroup.selectedIndex = 1;
  }

  saveLocalPhone() {
    const {data} = this.dataSource;
    this.newPhone();

    this.dataSource = new MatTableDataSource<any>([...data]);
    this.updatePerson();
    this.showEdit = false;
  }

  clear() {
    this.showEdit = false;
    const lastPhone = {... this.phone};
    const {data} = this.dataSource;

    const idxLast = data.indexOf(data.filter((d) => (d.id + d.description + d.number ) == ( lastPhone.id + lastPhone.description + lastPhone.number))[0]);
    data.splice(idxLast, 1);

    data.splice(idxLast, 0, this.phoneBkp );
    this.dataSource = new MatTableDataSource<any>([...data]);
    this.updatePerson();

    this.newPhone();
  }


  removePhoneFromTab(row) {
    const {data} = this.dataSource;

    const rowIdx = data.indexOf(row);

    data.splice(rowIdx, 1);

    this.dataSource.connect().next([...data]);
  }

  save(row: Person): Observable<any> {
    const {data} = this.dataSource;
    row.phones = data ;

    if (row.id > 0) {
      return this.personCrudService.put(row);
    } else {
      return this.personCrudService.post(row);
    }
  }

}
