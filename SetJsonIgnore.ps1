[string]$modelPath = Get-Location;
[string]$sorsPath = [String]::Concat($modelPath, "\Утіліти\JsonIgnore.xml");
[xml]$XmlDoc = Get-Content $sorsPath;
$sorsPath = [String]::Concat($modelPath, "\ipsmedserviceapp\Model");
[System.IO.DirectoryInfo] $modelDir = New-Object 'System.IO.DirectoryInfo'( $sorsPath );

foreach ( $csfile in $modelDir.GetFiles() ) {
    $fileName = [System.IO.Path]::GetFileNameWithoutExtension(   $csfile.Name );
    $file = $XmlDoc.tables.item  | Where-Object { $_.name -eq $fileName }; 
    if ($file -eq $null )
    {
        continue;
    }
    # $fileName = [System.String]::Concat( $file.name ,".cs" );
    $FileSors = [System.String]::Concat($sorsPath, "\", $fileName , ".cs" );
    $FileDest = [System.String]::Concat($sorsPath, "\with attributes\", $fileName , ".cs" );
    [string[]]$fileIn = Get-Content $FileSors;
    # [System.Text.StringBuilder]$sb = New-Object 'System.Text.StringBuilder';
    [System.IO.StringWriter]$sb = New-Object 'System.IO.StringWriter';
    

    $sb.WriteLine("using Newtonsoft.Json;" );
    [System.Collections.SortedList]$list = New-Object 'System.Collections.SortedList'; 
    
    if ( $file -ne $null ) {
        foreach ( $item in $file.noignore ) {
            $list.Add( [String]::Concat( " ", $item.Trim(), " " ), $item );
        }
    }

    $lastSpace = 0;
    $lastLevel = 0;
    $levelNumber = 0;
    for ( $i = 0; $i -lt $fileIn.Count; $i++ ) {
        $internalStr = $fileIn[$i].Trim();
        if( $internalStr -eq "{" ) {
            $levelNumber = $levelNumber +1;
        }
        if( $internalStr -eq "}" ) {
            $levelNumber = $levelNumber -1;
            $lastLevel = $i;
        }

        if ( $levelNumber -eq 2 -and [String]::IsNullOrWhiteSpace( $internalStr ) -eq $true ) {
            $lastSpace = $i;
        }
    }
    # $i = 0;
    for ( $i=0 ; $i -lt $fileIn.Count; $i++  ) {
        $str=$fileIn[$i];
        if ( $str.Contains("[JsonIgnore]") -eq $true -or $str.Contains( "using Newtonsoft.Json;" ) -eq $true ) {
            continue;
        }

        if ( $i -gt $lastSpace ) {
            [bool]$isNoIgnore = $false;
            foreach ( $key in $list.Keys ) {
                if ( $str.Contains( $key ) ) {
                    $isNoIgnore = $true;
                    break;
                }
            }
            if ( $lastLevel-1 -gt $i -and $isNoIgnore -ne $true) {
                $sb.WriteLine( "        [JsonIgnore]" );
            }
        }
        $sb.WriteLine( $str );
    }
    if ( [System.IO.File]::Exists( $FileDest ) -eq $true ) {
        [System.IO.File]::Delete( $FileDest );
    }

    [System.IO.File]::Move( $FileSors, $FileDest );
    $sb.ToString() | Set-Content $FileSors;

    $sb.Dispose();
}

Write-Host "JsonIgnore update process successful!"
