
class UserDto {
  id      : number   = 0 ;
  name    : string   = '';
  login   : string   = '';
  roleIds : number[] = [];
}

export class GetUsersRsp {
  users: UserDto[] = [];
}

