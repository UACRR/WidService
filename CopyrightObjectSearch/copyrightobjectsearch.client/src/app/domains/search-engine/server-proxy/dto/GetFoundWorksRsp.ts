export class FoundNameAuthorsPerformers {
  foundCde: number = 0;
  foundIn: string = '';
  name: string = '';
  authors: string = '';
  performers: string = '';
}
export class GetFoundWorksRsp {
  foundNameAuthorsPerformers: FoundNameAuthorsPerformers[] = [];
  errorText: string = '';
}

