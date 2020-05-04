
CREATE function  [dbo].[ft_Tsk_5_24_DBF]  (@dateBegin date = NULL, @dateEnd date = NULL)
--Реєстр по переданим проводкам з бухгалтерії
RETURNS @RT TABLE
(
id integer identity primary key, 
inputDate date, 
mfo char(10), 
okpol varchar(15), 
account varchar(30), 
mfoCorr varchar(256), 
nameMfoCorr varchar(200), 
accountCorr varchar(25), 
okpoCorr varchar(15), 
nameCorr varchar(200), 
dogNum varchar(50), 
docDate date, 
amount money, 
nplat varchar(512), 
custId integer,
clnName varchar(100), 
paidId integer, 
inputFileId integer, 
fileName varchar(100)
)
  
as
BEGIN
--Первый день месяца
set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

--Платежи 
insert into @RT
(inputDate, mfo, okpol, account, mfoCorr, nameMfoCorr, accountCorr, okpoCorr, nameCorr, dogNum, docDate, amount, nplat, custId, clnName, paidId, inputFileId, fileName)
select  inputDate, mfo, okpol, account, mfoCorr, nameMfoCorr, accountCorr, okpoCorr, nameCorr, t1.docNum, docDate, t1.sCredit-t1.sDebet, nplat, 
        t1.custId, NULL, t1.paidId, t1.inputFileId, t2.fileName
  from ExternalPay t1 
   join inputFile t2 on t2.fileId = t1.inputFileId 
   where t1.inputDate between @datebegin and @dateEnd 
   order by inputDate, fileName, nameCorr

update @RT 
  set clnName = t2.name 
  from @RT t1 
  join vCustomer t2 on t2.custid = t1.custid 

RETURN
END
/*
select id, inputDate, fileName, nameCorr, mfoCorr, nameMfoCorr, accountCorr, okpoCorr, dogNum, docDate, amount, nplat, clnName, mfo, okpol, account 
 from ft_Tsk_5_24_DBF  ('2018-11-01', '2019-11-30') order by inputDate, fileName, nameCorr
*/

GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_24_DBF] TO [ReportUser]
    AS [dbo];

