import { Component, OnInit } from '@angular/core';
import { FileUploadModule, Message, GrowlModule } from 'primeng/primeng';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.scss']
})
export class UploadComponent {
    msgs: Message[];

    uploadedFiles: any[] = [];

    onUpload(event) {
        for (let file of event.files) {
            this.uploadedFiles.push(file);
        }

        this.msgs = [];
        this.msgs.push({ severity: 'info', summary: 'File Uploaded', detail: '' });
    }

}
