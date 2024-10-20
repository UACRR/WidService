truncate table IdentBacklog


 IsRepeat:
    DELETE TOP (100000)
    FROM [DDEX].[dbo].[IdentBacklog]
    IF @@ROWCOUNT > 0
         GOTO IsRepeat

		--51 195 264