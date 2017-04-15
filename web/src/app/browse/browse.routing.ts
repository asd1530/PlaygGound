import { BrowseComponent } from './browse.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'browse', component: BrowseComponent },
];

export const BROWSE_ROUTES = RouterModule.forChild(routes);
