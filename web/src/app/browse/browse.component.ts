import { BrowseService } from './browse.service';
import { Component, OnInit } from '@angular/core';
import { TreeNode } from 'primeng/primeng';

@Component({
    selector: 'app-browse',
    templateUrl: './browse.component.html',
    styleUrls: ['./browse.component.scss'],
    providers: [BrowseService]
})
export class BrowseComponent implements OnInit {

    data: Array<TreeNode>;
    constructor(private browseService: BrowseService) { }

    ngOnInit() {
        this.browseService.loadReportData().subscribe(data => { this.data = data } );
        console.log(this.data);
    }

}
