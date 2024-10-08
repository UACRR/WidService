import { Type } from '@angular/compiler';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { SetWorkCodeRq } from '../../server-proxy/dto/SetWorkCodeRq';
import { HttpClient } from '@angular/common/http';
import { SetWorkCodeRsp } from '../../server-proxy/dto/SetWorkCodeRsp';
import { CodeEditBaseComponent } from '../code-edit-base/code-edit-base.component';

@Component({
  selector: 'app-wic-edit',
  templateUrl: '../code-edit-base/code-edit-base.component.html',
  styleUrls: ['../code-edit-base/code-edit-base.component.css',
    '../../../../app.component.css'
  ]
})
export class WicEditComponent  extends CodeEditBaseComponent {
  constructor(
    http: HttpClient
  ) {
      super(http);
  }

  // ------- OVERRIDABLES

  override getPromptText(): string {
    return 'Введіть код WIC';
  }

  override getNoValueText(): string {
    return 'Або поставне відмітку, що код невідомий';
  }

  override getWarningText(): string {
    return 'Зміна коду WIC призведе до зміни кодів SMART і ISWC';
  }

  override getActionApplyText(): string {
    return 'Застосувати';
  }

  override getActionCancelText(): string {
    return 'Відмінити';
  }

  override formatWorkCodeInRq(): string {
    var value: string = this.valueFormControl.value ? this.valueFormControl.value : '0';
    return `W-${value}`;
  }

  override isValidValue(): boolean {
    if (this.noValueChkFormControl.value) {
      return true;
    }

    var value: string = this.valueFormControl.value ? this.valueFormControl.value.trim() : '';

    if (value === '') {
      return false;
    }

    for (var idx = 1; idx < value.length; idx++) {
        var c = value.charAt(idx);
        if (c < '0' || c > '9') {
          return false;
        }
      }

    return true;
  }

}
