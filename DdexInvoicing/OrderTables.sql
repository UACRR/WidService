with Fkeys as (

    select distinct

         OnTable       = OnTable.name
        ,AgainstTable  = AgainstTable.name 

    from 

        sysforeignkeys fk

        inner join sysobjects onTable 
            on fk.fkeyid = onTable.id

        inner join sysobjects againstTable  
            on fk.rkeyid = againstTable.id

    where 1=1
        AND AgainstTable.TYPE = 'U'
        AND OnTable.TYPE = 'U'
        -- ignore self joins; they cause an infinite recursion
        and OnTable.Name <> AgainstTable.Name
    )

,MyData as (

    select 
         OnTable = o.name
        ,AgainstTable = FKeys.againstTable

    from 

        sys.objects o

        left join FKeys
            on  o.name = FKeys.onTable

    where 1=1
        and o.type = 'U'
        and o.name not like 'sys%'
    )

,MyRecursion as (

    -- base case
    select 
         TableName    = OnTable
        ,Lvl        = 1
    from
        MyData
    where 1=1
        and AgainstTable is null

    -- recursive case
    union all select
         TableName    = OnTable
        ,Lvl        = r.Lvl + 1
    from 
        MyData d
        inner join MyRecursion r
            on d.AgainstTable = r.TableName
)
select 
     Lvl = max(Lvl)
    ,TableName
    ,strSql = 'delete from [' + tablename + ']'
from 
    MyRecursion
group by
    TableName
order by 
     1 desc
    ,2 desc