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

export class SearchConditionDto {
  searchField         : SearchFieldEnum  = SearchFieldEnum.name   ;
  searchMethod        : SearchMethodEnum = SearchMethodEnum.exact ;
  value               : string           = ''                     ;
}

export class SearchParamsDto {
  searchConditions: SearchConditionDto[] = [];
}

