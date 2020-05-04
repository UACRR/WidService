create view vRelSchemaKindCode as 
select t1.schemaCode, t1.kindCode, t1.CDE, t2.crGroupCode
  from RelSchemaKindCode t1 
    join CopyrightKind t2 on t1.kindCode = t2.codeI
