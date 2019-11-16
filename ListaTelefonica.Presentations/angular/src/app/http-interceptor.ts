import { Injectable } from "@angular/core"
import { Observable, of } from "rxjs";
import { tap, catchError } from "rxjs/operators";
import { ToastrService } from 'ngx-toastr';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpResponse, HttpErrorResponse } from '@angular/common/http';
@Injectable()
export class AppHttpInterceptor implements HttpInterceptor {
    constructor(public toasterService: ToastrService) {}
intercept(
        req: HttpRequest<any>,
        next: HttpHandler
      ): Observable<HttpEvent<any>> {
    
        return next.handle(req).pipe(
            tap(evt => {
                if (evt instanceof HttpResponse) {
                    let msg = '';
                    if (evt.status == 201 || evt.body.status == 'updated') msg = 'Registro salvo com sucesso';
                    else if (evt.body.status == 'deleted') msg = 'Registro deletado com sucesso';                        

                    if(msg.length >0) this.toasterService.success(msg, 'Atenção', { positionClass: 'toast-top-right' });
                }
            }),
            catchError((err: any) => {
                if(err instanceof HttpErrorResponse) {

                    try { 
                        if(!err.error.errors) {
                            err.error.forEach(errorMsg => {
                                this.toasterService.error(errorMsg.Message, 'Atenção', { positionClass: 'toast-top-right' });
                            });                    
                        } else {
                            this.toasterService.error('Informe os dados da pessoa', 'Atenção', { positionClass: 'toast-top-right' });
                        }   
                    } catch(e) {
                        this.toasterService.error('An error occurred', '', { positionClass: 'toast-top-right' });
                    }
                    //log error 
                }
                return of(err);
            }));
    
      }
      
}