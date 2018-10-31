---------------------
CREATE PROCEDURE [dbo].[prtDocument] ( @docid  integer, @lang char(2) = NULL )
AS   
Begin
SET NOCOUNT ON;   --отключение вывода кол-ва строк для оптимизации
declare @Retcode integer, @ErrMsg varchar(200)
declare @DocType integer 

 If not exists ( select 1 from Document where docid = @docid ) 
  begin 
    Set @ErrMsg = ' Помилка документу!'
    Set @Retcode = 1
  end 

  If @Retcode <> 0 
   Begin 
     Set @ErrMsg = @ErrMsg + ' Операцію відхилено!'
	 RAISERROR
    (N'%s',
    10, -- Severity.
    1, -- State.
    @ErrMsg  -- First substitution argument.
     ); -- Second substitution argument.
    Return @RetCode
   end

set @lang = (Case When @lang is NULL or  @lang not in ('Uk', 'Ru','En') Then 'Uk' Else  @lang end)
set @DocType = ( select docTypeCode from document where docid = @docid )

If @DocType  = 3 
/*
(
docid        integer not null  primary key, 
reqId        integer null, 
licNum       varchar(64) NULL, 
licDate      char(10) NULL, 
licNumDate   varchar(100) NULL, 
custDesc     varchar(254) NULL,
licName      varchar(254) NULL,
productDesc  varchar(512) NULL, 
LocationName text NULL,
termUseName  varchar(254) NULL,
licCode      integer      NULL,
licNameType  varchar(254) NULL,
licNameTypeR varchar(254) NULL,
licNameC     varchar(254) NULL,
useMediaTypeName varchar(254) NULL,
AddUse       varchar(254) NULL, 
custNameMy   varchar(254) NULL, 
objId integer null, 
objName varchar(254) null, 
objAuthor varchar(254) null,
objPerfomer varchar(254) null, 
countUse integer null,               --кол-во использования
countUseName varchar(100) null,      --кол-во использования словами
TimeDesc varchar(254) null           --эпизод и хронометраж словами
 )
 */
 exec PrtDocLic @docid, @lang

--If @DocType  = 5 
-- exec PrtDocInv (@docid, @lang) 

--select * from #RT
--return @retcode

END

--exec dbo.prtDocument 14
--exec PrtDocLic 14