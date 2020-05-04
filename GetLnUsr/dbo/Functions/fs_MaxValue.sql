CREATE function dbo.fs_MaxValue(@val1 float, @val2 float)
returns int
as
begin
  if @val1 > @val2
    return @val1
  return isnull(@val2,@val1)
end

