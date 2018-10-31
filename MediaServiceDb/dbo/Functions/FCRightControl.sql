--drop FUNCTION FCRightControl 
CREATE FUNCTION FCRightControl (@сRightId integer)
RETURNS varchar(3000)
    WITH EXECUTE AS CALLER 
    as
    BEGIN 
--Возвращает строку с сообщением об ошибке по сRightId (чтобы не > 100% на территории в один период)
--Вызывается при вводе % правообладания в Copytright
--Пример: сRightId=1 - "Превышает 100% прав на территории ...кроме ...."
    
    declare @Result varchar(3000) 
    declare @Id integer, @num integer
    declare @unless varchar(10) 

    set @unless = 'крім'
    set @Id = 0
	set @Result = ''

   Declare @TmpTab table 
            (continentCode integer ,
             countryCode char(3) not null primary key, 
             uCountryCode char(3), 
             rate decimal(6,2) )

 insert into @TmpTab ( countryCode, UCountryCode, rate )   
 select  l.countryCode,  l.countryCode, sum(c.rate)  as rate 
 from copyright c join vCopyrightCountry l on (c.cRightId = l.cRightId)
   where c.objid = (select objId from copyright c1 where c1.cRightId = @сRightId) 
      and c.kindGroupId = (select kindGroupId from copyright c2 where c2.cRightId = @сRightId) 
      and getdate() between isnull(begindate, '1900-01-01') and isnull(endDate, '3000-01-01')
 group by c.objid, c.kindGroupId, l.countryCode
 having sum(c.rate) > 100 


 if (select count(*) from @TmpTab where isnull(UCountryCode,0)>0) = 0  
   RETURN @Result

    Declare @TmpUse table 
            (id Integer not null identity primary key, 
             continentCode integer, 
             continentName varchar(100), 
             countryCode char(3),  
             countryName varchar(100), 
             Pr smallint )

    Declare @TmpEx table 
            (id integer not null identity primary key,  
             continentCode integer,  
             continentName varchar(100), 
             countryName varchar(100), 
             countryCode char(3) )

   Declare @TmpCont table
            (continentCode integer primary key, 
             fCnCount integer, 
             uCnCount integer) 

   update @tmpTab set continentCode = t2.continentCode 
     from @tmpTab t1 join country t2 on t1.countryCode = t2.countryCode

   insert into @tmpTab ( continentCode, countryCode, UCountryCode, rate )  
      select t1.continentCode, t1.countryCode, null, null 
      from country t1 where not exists 
         ( select 1 from @tmpTab t2 
             where t1.continentCode = t2.continentCode and t1.countryCode = t2.countryCode)
   
   insert into @TmpCont (continentCode, fCnCount, uCnCount)
     select continentCode, count(*), null  from country group by continentCode 
   
   update @TmpCont set uCnCount = 
         ( select count (*) 
           from @tmpTab t1 
           where  t0.continentCode = t1.continentCode and  isnull(ucountryCode,0) <> 0
           group by t1.continentCode )
       from @TmpCont t0  
     
  If  (select sum(fCnCount) from @TmpCont ) - 
      (select sum(uCnCount) from @TmpCont  where isnull(uCnCount,0) <> 0 )  
     < 10 

   begin 
   --весь мир
   insert into @TmpUse ( continentCode )
   select 2   

   insert into @TmpEx ( continentCode, countryCode )
   select 2, CountryCode 
      from @tmpTab 
     where isnull(uCountryCode,0) = 0
   end 

Else 

 begin 
 --По континентам
   insert into @TmpUse ( continentCode, countryCode, pr )
   --если больше половины стран - записываю континент
   select continentCode, NULL, 1 
      from @TmpCont 
     where isnull(uCnCount,0) <> 0 
           and uCnCount>=fCnCount/2  
     union 
   --если меньше половины стран - записываю страны
   select NULL, t2.countryCode, 0 
      from @TmpCont t1 
           join @tmpTab t2 on t1.continentCode = t2.continentCode
     where isnull(t2.uCountryCode,0) <> 0 
           and uCnCount<t1.fCnCount/2  
     order by 1,2

   --Если внесены континенты, где не все страны
   insert into @TmpEx ( continentCode, countryCode )
   select t1.continentCode, t1.countryCode 
      from @tmpTab t1
         join @TmpUse t2 on t1.continentCode = t2.continentCode 
     where isnull(uCountryCode,0) = 0 and isnull(t2.pr,0) = 1 
     order by 1
  end 

  update @tmpUse set continentName = t2.continentNameUk, 
                     countryname = t3.countryNameUk 
   from  @tmpUse t1  
     left join continent t2 on t1.continentCode = t2.continentCode 
     left join Country t3 on t1.countryCode = t3.countryCode 

  update @tmpEx set continentName = t2.continentNameUk, 
                     countryname = t3.countryNameUk  
   from  @tmpEx t1  
     left join continent t2 on t1.continentCode = t2.continentCode 
     left join Country t3 on t1.countryCode = t3.countryCode 

  
  declare @idUse integer, @idEx integer
  set @idUse =0 
  set @idEx =0 

--Вывести в одну строку собранное в таблицах @TmpUse, @TmpEx
    WHILE (SELECT isnull(min(id),0) FROM @TmpUse  where id > @idUse ) > 0 
    BEGIN
     set @idUse = (SELECT isnull(min(id),0) FROM @TmpUse  where id > @idUse )
     set @Result = @Result + ';'+ 
         ( select 
             (Case  When isnull(countryCode,0)<>0 
			        Then rtrim(isnull(countryName,'')) 
                    Else  rtrim(isnull(continentName,'')) end )
           from @TmpUse where id = @idUse ) 
       set @Result =  @Result+' '+ 
            (Case when (select count(*) 
                 from @tmpEx t1 
                     join @tmpUse t2  on isnull(t1.continentCode,0) = isnull(t2.continentCode,0)   
                     where t2.id = @idUse  ) <> 0 Then @unless+' '  Else '' End)
            
       WHILE (SELECT isnull(min(t1.id),0) 
               FROM @tmpEx t1 
                     join  @tmpUse t2  on isnull(t1.continentCode,0) = isnull(t2.continentCode,0)   
                     where t1.id > @idEx and t2.id = @idUse ) > 0 
      BEGIN
        set @idEx = (SELECT isnull(min(t1.id),0) 
                     from @TmpEx t1 
                     join  @TmpUse t2  on isnull(t1.continentCode,0) = isnull(t2.continentCode,0)   
                     where t1.id > @idEx and t2.id = @idUse )

        set @Result =  @Result + ',' +
        (select 
           ( Case When isnull(t1.CountryCode,0)<>0 
                Then rtrim(isnull(t1.countryName,''))  
                Else rtrim(isnull(t1.continentName,''))  end )
             from @TmpEx t1 where t1.id = @idEx )
       END

    END

   set @Result = replace (rtrim(ltrim(substring(@Result,2,3000))), ' ,' , ' ')

 RETURN @Result
END

--select dbo.FCRightControl(84)
/*
select *, dbo.FCRightControl(cRightId) from copyright 

select * from copyright where objid = 3
select * from LocationUse where cRightId = 84
select * from LocationExept where cRightId = 84
select * from Country where continentCode = 4
--insert into LocationExept (cRightId, countryCode) select 84, 643
*/