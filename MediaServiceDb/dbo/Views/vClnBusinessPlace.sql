create view vClnBusinessPlace as 
select t4.name as clnName, t2.name as placeTypeName, t1.placeName, t1.placeCity, t1.placeAddress, t1.placePhone 
 from clnBusinessPlace t1 
  join typePlace t2 on t2.codeI = t1.plCode
  join vcustomer t4 on t4.custId = t1.custId