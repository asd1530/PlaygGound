import { BROWSE_ROUTES } from './browse.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowseComponent } from './browse.component';
import { TreeTableModule,  SharedModule } from 'primeng/primeng';

@NgModule({
  imports: [
    CommonModule,
      BROWSE_ROUTES,
      TreeTableModule,
      SharedModule
  ],
  declarations: [BrowseComponent]
})
export class BrowseModule { }
