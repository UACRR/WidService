-- IP ROLE MUST BE ENTERED

-- Main error id = 9, inferred error ids =  9, 16, 17, 18, 19, 22
update RespFileErr set IsFixed = 1 where RespFileErr in (9, 16, 17, 18, 19, 22)