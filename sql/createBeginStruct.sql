
insert into ObjectRight(categoryCode,objType,name,author,performer,status,createDate)
values( 5, 1, 'объект 1', 'Іванов І.І.', 'Петров П.П.', 1, getdate())
insert into ObjectRight(categoryCode,objType,name,author,performer,status,createDate)
values( 5, 1, 'объект 2', 'Іванов І.І.', 'Петров П.П.', 1, getdate())
insert into ObjectRight(categoryCode,objType,name,author,performer,status,createDate)
values( 5, 1, 'объект 3', 'Іванов І.І.', 'Петров П.П.', 1, getdate())
insert into ObjectRight(categoryCode,objType,name,author,performer,status,createDate)
values( 5, 1, 'объект 4', 'Іванов І.І.', 'Петров П.П.', 1, getdate())

begin 
declare @custId int;
Insert into customer(custType, status, ankVersion)
values( 1, 2, 1 ) 
select @custId = cast( @@IDENTITY as int )   

select @custId;

insert into Person(custId, version) values( @custId, 1);

insert into AnketaPerson(
custId,[version],isCurrent,status,firstName,surName,lastName,nikName,sex,birthDate,phoneMobileMain,phoneMobileExtra,
phoneHome,eMail,citizenship,residency,reCountry,reAddress,inn)
values( @custId , 1, 1, 2, 'Віктор','Михайлович','Дем''янюк', 'Дема', 2, '1967-12-11', '+380506542233', '+380676542233', '+380446542233','RightHolder03@ukr.net'
, null, 1, '804', 'м.Київ Оболонський проспект Б. 7А кв. 90', '11223344' )

end

                                                           begin 
declare @custId int;
Insert into customer(custType, status, ankVersion)
values( 3, 2, 1 ) 
select @custId = cast( @@IDENTITY as int )   

select @custId;

insert into Company(custId, version) values( @custId, 1);

insert into AnketaCompany(
custId,version,activityCode,isCurrent,status,name,shortName,faAddress,jaAddress,okpo,registrDate,
typeVAT,numberVAT,jaCity,faCity,jaCountry,faCountry,jaRegion,faRegion)
values( @custId , 1, 4546, 1, 2,'Дрім Тоун','ДрімТоун', 'м. Київ Оболонський проспект 1', 'м. Київ Оболонський проспект 1', '09876543', '2001-02-01', 1
,'000111222-0099', 'Київ', 'Київ', '804', '804', null, null)

end
