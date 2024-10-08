import { AutoMap, classes } from '@automapper/classes';
export class ExternalObjectDto {
  id        : number = 0;
  title     : string = '';
  authors   : string = '';
  performers: string = '';
  iswc      : string = '';
  foundObjId: number = 0;
  foundWic  : number = 0;
  foundIswc : string = '';
  foundVia  : string = '';
  createdAt : Date   = new Date();
  updatedAt : Date   = new Date();
}

