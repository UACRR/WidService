--drop function dbo.f_N2TEn
Create function [dbo].[f_N2TEn] (@Num BIGINT, @IsMaleGender bit=1)
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
         when 1 then ' one hungred' 
         when 2 then ' two hungreds' 
         when 3 then ' three hungreds'
         when 4 then ' four hungreds' 
         when 5 then ' five hungreds' 
         when 6 then ' six hungreds'
         when 7 then ' seven hungreds' 
         when 8 then ' eight hungreds' 
         when 9 then ' nine hungreds' else '' end
        +case @d2
         when 2 then ' twenty' 
         when 3 then ' thirty' 
         when 4 then ' fourty'
         when 5 then ' fifty' 
         when 6 then ' sixty' 
         when 7 then ' seventy'
         when 8 then ' eighty' 
         when 9 then ' ninety' else '' end
        +case @d1
         when 1 then (case when @th=2 or (@th=1 and @IsMaleGender=0) then ' one' else ' one' end)
         when 2 then (case when @th=2 or (@th=1 and @IsMaleGender=0) then ' two' else ' two' end)
         when 3 then ' three' 
         when 4 then ' four' 
         when 5 then ' five'
         when 6 then ' six' 
         when 7 then ' seven' 
         when 8 then ' eight'
         when 9 then ' nine' 
         when 10 then ' ten' 
         when 11 then ' eleven'
         when 12 then ' twelve' 
         when 13 then ' thirteen' 
         when 14 then ' fourteen'
         when 15 then ' fifteen' 
         when 16 then ' sixteen' 
         when 17 then ' seventeen'
         when 18 then ' eighteen' 
         when 19 then ' nineteen' else '' end
        +case @th
         --when 1 then ' hungred'   +(case when @d1=1 then '' else 's'  end)
         when 2 then ' thousand'  +(case when @d1=1 then '' else 's'  end)
         when 3 then ' million'   +(case when @d1=1 then '' else 's'  end)
         when 4 then ' мільярд'   +(case when @d1=1 then '' else 's'  end)
         when 5 then ' триліон'   +(case when @d1=1 then '' else 's'  end)
         when 6 then ' квадриліон' +(case when @d1=1 then '' else 's'  end)
         when 7 then ' квинтиліон' +(case when @d1=1 then '' else 's'  end)
         else '' end
         + case when @th in (1,2,3,4,5,6,7) then (case when @d1=1 then '' else 's' end) else '' end
        +IsNull(@nword,'')
  end
 end
 return upper(substring(@nword,2,1))+substring(@nword,3,len(@nword)-2)
end

--select dbo.f_Num2Wort (123456781.47, NULL, NULL)
--select dbo.f_Num2Wort (121456782.47, NULL, NULL)