import { Component, OnInit } from '@angular/core';

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
  displayedColumns: string[] = ['Id', 'Name', 'DateBirth', 'delete'];
  
  constructor() { 
    
  
  }

  ngOnInit() {
  }

}
