create view vEtGenreRate as 
(
select t1.genreCode, max(t2.name) as genreName, 
sum((Case When t1.actCode = 1 Then t1.rate Else 0 end)) as act1_Rate, 
sum((Case When t1.actCode = 2 Then t1.rate Else 0 end)) as act2_Rate, 
sum((Case When t1.actCode = 3 Then t1.rate Else 0 end)) as act3_Rate
 from EtGenreRate t1 
 join EtGenre t2 on t2.CodeI = t1.genreCode 
 group by t1.genreCode
)