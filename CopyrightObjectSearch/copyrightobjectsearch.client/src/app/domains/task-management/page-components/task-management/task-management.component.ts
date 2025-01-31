import { Component, OnInit } from '@angular/core';
import { slideInOut } from '../../../../animations';

@Component({
  selector: 'app-task-management',
  templateUrl: './task-management.component.html',
  styleUrls: [
    './task-management.component.css',
    '../../../../app.component.css'
  ],
  animations: [slideInOut]
})
export class TaskManagementComponent implements OnInit {

  isNewTaskVisible: boolean = false;

  constructor(
  ) {
  }

  ngOnInit() {
  }

  onNewTask() {
    this.isNewTaskVisible = true;
  }

  onFinished() {
    this.isNewTaskVisible = false;
  }
}
