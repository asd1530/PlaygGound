import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { TreeNode } from 'primeng/primeng';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class BrowseService {
    constructor(private http: Http) {
    };

    loadReportData() {
        return this.http.get('http://localhost:8080/api/browse').
            map(response => response.json());
    }
}
