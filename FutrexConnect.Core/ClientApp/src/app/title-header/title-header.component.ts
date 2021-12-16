import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-title-header',
  templateUrl: './title-header.component.html',
  styleUrls: ['./title-header.component.css'],
})
export class TitleHeaderComponent implements OnInit {
  public title: string;
  constructor() {
    this.title = 'Customers';
  }

  ngOnInit(): void {}
}
