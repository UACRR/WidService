insert into PermitUser (login, passwordHash, createDate, modifyDate, isLock, isTempPassword, isWindowsAuth)
values ('sa',
0xB08612FB6E6B2FB16C378D6D1C056F7E23FCE17AB247ADC4C127BC9A01D2E622861484AF198029E4CEEC2DB53EE2E8614D96E01853FBF15E3ED0CA921EFDAD74,
'20200227', '20200306', 0, 0, 0)

-- get id from PermitUser (new inserted)
declare @id integer;

insert into [PermitUserRole] (userCode, roleCode, createDate, isRead, isWrite)
values
(@id, 1, '20200327', 1, 1),
(@id, 2, '20200327', 1, 1),
(@id, 3, '20200327', 1, 1),
(@id, 4, '20200327', 1, 1),
(@id, 5, '20200327', 1, 1),
(@id, 6, '20200327', 1, 1),
(@id, 7, '20200327', 1, 1),
(@id, 8, '20200227', 1, 1),
(@id, 9, '20200327', 1, 1),
(@id, 10, '20200327', 1, 1),
(@id, 11, '20200327', 1, 1);