import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UploadComponent } from './upload.component';
import { GrowlModule } from 'primeng/primeng';
import { FileUploadModule } from 'primeng/primeng';
import { UPLOAD_ROUTES } from './upload.routes';

@NgModule({
  imports: [
      CommonModule,
      GrowlModule,
      FileUploadModule,
      UPLOAD_ROUTES
  ],
  declarations: [UploadComponent]
})
export class UploadModule { }
