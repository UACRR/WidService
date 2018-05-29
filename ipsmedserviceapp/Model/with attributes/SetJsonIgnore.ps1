[string]$sorsPath = "D:\work\MediaSercice\ipssysadmin\ipsmedserviceapp\Model";
[xml]$XmlDoc = Get-Content "JsonIgnore.xml";
foreach( $file in $XmlDoc.item )
{
    # $fileName = [System.String]::Concat( $file.name ,".cs" );
    $FileSors = [System.String]::Concat($sorsPath, "\", $file.name ,".cs" );
    $FileDest = [System.String]::Concat($sorsPath, "\with attributes\", $file.name ,".cs" );
    $fileIn = Get-Content $FileSors;
    # [System.Text.StringBuilder]$sb = New-Object 'System.Text.StringBuilder';
    [System.IO.StringWriter]$sb = New-Object 'System.IO.StringWriter';
    

    $sb.WriteLine("using Newtonsoft.Json;" );
    [System.Collections.SortedList]$list = New-Object 'System.Collections.SortedList'; 
    foreach( $item in $file.ignore )
    {
        $list.Add( [String]::Concat( " ", $item, " " ), $item );
    }
    foreach( $str in $fileIn )
    {
        if( $str.Contains("[JsonIgnore]") -eq $true -or  $str.Contains( "using Newtonsoft.Json;" ) -eq $true )
        {
            continue;
        }

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
            $sb.WriteLine( "        [JsonIgnore]" );
        }
        $sb.WriteLine( $str );
    }
    if( [System.IO.File]::Exists( $FileDest ) -eq $true )
    {
        [System.IO.File]::Delete( $FileDest );
    }

    [System.IO.File]::Move( $FileSors, $FileDest );
    $sb.ToString() | Set-Content $FileSors;

    $sb.Dispose();
}