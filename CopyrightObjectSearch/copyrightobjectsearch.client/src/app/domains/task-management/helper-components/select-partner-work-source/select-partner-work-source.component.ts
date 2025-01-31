import { Type } from '@angular/compiler';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { GetPartnerWorkSourcesRq } from '../../server-proxy/dto/GetPartnerWorkSourcesRq';
import { GetPartnerWorkSourcesRsp } from '../../server-proxy/dto/GetPartnerWorkSourcesRsp';
import { GetPartnerWorkFilterInfoRsp } from '../../server-proxy/dto/GetPartnerWorkFilterInfoRsp';
import { GetPlannedTaskNameRq } from '../../server-proxy/dto/GetPlannedTaskNameRq';
import { GetPlannedTaskNameRsp } from '../../server-proxy/dto/GetPlannedTaskNameRsp';

class FilterSourceTypeItem {
  sourceTypeId   : number = 0 ;
  sourceTypeName : string = '';
}

class FilterPartnerItem {
  partnerId   : number = 0 ;
  partnerName : string = '';
  sourceTypes : FilterSourceTypeItem[] = [];
}

 class FilterInfoItem {
  partners: FilterPartnerItem[] = [];
  minYear : number = 0;
  maxYear : number = 0;
}
class Item {
  partnerWorkSourceId : number = 0 ;
  title               : string = '';
  partnerId           : number = 0 ;
  partnerName         : string = '';
  sourceId            : number = 0 ;
  sourceTypeId        : number = 0 ;
  sourceTypeName      : string = '';
  year                : number = 0 ;
  month               : number = 0 ;
  quarter             : number = 0 ;
}

@Component({
  selector: 'app-select-partner-work-source',
  templateUrl: './select-partner-work-source.component.html',
  styleUrls: ['./select-partner-work-source.component.css',
    '../../../../app.component.css'
  ]
})
export class SelectPartnerWorkSourceComponent implements OnInit {

  @Output() finished = new EventEmitter();

  items: Item[] = [];

  filterInfoItem: FilterInfoItem = new FilterInfoItem;

  formControlFilterPartner    = new FormControl<number>(0);
  formControlFilterSourceType = new FormControl<number>(0);
  formControlFilterYear       = new FormControl<number>(0);
  formControlFilterMonth      = new FormControl<number>(0);

  valueFormControl = new FormControl('');
  noValueChkFormControl = new FormControl(false);

  errorText = '';
  taskName = '';

  isUpdateInProgress = false;

  constructor(
    private http: HttpClient
  ) {
    this.http = http;
  }

  ngOnInit() {
    this.getPartnerWorkFilterInfo();
  }

  // ------- EVENT HANDLERS
  onSelectClicked(item: Item) {
    this.getPlannedTaskName(item);
  }

  onApply() {
    this.finished.emit();
  }

  onCancel() {
     this.finished.emit();
  }

  onHideError() {
    this.errorText = '';
  }

  onNoValueChkClicked() {
    this.valueFormControl.setValue('');
  }

  onFilterchanged() {
    this.taskName = '';
    this.getPartnerWorkSources();
  }

  // ------- GETTERS
  getPartnerWorkFilterInfo() {
    this.errorText = '';
    this.http.get<GetPartnerWorkFilterInfoRsp>('http://localhost:5235/api/TaskAdministration/GetPartnerWorkFilterInfo')
      .subscribe({

        next: response => {
          this.filterInfoItem = new FilterInfoItem();
          var partners: FilterPartnerItem[] = [];

          response.partners.forEach(x => {
            var sourceTypes: FilterSourceTypeItem[] = [];
            x.sourceTypes.forEach(y => {
              sourceTypes.push({
                sourceTypeId: y.sourceTypeId,
                sourceTypeName: y.sourceTypeName,
              });
            });
            partners.push({
              partnerId: x.partnerId,
              partnerName: x.partnerName,
              sourceTypes: sourceTypes,
            });
          });

          this.filterInfoItem = {
            partners: partners,
            minYear: response.minYear,
            maxYear: response.maxYear,
          }

          this.formControlFilterPartner.setValue(partners[0].partnerId);
          this.formControlFilterSourceType.setValue(this.filterInfoItem.partners[0].sourceTypes[0].sourceTypeId);
          this.formControlFilterYear.setValue(this.filterInfoItem.minYear);
          this.formControlFilterMonth.setValue(1);

          this.formControlFilterPartner.valueChanges.subscribe(value => {
            var partnerId = value == null ? 0 : value;
            var partner = this.filterInfoItem.partners.find(x => x.partnerId == partnerId);
            if (partner) {
              this.formControlFilterSourceType.setValue(partner.sourceTypes[0].sourceTypeId);
            }
            this.onFilterchanged();
            }
          );
          this.formControlFilterSourceType.valueChanges.subscribe(value => this.onFilterchanged());
          this.formControlFilterYear.valueChanges.subscribe(value => this.onFilterchanged());
          this.formControlFilterMonth.valueChanges.subscribe(value => this.onFilterchanged());

          this.getPartnerWorkSources();
        },
        error: error => {

          this.errorText = error.message;

        }
      });
    // this.appService.userId = 1;
    // this.router.navigateByUrl('domains/user-administration/page-components/user-administration');

  }

  getPartnerWorkSources() {
    this.errorText = '';
    const rq: GetPartnerWorkSourcesRq = {
      partnerId   : this.formControlFilterPartner.value == null ? 0 : this.formControlFilterPartner.value,
      sourceTypeId: this.formControlFilterSourceType.value == null ? 0 : this.formControlFilterSourceType.value,
      year        : this.formControlFilterYear.value == null ? 0 : this.formControlFilterYear.value,
      month       : this.formControlFilterMonth.value == null ? 0 : this.formControlFilterMonth.value,
      quarter     : 0           ,
    };
    this.http.post<GetPartnerWorkSourcesRsp[]>('http://localhost:5235/api/TaskAdministration/GetPartnerWorkSources', rq)
      .subscribe({

        next: response => {
          this.items = [];
          response.forEach(x => {
            this.items.push(
              {
                  partnerWorkSourceId : x.partnerWorkSourceId,
                  title               : x.title              ,
                  partnerId           : x.partnerId          ,
                  partnerName         : x.partnerName        ,
                  sourceId            : x.sourceId           ,
                  sourceTypeId        : x.sourceTypeId       ,
                  sourceTypeName      : x.sourceTypeName     ,
                  year                : x.year               ,
                  month               : x.month              ,
                  quarter             : x.quarter            ,
              }
            )
          });
          
        },
        error: error => {

          this.errorText = error.message;

        }
      });
    // this.appService.userId = 1;
    // this.router.navigateByUrl('domains/user-administration/page-components/user-administration');

  }

  getPlannedTaskName(item: Item) {
    this.errorText = '';
    const rq: GetPlannedTaskNameRq = {
      partnerWorkSourceId: item.partnerWorkSourceId,
    };
    this.http.post<GetPlannedTaskNameRsp>('http://localhost:5235/api/TaskAdministration/GetPlannedTaskName', rq)
      .subscribe({

        next: response => {
          this.taskName = response.taskTitle
        },
        error: error => {
          this.errorText = error.message;
        }
      });
   }

  getFilterSourceTypes(): FilterSourceTypeItem[] {
    var retVal: FilterSourceTypeItem[] = [];
    var partnerId = this.formControlFilterPartner.value;
    var filterPartner = this.filterInfoItem.partners.find(x => x.partnerId == partnerId);
    if (filterPartner) {
      filterPartner.sourceTypes.forEach(x => {
        retVal.push(x);
      });
    }
    return retVal;
  }

  getFilterYears(): string[] {
    var retVal: string[] = [];
    for (var year = this.filterInfoItem.minYear; year <= this.filterInfoItem.maxYear; year++) {
      retVal.push(year.toString());
    }
    return retVal;
  }

  getFilterMonths(): string[] {
    var retVal: string[] = [];
    for (var month = 1; month <= 12; month++) {
      retVal.push(month.toString());
    }
    return retVal;
  }

  getErrorText(): string {
    return this.errorText;
  }

  getPromptText(): string {
    return 'Виберіть звіт';
  }

  getNoValueText(): string {
    return 'Або поставне відмітку, що код невідомий';
  }

  getWarningText(): string {
    return `Для вибраного звіту заплановане завдання ${this.taskName}. Щоб створити завдання натисніть Застосувати.`;
  }

  getActionApplyText(): string {
    return 'Застосувати';
  }

  getActionCancelText(): string {
    return 'Відмінити';
  }

  // ------- CHECKERS
  isErrorVisible(): boolean {
    return this.errorText !== '';
  }

  isValueInputEnabled(): boolean {
    return this.noValueChkFormControl.value === false;
  }

  isWarningTextVisible(): boolean {
    return this.taskName !== '';
  }

  isApplyVisible(): boolean {
    return this.taskName !== '';
  }

  // ------- OTHER
  formatWorkCodeInRq(): string {
    return this.valueFormControl.value ? this.valueFormControl.value : ''
  }

  

}
