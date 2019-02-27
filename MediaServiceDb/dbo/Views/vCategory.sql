create view vCategory as
(select cast(5 as integer) as codei, 'Малі права' as name
union 
select cast(6 as integer) as codei, 'Великі права' as name
)