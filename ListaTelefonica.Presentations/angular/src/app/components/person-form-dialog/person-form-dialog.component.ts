import { Component, OnInit, Inject, EventEmitter } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Person } from 'src/app/models/person';

@Component({
  selector: 'app-person-form-dialog',
  templateUrl: './person-form-dialog.component.html',
  styleUrls: ['./person-form-dialog.component.scss']
})
export class PersonFormDialogComponent implements OnInit {
  person: Person;
  onClickSave: EventEmitter<boolean> = new EventEmitter();

  constructor(
    public dialogRef: MatDialogRef<PersonFormDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
      this.person = data['person']
    }

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit() {
  }

  save(): void {
    this.onClickSave.emit();
  }

}
