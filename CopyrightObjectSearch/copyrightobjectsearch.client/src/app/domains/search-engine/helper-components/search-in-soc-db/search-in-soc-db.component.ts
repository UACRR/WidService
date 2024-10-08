import { HttpClient } from '@angular/common/http';
import { Type } from '@angular/compiler';
import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { SearchConditionDto, SearchParamsDto } from '../../server-proxy/dto/search-params-rq';
import { map, catchError, Observable, of } from 'rxjs';
import { FoundNameAuthorsPerformers } from '../../server-proxy/dto/found-object-dto';
import { GetFoundObjectsRsp } from '../../server-proxy/dto/GetFoundObjectsRsp';
import { SetWorkCodeRq } from '../../server-proxy/dto/SetWorkCodeRq';
import { SetWorkCodeRsp } from '../../server-proxy/dto/SetWorkCodeRsp';

enum SearchFieldEnum
{
    name,
    authors,
    performers,
}

enum SearchMethodEnum
{
    none          = -1,
    exact         =  0,
    containsWord  =  1,
    contains      =  2,
    startsWith    =  3,
    pattern       =  4,
}

class SearchCondition {
  title               : string           = ''                     ;
  searchField         : SearchFieldEnum  = SearchFieldEnum.name   ;
  searchMethod        : SearchMethodEnum = SearchMethodEnum.exact ;
  value               : string           = ''                     ;

  valueFrmControl: FormControl = new FormControl('');
  chkFrmControls : FormControl[] = [];
}

class FoundItem {
  foundCde      : number = 0 ;
  foundIn       : string = '';
  name          : string = '';
  authors       : string = '';
  performers    : string = '';

  nameHtml      : string = '';
  authorsHtml   : string = '';
  performersHtml: string = '';
}

@Component({
  selector: 'app-search-in-soc-db',
  templateUrl: './search-in-soc-db.component.html',
  styleUrls: ['./search-in-soc-db.component.css',
    '../../../../app.component.css'
  ]
})
export class SearchInSocDbComponent implements OnInit {
  @Input() inputExternalObjectId = 0;
  @Input() inputName = '';
  @Input() inputAuthors = '';
  @Input() inputPerformers = '';

  @Output() objectSelected = new EventEmitter();

  searchInFoundFormControl = new FormControl();

  searchConditions: SearchCondition[] = [
    {
      title               : 'Назва',
      searchField         : SearchFieldEnum.name,
      searchMethod        : SearchMethodEnum.exact,
      value               : '',

      valueFrmControl: new FormControl(''),
      chkFrmControls : [
        new FormControl(true),
        new FormControl(false),
        new FormControl(false),
        new FormControl(false),
        new FormControl(false),
      ],
    },
    {
      title               : 'Автори',
      searchField         : SearchFieldEnum.authors,
      searchMethod        : SearchMethodEnum.none,
      value               : '',

      valueFrmControl: new FormControl(''),
      chkFrmControls: [
        new FormControl(false),
        new FormControl(false),
        new FormControl(false),
        new FormControl(false),
        new FormControl(false),
      ],
    },
    {
      title               : 'Виконавці',
      searchField         : SearchFieldEnum.performers,
      searchMethod        : SearchMethodEnum.none,
      value               : '',

      valueFrmControl: new FormControl(''),
      chkFrmControls: [
        new FormControl(false),
        new FormControl(false),
        new FormControl(false),
        new FormControl(false),
        new FormControl(false),
      ],
    },
  ];

  foundItems: FoundItem[] = [];

  searchErrorText = '';

  // state
  isSearchInProgressSmart = false;
  isSearchInProgressWid = false;

  constructor (
    private http: HttpClient,
    private sanitizer: DomSanitizer
  ) {
  }

  ngOnInit() {
    this.searchConditions[SearchFieldEnum.name].valueFrmControl.setValue(this.inputName);
    this.searchConditions[SearchFieldEnum.authors].valueFrmControl.setValue(this.inputAuthors);
    this.searchConditions[SearchFieldEnum.performers].valueFrmControl.setValue(this.inputPerformers);
  }

  isFoundItemVisible(foundItem: FoundItem): boolean {
    const searchText: string = this.searchInFoundFormControl.value;
    return !searchText                                                        ||
           searchText.trim()             === ''                               ||
           foundItem.foundCde.toString() === searchText                       ||
           foundItem.name.length        !== foundItem.nameHtml.length         ||
           foundItem.authors.length     !== foundItem.authorsHtml.length      ||
           foundItem.performers.length  !== foundItem.performersHtml.length;
  }

  onSearchInSmartClicked() {
    alert('Не реалізовано');
  }

  onSearchInWidClicked() {
    if (!this.isSearchConditionSelected()) {
      this.searchErrorText = 'Не вибрано жодної умови для пошуку твору';
      return;
    }

    this.searchErrorText = '';
    this.isSearchInProgressWid = true;
    this.foundItems = [];
    this.searchInFoundFormControl.setValue('');

    const rq: SearchParamsDto = new SearchParamsDto();
    this.searchConditions.forEach(x => {
      rq.searchConditions.push({
        searchField  : x.searchField,
        searchMethod : x.searchMethod,
        value        : x.valueFrmControl.value,
      });
    });
    this.http.post<GetFoundObjectsRsp>('http://localhost:5235/api/SearchEngine/GetFoundObjects', rq)
      .subscribe({
        next: response => {
          this.foundItems = [];
          response.foundNameAuthorsPerformers.forEach(x => {
            this.foundItems.push({
              foundCde    :   x.foundCde,
              foundIn     :   x.foundIn,
              name        :   x.name,
              authors     :   x.authors,
              performers  :   x.performers,
              nameHtml    :   x.name,
              authorsHtml :   x.authors,
              performersHtml: x.performers,
            });
          });
          this.searchErrorText = response.errorText;
          this.isSearchInProgressWid = false;
         },
        error: error => {
          this.isSearchInProgressWid = false;
          this.searchErrorText = error.error;;
        }
      });
  }

  onSearchInFoundWorksClicked() {
    const searchText: string = this.searchInFoundFormControl.value;
    if (!searchText || searchText.trim() === '') {
       this.foundItems.forEach(x => {
        x.nameHtml        = x.name      ;
        x.authorsHtml     = x.authors   ;
        x.performersHtml  = x.performers;
      });
    }
    else {
      this.foundItems.forEach(x => {
        x.nameHtml        = this.buildTextSerchResultHtml(x.name        , searchText);
        x.authorsHtml     = this.buildTextSerchResultHtml(x.authors     , searchText);
        x.performersHtml  = this.buildTextSerchResultHtml(x.performers  , searchText);
      });
    }
    
  }

  onSelectWorkClicked(foundItem: FoundItem) {
    const rq: SetWorkCodeRq = {
      workCode: this.getFoundItemCodeText(foundItem),
      externalObjectId: this.inputExternalObjectId,
    };
    this.http.post<SetWorkCodeRsp>('http://localhost:5235/api/SearchEngine/SetWorkCode', rq)
      .subscribe({
        next: response => {
          this.objectSelected.emit({
            externalObjectId: response.externalObjectId,
            objId: response.objId,
            wic: response.wic,
            iswc: response.iswc
          });
        },
        error: error => {
          this.searchErrorText = error.error;
        }
      });
  }

  setSearchMethodFromChecks(searchCondition: SearchCondition) {
    searchCondition.searchMethod = SearchMethodEnum.none;
    for (var idx = 0; idx < searchCondition.chkFrmControls.length; idx++) {
      const chkCtrl = searchCondition.chkFrmControls[idx];
      if (chkCtrl.value) {
        searchCondition.searchMethod = idx;
        break;
      }
    }
  }

  onSrchCondMethClicked(searchCondition: SearchCondition, searchMethod: SearchMethodEnum) {
    const newChkValue = !searchCondition.chkFrmControls[searchMethod].value;
    setTimeout(() => {
      searchCondition.chkFrmControls.forEach(x => x.setValue(false));
      searchCondition.chkFrmControls[searchMethod].setValue(newChkValue);
//      if (searchCondition.searchField === SearchFieldEnum.name && !newChkValue) {
//        searchCondition.chkFrmControls[0].setValue(true);
//      }
      this.setSearchMethodFromChecks(searchCondition);
    }, 0);
  }

  onHideSearchError() {
    this.searchErrorText = '';
  }

  getFoundItemCodeText(foundItem: FoundItem): string {
    return `${foundItem.foundIn}-${foundItem.foundCde}`;
  }

  getNameHtml(foundItem: FoundItem): SafeHtml {
    return this.sanitizer.bypassSecurityTrustHtml(foundItem.nameHtml);
  }

  getAuthorsHtml(foundItem: FoundItem): SafeHtml {
    return this.sanitizer.bypassSecurityTrustHtml(foundItem.authorsHtml);
  }

  getPerformersHtml(foundItem: FoundItem): SafeHtml {
    return this.sanitizer.bypassSecurityTrustHtml(foundItem.performers);
  }

  getFoundTextStyle(): SafeHtml {
    return this.sanitizer.bypassSecurityTrustStyle('found-text');
  }

  buildTextSerchResultHtml(sourceText: string, searchText: string): string {
    const replacementText = `<strong>[${searchText.toUpperCase()}]</strong>`;
    var retVal = sourceText.replace(new RegExp(searchText, 'gi'), replacementText);
    return retVal;
  }

  isSearchInProgress(): boolean {
    return this.isSearchInProgressSmart || this.isSearchInProgressWid;
  }

  isSearchInProgressSpinnerVisibleSmart(): boolean {
    return this.isSearchInProgressSmart;
  }

  isSearchInProgressSpinnerVisibleWid(): boolean {
    return this.isSearchInProgressWid;
  }

  isSearchInProgressDivVisible(): boolean {
    return this.isSearchInProgress();
  }

  isNotFoundDivVisible(): boolean {
    return !this.isSearchInProgress() && this.foundItems.length === 0;
  }

  isNotSelectedDivVisible(): boolean {
    var hasVisible = false;
    this.foundItems.forEach(x => {
      if (this.isFoundItemVisible(x)) {
        hasVisible = true;
      };
    });
    return !this.isSearchInProgress() && this.foundItems.length !== 0 && !hasVisible;
  }

  isSearchConditionSelected(): boolean {
    var retVal = false;
    this.searchConditions.forEach(x => {
      if (x.searchMethod != SearchMethodEnum.none) {
        retVal = true;
      }
    });
    return retVal;
  }

  isErrorVisible(): boolean {
    return this.searchErrorText !== '';
  }
}
