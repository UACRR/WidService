[string]$modelPath="D:\work\MediaSercice\ipssysadmin\ipsmedserviceapp\Model";
$files = Get-ChildItem -Path $modelPath  -Exclude MediaServiceContext*.cs  -Name -Filter "*.cs";
$i = 0;
$outBuffer = "";
foreach( $fileName in $files )
{
    $fullName = [string]::Concat( $modelPath, "\", $fileName );
    $content = Get-Content -Path $fullName;
    $content = $content -replace "using.*?{\n\s+(.+)}.+}", "$1}";
    # $content = $content -replace "public\s(\w+)\(\)\n\s+{.*?}\n\n","" -replace "(\n)\n.*}", "$1}" -replace "(\s+)public\s", "$1";

    $outBuffer = $outBuffer  + $content;
    $i = $i + 1;
    if( $i -ge 2 ) 
    {
        break;
    } 

    Write-Host $outBuffer;
}