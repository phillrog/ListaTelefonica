import { Component, OnInit, ViewChild } from '@angular/core';
import { SidenavPersonFormService } from 'src/app/services/sidenav-person-form.service';
import { MatSidenav, MatDialog, MatTableDataSource } from '@angular/material';
import { PersonFormDialogComponent } from '../person-form-dialog/person-form-dialog.component';
import { Person } from 'src/app/models/person';

@Component({
  selector: 'app-list-person',
  templateUrl: './list-person.component.html',
  styleUrls: ['./list-person.component.scss']
})
export class ListPersonComponent implements OnInit {
  
  dataSource = new MatTableDataSource<any>();
  displayedColumns: string[] = ['Id', 'Name', 'DateBirth', 'update', 'delete'];
  
  constructor(public dialog: MatDialog) {}

  openDialog(personSelected): void {
    const dialogRef = this.dialog.open(PersonFormDialogComponent, {
      height: '100%',
      width: '80%',
      data: {descriptionRegister: 'Editar', type: 1, person: personSelected}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
    
    });
  }

  ngOnInit() {
  }


  editPerson(row) {
    this.openDialog(row);
  }

  deletePerson(row) {

  }
}
