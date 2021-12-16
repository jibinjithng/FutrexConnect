import { Component, Input, OnInit, AfterViewInit } from '@angular/core';

@Component({
  selector: 'app-status-indicator',
  templateUrl: './status-indicator.component.html',
  styleUrls: ['./status-indicator.component.css'],
})
export class StatusIndicatorComponent implements OnInit {
  @Input()
  status: string;
  statusIndicatorCssCass: string;
  constructor() {}

  ngOnInit() {
    switch (this.status) {
      case 'Active':
        this.statusIndicatorCssCass = 'status-indicator bg-success text-white';
        break;
      case 'Inactive':
        this.statusIndicatorCssCass = 'status-indicator bg-danger text-white';
        break;
      default:
        this.statusIndicatorCssCass = 'status-indicator';
        break;
    }
  }
}
