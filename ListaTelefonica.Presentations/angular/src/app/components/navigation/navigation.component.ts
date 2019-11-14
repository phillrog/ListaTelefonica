import { Component, ViewChild, EventEmitter } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { MatDialog, MatTableDataSource } from '@angular/material';
import { PersonFormDialogComponent } from '../person-form-dialog/person-form-dialog.component';
import { PersonCrudService } from 'src/app/services/person-crud.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent {
  
  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );

  constructor(private breakpointObserver: BreakpointObserver, public dialog: MatDialog, private personCrudService : PersonCrudService) {}

  openDialog(): void {
    const dialogRef = this.dialog.open(PersonFormDialogComponent, {
      height: '100%',
      width: '80%',
      data: {descriptionRegister: 'Cadastro', type: 0}
    });

    dialogRef.afterClosed().subscribe(result => {
      
    });
  }

  resfresh() {
    this.personCrudService.subject.next(true);
  }
}
