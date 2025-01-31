class SourceTypeDto {
  sourceTypeId   : number = 0 ;
  sourceTypeName : string = '';
}

class PartnerDto {
  partnerId   : number = 0 ;
  partnerName : string = '';
  sourceTypes : SourceTypeDto[] = [];
}

export class GetPartnerWorkFilterInfoRsp {
  partners: PartnerDto[] = [];
  minYear : number = 0;
  maxYear : number = 0;
}
