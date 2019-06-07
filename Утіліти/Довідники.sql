select CONCAT( 'baseEng.Add("', LOWER( dicName ),'".ToLower(),
                new BaseDictionaryEng<', dicName,',', dicName,'Tr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                sors => (DictBaseTypeI)sors, 
				sors => (', dicName,')sors, 
                sors => sors.',dicName,'Tr.ToList(),
                (sors, dest) => ((',dicName,'Tr)sors).CodeI == ((',dicName,'Tr)dest).CodeI && ((',dicName,'Tr)sors).Lang == ((',dicName,'Tr)dest).Lang,
                rec => rec.',dicName,'Tr)
            );')

from DicCategoryItems where dicType = 'i'

select CONCAT('"', dicName,'","',dicName, 'Tr",')
from DicCategoryItems where dicType = 'i'


select * from Form1

select concat(
'public static implicit operator ',dicName,'(DictBaseTypeI test)
{
    return new ',dicName,' { CodeI = test.CodeI, Name = test.Name, ',dicName,'Tr = test.DictTrI.Select(rec => new ',dicName,'Tr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
}
public static implicit operator DictBaseTypeI(',dicName,' test)
{
    return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.',dicName,'Tr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
}'
)
from DicCategoryItems where dicType = 'i'

