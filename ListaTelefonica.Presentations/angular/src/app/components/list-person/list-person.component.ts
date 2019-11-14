import { Component, OnInit } from '@angular/core';
import { MatDialog, MatTableDataSource } from '@angular/material';
import { PersonFormDialogComponent } from '../person-form-dialog/person-form-dialog.component';
import { PersonCrudService } from 'src/app/services/person-crud.service';

@Component({
  selector: 'app-list-person',
  templateUrl: './list-person.component.html',
  styleUrls: ['./list-person.component.scss']
})
export class ListPersonComponent implements OnInit {
  
  dataSource = new MatTableDataSource<any>();
  displayedColumns: string[] = ['id', 'name', 'dateBirth', 'update', 'delete'];
  
  constructor(public dialog: MatDialog, private personCrudService: PersonCrudService) {
    this.updateDataSource();
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

  updateDataSource() {
    this.personCrudService.getAll().subscribe((data: any) => {
      this.dataSource = new MatTableDataSource<any>(data);
    });
  }

  editPerson(row) {
    this.openDialog(row);
  }

  deletePerson() {

  }
}
