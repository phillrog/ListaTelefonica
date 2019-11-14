import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatSidenav } from '@angular/material';
import { SidenavPersonFormService } from 'src/app/services/sidenav-person-form.service';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.scss']
})
export class PersonFormComponent implements OnInit, AfterViewInit {

 
  constructor() { 
    debugger;
  }

  ngOnInit() {
  }

  ngAfterViewInit(): void {
    
  }

}
