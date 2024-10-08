import { Type } from '@angular/compiler';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { SetWorkCodeRq } from '../../server-proxy/dto/SetWorkCodeRq';
import { HttpClient } from '@angular/common/http';
import { SetWorkCodeRsp } from '../../server-proxy/dto/SetWorkCodeRsp';
import { CodeEditBaseComponent } from '../code-edit-base/code-edit-base.component';

@Component({
  selector: 'app-iswc-edit',
  templateUrl: '../code-edit-base/code-edit-base.component.html',
  styleUrls: ['../code-edit-base/code-edit-base.component.css',
    '../../../../app.component.css'
  ]
})
export class IswcEditComponent  extends CodeEditBaseComponent {
  constructor(
    http: HttpClient
  ) {
      super(http);
  }

  // ------- OVERRIDABLES

  override getPromptText(): string {
    return 'Введіть код ISWC';
  }

  override getNoValueText(): string {
    return 'Або поставне відмітку, що код невідомий';
  }

  override getWarningText(): string {
    return 'Зміна коду ISWC призведе до зміни кодів SMART і WID';
  }

  override getActionApplyText(): string {
    return 'Застосувати';
  }

  override getActionCancelText(): string {
    return 'Відмінити';
  }

  override formatWorkCodeInRq(): string {
    return this.valueFormControl.value ? this.valueFormControl.value : ''
  }

  override isValidValue(): boolean {
    var value: string = this.valueFormControl.value ? this.valueFormControl.value : '';

    // replace 3 dashed (function replace() changes just the first occurance)
    value = value.replace('-', '');
    value = value.replace('-', '');
    value = value.replace('-', '');
    if (value.charAt(0) !== 'T') {
      return false;
    }
    else if (value.length < 11) {
      return false;
    }
    else {
      for (var idx = 1; idx < value.length; idx++) {
        var c = value.charAt(idx);
        if (c < '0' || c > '9') {
          return false;
        }
      }
    }

    return true;
  }

}
