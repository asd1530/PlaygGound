import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class BrowseService {
  serviceData: Object[];
  constructor(private http: Http) {
    http.get('http://localhost:1337/person').subscribe(res => {
      this.serviceData = res.json();
    });
  }

  loadPersons(): Object[] {
    return this.serviceData;
  }
}
