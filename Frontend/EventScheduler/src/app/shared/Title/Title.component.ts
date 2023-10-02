import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-Title',
  templateUrl: './Title.component.html',
  styleUrls: ['./Title.component.css']
})
export class TitleComponent implements OnInit {
  @Input() title = '';
  constructor() { }

  ngOnInit() {
  }

}
