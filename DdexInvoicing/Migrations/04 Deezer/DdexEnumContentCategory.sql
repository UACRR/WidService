  if not exists (select null from DdexEnumContentCategory where codeI = 3)
  begin
	alter table DdexEnumContentCategory alter column codeName varchar(12);
	alter table DdexEnumContentCategory alter column name varchar(12);
	insert DdexEnumContentCategory values (3, 'GEPreCleared', 'GEPreCleared');
  end

