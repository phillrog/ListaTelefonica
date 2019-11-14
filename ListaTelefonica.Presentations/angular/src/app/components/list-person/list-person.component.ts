import { Component, OnInit, ViewChild } from '@angular/core';
import { SidenavPersonFormService } from 'src/app/services/sidenav-person-form.service';
import { MatSidenav, MatDialog } from '@angular/material';
import { PersonFormDialogComponent } from '../person-form-dialog/person-form-dialog.component';

const ELEMENT_DATA: models.Person[] = [{
  Id: 56,
  Name: "TESTE VAI VARIO ",
  DateBirth: "2019-11-12T09:30:38.362481",
  Phones: [
      {
          Id: 69,
          Description: "1HEHEHE",
          Number: "993320555123"
      }
  ]
},
{
  Id: 56,
  Name: "TESTE VAI VARIO ",
  DateBirth: "2019-11-12T09:30:38.362481",
  Phones: [
      {
          Id: 69,
          Description: "1HEHEHE",
          Number: "993320555123"
      }
  ]
},
{
  Id: 56,
  Name: "TESTE VAI VARIO ",
  DateBirth: "2019-11-12T09:30:38.362481",
  Phones: [
      {
          Id: 69,
          Description: "1HEHEHE",
          Number: "993320555123"
      }
  ]
},
{
  Id: 56,
  Name: "TESTE VAI VARIO ",
  DateBirth: "2019-11-12T09:30:38.362481",
  Phones: [
      {
          Id: 69,
          Description: "1HEHEHE",
          Number: "993320555123"
      }
  ]
},
{
  Id: 56,
  Name: "TESTE VAI VARIO ",
  DateBirth: "2019-11-12T09:30:38.362481",
  Phones: [
      {
          Id: 69,
          Description: "1HEHEHE",
          Number: "993320555123"
      }
  ]
},
{
  Id: 56,
  Name: "TESTE VAI VARIO ",
  DateBirth: "2019-11-12T09:30:38.362481",
  Phones: [
      {
          Id: 69,
          Description: "1HEHEHE",
          Number: "993320555123"
      }
  ]
},
{
  Id: 56,
  Name: "TESTE VAI VARIO ",
  DateBirth: "2019-11-12T09:30:38.362481",
  Phones: [
      {
          Id: 69,
          Description: "1HEHEHE",
          Number: "993320555123"
      }
  ]
},
{
  Id: 56,
  Name: "TESTE VAI VARIO ",
  DateBirth: "2019-11-12T09:30:38.362481",
  Phones: [
      {
          Id: 69,
          Description: "1HEHEHE",
          Number: "993320555123"
      }
  ]
},
{
  Id: 56,
  Name: "TESTE VAI VARIO ",
  DateBirth: "2019-11-12T09:30:38.362481",
  Phones: [
      {
          Id: 69,
          Description: "1HEHEHE",
          Number: "993320555123"
      }
  ]
},
{
  Id: 56,
  Name: "TESTE VAI VARIO ",
  DateBirth: "2019-11-12T09:30:38.362481",
  Phones: [
      {
          Id: 69,
          Description: "1HEHEHE",
          Number: "993320555123"
      }
  ]
},
{
  Id: 56,
  Name: "TESTE VAI VARIO ",
  DateBirth: "2019-11-12T09:30:38.362481",
  Phones: [
      {
          Id: 69,
          Description: "1HEHEHE",
          Number: "993320555123"
      }
  ]
}
];

@Component({
  selector: 'app-list-person',
  templateUrl: './list-person.component.html',
  styleUrls: ['./list-person.component.scss']
})
export class ListPersonComponent implements OnInit {
  
  dataSource = ELEMENT_DATA;
  displayedColumns: string[] = ['Id', 'Name', 'DateBirth', 'update', 'delete'];
  
  constructor(public dialog: MatDialog) {}

  openDialog(): void {
    const dialogRef = this.dialog.open(PersonFormDialogComponent, {
      width: '250px',
      data: {name: 'this.name, animal: this.animal'}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    
    });
  }

  ngOnInit() {
  }


}
