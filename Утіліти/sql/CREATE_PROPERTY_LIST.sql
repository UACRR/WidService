CREATE TABLE #propTable
(
	property VARCHAR(50),
)

INSERT INTO #propTable (property)
values 
('TV_ALL'),
('TV_NO_ACCEPT'),
('TV_NO_ATTACH'),
('TV_NO_DISTRIB'),
('BTN_UPDATE'),
('BTN_CREATE_OBJ'),
('GV_IN_CODE'),
('GV_OBJ_NAME'),
('GV_BS_CAT_NAME'),
('GVTT_BS_CAT_NAME'),
('GV_GENRE'),
('GV_AUTHOR'),
('GV_PERFORMER'),
('GV_RATE'),
('GV_UNDISTRIB_MONEY');


-- приватні поля для властивостей
select 
concat('private string _',LOWER(property),';') 
from #propTable

-- властивості для класів локалізації
select 
concat('public string ', property, '
{','
	get => _', LOWER(property), ';','
	set 
	{
		_', LOWER(property), ' = value; 
		OnPropertyChanged(nameof(',property,')); 
	}','
}') 
from #propTable

-- властивості для класів Language Library
select concat('public LanguageItem ', property, ' { get; set; } = new LanguageItem();')
from #propTable


-- грохнуть
DROP TABLE #propTable


















