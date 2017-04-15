import { BrowseService } from './browse.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-browse',
  templateUrl: './browse.component.html',
  styleUrls: ['./browse.component.scss'],
  providers: [BrowseService]
})
export class BrowseComponent implements OnInit {

  constructor(private browseService:BrowseService ) { }

  ngOnInit() {
    this.browseService.loadPersons();
  }

}
