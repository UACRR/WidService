import { Type } from '@angular/compiler';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { slideInOut } from '../../../../animations';

enum UserTaskTypeEnum {
  SeachSocWork          = 1,
  SearchPartnerWork     = 2,
  SearchRightHolderWork = 3,
}

@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.css',
    '../../../../app.component.css'
  ],
  animations: [slideInOut]
})
export class EditTaskComponent implements OnInit {

  @Output() finished = new EventEmitter();

  taskTypeCheckFormControls: FormControl[] = [
    new FormControl(false),
    new FormControl(false),
    new FormControl(false),
  ];

  errorText = '';

  isUpdateInProgress = false;

  constructor(
    private http: HttpClient
  ) {
    this.http = http;
  }

  ngOnInit() {
    setTimeout(() => {
      this.taskTypeCheckFormControls[1].setValue(true);
    }, 0);
  }

  onCreateTaskFinished() {
    this.taskTypeCheckFormControls[1].setValue(false);
    this.finished.emit();
  }

  onTaskTypeCheckClicked(idx: number) {
    var curIdx = 0;
    this.taskTypeCheckFormControls.forEach(x => {
      x.setValue(curIdx === idx);
      curIdx++;
    });
  }

  getReportText(): string {
    return '<не вибраний>';
  }

  isSeachSocWork(): boolean {
    return this.taskTypeCheckFormControls[0].value;
  }

  isSearchPartnerWork(): boolean {
    return this.taskTypeCheckFormControls[1].value;
  }

  isSearchRightHolderWork(): boolean {
    return this.taskTypeCheckFormControls[2].value;
  }
}
