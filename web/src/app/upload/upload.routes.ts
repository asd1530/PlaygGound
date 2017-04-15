import { UploadComponent } from './upload.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
    { path: 'upload', component: UploadComponent },
];

export const UPLOAD_ROUTES = RouterModule.forChild(routes);
