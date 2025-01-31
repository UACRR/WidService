import { Type } from '@angular/compiler';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { SetWorkCodeRq } from '../../server-proxy/dto/SetWorkCodeRq';
import { HttpClient } from '@angular/common/http';
import { SetWorkCodeRsp } from '../../server-proxy/dto/SetWorkCodeRsp';

@Component({
  selector: 'app-code-edit-base',
  templateUrl: './code-edit-base.component.html',
  styleUrls: ['./code-edit-base.component.css',
    '../../../../app.component.css'
  ]
})
export class CodeEditBaseComponent implements OnInit {
  @Input() inputPartnerWorkId = 0;
  @Input() inputIswc = '';

  @Output() finished = new EventEmitter();

  valueFormControl = new FormControl('');
  noValueChkFormControl = new FormControl(false);

  errorText = '';

  isUpdateInProgress = false;

  constructor(
    private http: HttpClient
  ) {
    this.http = http;
  }

  ngOnInit() {
    this.valueFormControl.setValue(this.inputIswc);
  }

  // ------- EVENT HANDLERS
  onApply() {
    if (this.noValueChkFormControl.value === false) {
      if (!this.isValidValue()) {
        this.errorText = 'Невірний формат коду';
        return;
      }
    }
    this.sendSetWorkCodeRq();
  }

  onCancel() {
     this.finished.emit(
      {
        isCanceled: true,
        objId: 0,
        wic: 0,
        iswc: ''
      }
    );
  }

  onHideError() {
    this.errorText = '';
  }

  onNoValueChkClicked() {
    this.valueFormControl.setValue('');
  }

  // ------- IMPLEMENTATION

  sendSetWorkCodeRq() {
    this.isUpdateInProgress = true;
    this.errorText = '';
    const rq: SetWorkCodeRq = {
      workCode: this.formatWorkCodeInRq(),
      partnerWorkId: this.inputPartnerWorkId,
    };
    this.http.post<SetWorkCodeRsp>('http://localhost:5235/api/SearchEngine/SetWorkCode', rq)
      .subscribe({
        next: response => {
          this.isUpdateInProgress = false;
          if (response.errorText === '') {
            this.finished.emit({
              isCanceled: false,
              partnerWorkId: response.partnerWorkId,
              objId: response.objId,
              wic: response.wic,
              iswc: response.iswc
            });
          }
          else {
            this.errorText = response.errorText;
            this.isUpdateInProgress = false;
          };
        },
        error: error => {
        }
      });
  }

  getErrorText(): string {
    return this.errorText;
  }

  isErrorVisible(): boolean {
    return this.errorText !== '';
  }

  isValueInputEnabled(): boolean {
    return this.noValueChkFormControl.value === false;
  }

  // ------- OVERRIDABLES

  getPromptText(): string {
    return 'Введіть код';
  }

  getNoValueText(): string {
    return 'Або поставне відмітку, що код невідомий';
  }

  getWarningText(): string {
    return 'Зміна коду призведе до зміни кодів';
  }

  getActionApplyText(): string {
    return 'Застосувати';
  }

  getActionCancelText(): string {
    return 'Відмінити';
  }

  formatWorkCodeInRq(): string {
    return this.valueFormControl.value ? this.valueFormControl.value : ''
  }

  isValidValue(): boolean {
    return true;
  }

}
