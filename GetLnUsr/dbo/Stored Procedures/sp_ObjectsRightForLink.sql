
CREATE PROCEDURE [dbo].[sp_ObjectsRightForLink] @query varchar(1024), @offset int, @fetch int, @count int output
AS
BEGIN
-- видалити якщо існує
IF OBJECT_ID('tempdb..#temp_ObjectsRightForLink') IS NOT NULL DROP TABLE #temp_ObjectsRightForLink

-- таблиця:
IF OBJECT_ID('tempdb..#temp_ObjectsRightForLink') IS NULL
create table #temp_ObjectsRightForLink (
WIC int,
iswc varchar(16),
name varchar(256),
author varchar(512),
performer varchar(512),
genrename varchar(16),
rateTotalMec numeric(5,2),
rateTotalPER numeric(5,2),
)

-- вставка результату обробки
IF OBJECT_ID('tempdb..#temp_ObjectsRightForLink') IS NOT NULL
insert into #temp_ObjectsRightForLink exec (@query)

-- значення для вихідного параметра
select @count = count(*) from #temp_ObjectsRightForLink

-- виведення результату
select * from #temp_ObjectsRightForLink
order by WIC OFFSET @offset ROWS FETCH NEXT @fetch ROWS ONLY
END
