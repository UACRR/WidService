USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spSaveExceptionSet]    Script Date: 12.09.2022 13:09:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[spSaveExceptionSet]
	  @setCode int
	, @newSetName varchar(100)
    , @ExceptionMember ExceptionMember readonly
	, @ExceptionAdd ExceptionAdd readonly	
as
begin
begin try
    begin transaction
	
	exec spDeleteExceptionSet @setCode, 1;

	update ExceptionSet
    set setName = @newSetName, dateUpdated = GetDate()
    where setCode = @setCode
	
	declare @idBaseEM int = (select ident_current('ExceptionMember') + 1);
	set identity_insert ExceptionMember on; 
    insert ExceptionMember(
        id
        , dateBegin
        , dateEnd
        , setCode
        , rHolderType
        , memberName
        , nameForSeek
        , interCode
        , excType
        , custId
        , comment
        , IPInr
        , dateCreated
	) 
    select id + @idBaseEM
        , dateBegin
        , dateEnd
        , setCode
        , rHolderType
        , memberName
        , nameForSeek
        , interCode
        , excType
        , custId
        , comment
        , IPInr
        , dateCreated
    from @ExceptionMember; 
    set identity_insert ExceptionMember off;

	declare @idBaseAdd int = (select ident_current('ExceptionAdd') + 1);
	set identity_insert ExceptionAdd on; 
    insert ExceptionAdd (
          id
        , excId
        , custId
        , interCode
        , name
        , nameForSeek
        , IPInr
        , dateCreated
    )
    select 
          id + @idBaseAdd
        , excId + @idBaseEM
        , custId
        , interCode
        , name
        , nameForSeek
        , IPInr
        , dateCreated 
    from @ExceptionAdd
    set identity_insert ExceptionAdd off;

	commit transaction
end try
begin catch
	rollback transaction
	declare @ErrorMessage NVARCHAR(4000);  
    declare @ErrorState INT;  
    select   
        @ErrorMessage = error_message(),  
        @ErrorState = error_state();  
  
    raiserror (
		  @ErrorMessage -- Message text.  
		, 16 -- Severity.  
		, @ErrorState -- State.  
    )   with nowait;  
end catch

end
GO

