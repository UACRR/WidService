--drop function dbo.f_N2TUk
CREATE function [dbo].[f_N2TUk] (@Num BIGINT, @IsMaleGender bit=1)
returns varchar(255)
as
begin
 declare @nword varchar(255), @th tinyint, @gr smallint, @d3 tinyint, @d2
tinyint, @d1 tinyint
 if @Num<0 return '*** Error: Negative value' else if @Num=0 return 'Ноль'
/* особый случай */
 while @Num>0
 begin
  set @th=IsNull(@th,0)+1  set @gr=@Num%1000  set @Num=(@Num-@gr)/1000
  if @gr>0
  begin
   set @d3=(@gr-@gr%100)/100
   set @d1=@gr%10
   set @d2=(@gr-@d3*100-@d1)/10
   if @d2=1 set @d1=10+@d1
   set @nword=case @d3
         when 1 then ' сто' 
         when 2 then ' двісті' 
         when 3 then ' триста'
         when 4 then ' чотириста' 
         when 5 then ' п''ятсот' 
         when 6 then ' шістьсот'
         when 7 then ' сімсот' 
         when 8 then ' вісімсот' 
         when 9 then ' дев''ятьсот' else '' end
        +case @d2
         when 2 then ' двадцять' 
         when 3 then ' тридцять' 
         when 4 then ' сорок'
         when 5 then ' п''ятьдесят' 
         when 6 then ' шістьдесят' 
         when 7 then ' сімьдесят'
         when 8 then ' вісімдесят' 
         when 9 then ' дев''яносто' else '' end
        +case @d1
         when 1 then (case when @th=2 or (@th=1 and @IsMaleGender=0) then ' одна' else ' один' end)
         when 2 then (case when @th=2 or (@th=1 and @IsMaleGender=0) then ' дві' else ' два' end)
         when 3 then ' три' 
         when 4 then ' чотири' 
         when 5 then 'п''ять'
         when 6 then ' шість' 
         when 7 then ' сім' 
         when 8 then ' вісім'
         when 9 then ' дев''ять' 
         when 10 then ' десять' 
         when 11 then ' одинадцять'
         when 12 then ' дванадцять' 
         when 13 then ' тринадцять' 
         when 14 then ' чотирнадцять'
         when 15 then ' п''ятнадцять' 
         when 16 then ' шістнадцять' 
         when 17 then ' сімнадцять'
         when 18 then ' вісімнадцять' 
         when 19 then ' дев''ятнадцять' else '' end
        +case @th
         when 2 then ' тисяч'   +(case when @d1=1 then 'а' when @d1 in (2,3,4) then 'і' else ''  end)
         when 3 then ' мільон' 
         when 4 then ' мільярд' 
         when 5 then ' триліон' 
         when 6 then ' квадриліон' 
         when 7 then ' квинтиліон' 
         else '' end
        +case when @th in (3,4,5,6,7) then (case when @d1=1 then '' when @d1 in (2,3,4) then 'и' else 'ів' end) else '' end
        +IsNull(@nword,'')
  end
 end
 return upper(substring(@nword,2,1))+substring(@nword,3,len(@nword)-2)
end

--select dbo.f_Num2Wort (123456781.47, NULL, NULL)
--select dbo.f_Num2Wort (121456782.47, NULL, NULL)