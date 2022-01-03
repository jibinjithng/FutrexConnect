import { Component, Input, OnInit } from '@angular/core';
import { IBreadcrumbData } from '../../models/navigation-models';

@Component({
  selector: 'app-breadcrumb',
  templateUrl: './breadcrumb.component.html',
  styleUrls: ['./breadcrumb.component.css'],
})
export class BreadcrumbComponent implements OnInit {
  @Input()
  breadcrumbData: IBreadcrumbData[];

  constructor() {}

  ngOnInit(): void {}
}
