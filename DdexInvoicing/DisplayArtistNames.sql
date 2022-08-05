select * from WrkDisplayArtistNames order by DisplayArtistName

select max(len(performers)) from wObject-- order by performers
select * from wObject t1 cross apply string_split(t1.performers, ',') where len(t1.performers) = 9738

select * from wObject where performers like '%Paul Mauriat%'