[xml]$XmlDoc = Get-Content "D:\work\MediaSercice\ipssysadmin\ipsmedserviceapp\Model\with attributes\JsonIgnore.xml";
foreach( $file in $XmlDoc.item )
{
    $updateFile = [System.String]::Concat("D:\work\MediaSercice\ipssysadmin\ipsmedserviceapp\Model\with attributes\", $file.name ,".cs" );
    $fileIn = Get-Content $updateFile;
    [System.Text.StringBuilder]$sb = New-Object 'System.Text.StringBuilder';
    $sb.AppendLine(("using Json");
    
    [System.Collections.SortedList]$list = New-Object 'System.Collections.SortedList'; 
    foreach( $item in $file.ignore )
    {
        $list.Add( [String]::Concat( " ", $item, " " ), $item );
    }
    foreach( $str in $fileIn )
    {
        [bool]$isIgnore = $false;
        foreach( $key in $list.Keys )
        {
            if( $str.Contains( $key ) )
            {
                $isIgnore = $true;
                break;
            }
        }
        if($isIgnore -eq $true)
        {
            Write-Host "[JsonIgnore]"
        }
        Write-Host $str;
    }
}