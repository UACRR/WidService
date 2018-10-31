--drop FUNCTION dbo.f_docNumber 
CREATE FUNCTION dbo.f_docNumber (@docType integer)
RETURNS char(25)
    WITH EXECUTE AS CALLER 
    as
    BEGIN 
    declare  @result char(25)
    set @result = 
(select 
(Case when isnull(max(k1.docMaker),'') = '' then '' Else max(k1.docMaker)+'-' end) +
convert(char(10),
(
isnull(max(convert(integer, (substring (isnull(d1.docNumber,''), isnull(patIndex('%-%',isnull(d1.docNumber,'')),0)+1, 30)))),0) +1))
      from Document d1
	  join DocumentKind k1 on d1.docTypeCode = k1.docTypeCode
	  where d1.docTypeCode = @docType
)
	RETURN @result
END
--select dbo.f_docNumber(4)