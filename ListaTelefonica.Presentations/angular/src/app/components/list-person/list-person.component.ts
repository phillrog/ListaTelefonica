import { Component, OnInit, Input, EventEmitter, AfterViewInit, OnDestroy } from '@angular/core';
import { MatDialog, MatTableDataSource } from '@angular/material';
import { PersonFormDialogComponent } from '../person-form-dialog/person-form-dialog.component';
import { PersonCrudService } from 'src/app/services/person-crud.service';
import { Subscription } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-list-person',
  templateUrl: './list-person.component.html',
  styleUrls: ['./list-person.component.scss']
})
export class ListPersonComponent implements OnInit, OnDestroy {
  
  subscription: Subscription;
  dataSourceBkp = new MatTableDataSource<any>();
  dataSource = new MatTableDataSource<any>();
  displayedColumns: string[] = ['id', 'name', 'dateBirth', 'update', 'delete'];
  filterMoreTwoPhoneBind = false;
  
  constructor(public dialog: MatDialog, private personCrudService: PersonCrudService,
    private toastr: ToastrService) {
    this.updateDataSource();

    this.subscription = this.personCrudService.subject.asObservable()
    .subscribe(message => this.updateDataSource());
  }

  openDialog(personSelected): void {
    const dialogRef = this.dialog.open(PersonFormDialogComponent, {
      height: '100%',
      width: '80%',
      data: {descriptionRegister: 'Editar', type: 1, person: personSelected}
    });

    dialogRef.afterClosed().subscribe(result => {
      this.updateDataSource();
    });
  }

  ngOnInit() {
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  updateDataSource() {
    this.personCrudService.getAll().subscribe((data: any) => {
      this.dataSource = new MatTableDataSource<any>(data);
    });
  }

  editPerson(row) {
    this.openDialog(row);
  }

  deletePerson(row) {
    this.personCrudService.delete(row.id).subscribe((data: any) => {
      this.dataSource = new MatTableDataSource<any>(data);      
      this.updateDataSource();
    });
  }

  applyFilter(filterValue: string) {
    if(filterValue.length > 0) { 
      this.filterMoreTwoPhone(false);
      this.filterMoreTwoPhoneBind = false;
    }
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  filterMoreTwoPhone(e) {
    let { data} = this.dataSource;
    
    if ( e == true) {
      this.dataSourceBkp = new MatTableDataSource<any>(data);

      this.dataSource = new MatTableDataSource<any>(data.filter(e => e.phones.length > 1));
    } else {
      this.dataSource = new MatTableDataSource<any>(this.dataSourceBkp.data);
    }
  }
}
