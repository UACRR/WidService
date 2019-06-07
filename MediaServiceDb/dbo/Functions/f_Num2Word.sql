
--drop function dbo.f_Num2Wort
create function [dbo].[f_Num2Word] (@Value money, @currency char(3)=NULL, @lang char(2)=NULL)
returns varchar(1024)
as
begin
--------Ф-я суммы прописью для валюты на языке
 declare @rpart bigint, @rattr tinyint, @cpart tinyint, @cattr tinyint, @RText varchar(1024)

 set @currency = isnull(@currency,'980')  
 set @lang = isnull(@lang, 'Uk')
 
 set @rpart=floor(@Value)   set @rattr=@rpart%100
 if @rattr>19 
    set @rattr=@rattr%10

 set @cpart=(@Value-@rpart)*100

 if @cpart>19 
    set @cattr=@cpart%10 
  else set @cattr=@cpart
 
 If @lang = 'Ru' 
 BEGIN
 IF @currency = '643'
 set @RText = 
 dbo.f_N2TRu(@rpart,1)+' рубл' + 
       case when @rattr=1 then 'ь' when @rattr in (2,3,4) then 'я' 
            else 'ей' end+' ' +right('0'+cast(@cpart as varchar(2)),2)+' копе' + 
            case when @cattr=1 then 'йка' when @cattr in (2,3,4) then 'йки'
             else 'ек' end

 If @currency = 840
 set @RText =  dbo.f_N2TRu(floor(@Value),1)+' доллар'
      +case when @rattr=1 then '' when @rattr in (2,3,4) then 'а' else
'ов' end
      +' США '+right('0'+cast(@cpart as varchar(2)),2)+' цент'
      +case when @cattr=1 then '' when @cattr in (2,3,4) then 'а' else
'ов' end

 If @currency = 980
 set @RText =  dbo.f_N2TRu(@rpart,0)+' грив' + 
       case when @rattr=1 then 'на' when @rattr in (2,3,4) then 'ны' 
            else 'ен' end+' ' +right('0'+cast(@cpart as varchar(2)),2)+' копе' + 
            case when @cattr=1 then 'йка' when @cattr in (2,3,4) then 'йки'
             else 'ек' end
END 

 If @lang = 'Uk' 
 BEGIN
 IF @currency = '643'
 set @RText = 
 dbo.f_N2TUk(@rpart,1)+' рубл' + 
       case when @rattr=1 then 'ь' when @rattr in (2,3,4) then 'і' 
            else 'ів' end+' ' +right('0'+cast(@cpart as varchar(2)),2)+' копі' + 
            case when @cattr=1 then 'йка' when @cattr in (2,3,4) then 'йки'
             else 'йок' end

 If @currency = 840
 set @RText =  dbo.f_N2TUk(floor(@Value),1)+' доллар'
      +case when @rattr=1 then '' when @rattr in (2,3,4) then 'и' else
'ів' end
      +' США '+right('0'+cast(@cpart as varchar(2)),2)+' цент'
      +case when @cattr=1 then '' when @cattr in (2,3,4) then 'и' else
'ів' end

 If @currency = 980
 set @RText =  dbo.f_N2TUk(@rpart,1)+' грив' + 
       case when @rattr=1 then 'ня' when @rattr in (2,3,4) then 'ні' 
            else 'ен' end+' ' +right('0'+cast(@cpart as varchar(2)),2)+' копі' + 
            case when @cattr=1 then 'йка' when @cattr in (2,3,4) then 'йки'
             else 'йок' end
END 


 If @lang = 'En' 
 BEGIN
 IF @currency = '643'
 set @RText = 
 dbo.f_N2TEn(@rpart,1)+' rubl' + 
       case when @rattr=1 then '' else 's' end+' ' +right('0'+cast(@cpart as varchar(2)),2)+' copeck' + 
            case when @cattr=1 then '' else 's' end

 If @currency = 840
 set @RText =  dbo.f_N2TEn(floor(@Value),1)+' dollar'
      +case when @rattr=1 then '' else 's' end
      +' USA '+right('0'+cast(@cpart as varchar(2)),2)+' cent'
      +case when @cattr=1 then '' else 's' end

 If @currency = 980
 set @RText =  dbo.f_N2TEn(@rpart,1)+' grivna' + 
       case when @rattr=1 then '' else 's' end+' ' +right('0'+cast(@cpart as varchar(2)),2)+' cent' + 
            case when @cattr=1 then '' else 's' end
END 

return @RText
 
end

--select dbo.f_Num2Word (12345381.47, '980', 'En')