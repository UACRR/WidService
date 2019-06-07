[string]$modelPath=Get-Location;
[string]$formDesignPath=[string]::Concat( $modelPath, "\ipsFormsDesign");
$modelPath=[string]::Concat( $modelPath,"\ipsmedserviceapp\Model");
$files = Get-ChildItem -Path $modelPath  -Exclude MediaServiceContext*.cs  -Name -Filter "*.cs";
$i = 0;
[string]$outBuffer = "using System;`nnamespace ipsFormsDesign.Interfaces`n{`n";
[string]$serialize = [string]::Format( "[Serializable]{0}public partial class", [System.Environment]::NewLine);
foreach( $fileName in $files )
{
    if( $fileName -eq "RelCounterDoc.cs")
    {
        $erri = 0;
    }
    $fullName = [string]::Concat( $modelPath, "\", $fileName );
    $formDesignFile = [string]::Concat( $formDesignPath, '\Model\', $fileName );
    $content = [System.IO.File]::ReadAllText($fullName);
    $designContent = [regex]::Replace($content, 'namespace ipsmedserviceapp.Model', 'namespace ipsFormsDesign.Model', [System.Text.RegularExpressions.RegexOptions]::Singleline );  
    $designContent = [regex]::Replace($designContent, 'public partial class (\w+)', 'public partial class $1 : I$1' );  
    $designContent = "using ipsFormsDesign.Interfaces;`n" + $designContent;
    $designContent = [regex]::Replace($designContent, '^(\s+\w+\s+\=\snew )HashSet(<\w+>\(\);)\s', '$1ObservableListSource$2', [System.Text.RegularExpressions.RegexOptions]::Multiline );
    $designContent = [regex]::Replace($designContent, '(\s+public virtual) ICollection<(\w+)> (\w+ { get; set; })?(\s)', '$1 ObservableListSource<$2> $3$4', [System.Text.RegularExpressions.RegexOptions]::Singleline );
    $designContent = [regex]::Replace($designContent, '^(\s+).JsonIgnore.\s', '', [System.Text.RegularExpressions.RegexOptions]::Singleline );
    $designContent | Set-Content $formDesignFile;

    $content = [regex]::Replace($content, 'namespace ipsmedserviceapp.Model', 'namespace ipsFormsDesign.Model', [System.Text.RegularExpressions.RegexOptions]::Singleline );  
    $content = [regex]::Replace($content, 'using.*?{\s+(.*)}.*}', '$1}', [System.Text.RegularExpressions.RegexOptions]::Singleline );
    $content = [regex]::Replace($content, 'public partial class (\w+)', 'public interface I$1', [System.Text.RegularExpressions.RegexOptions]::Singleline );
    $content = [regex]::Replace($content, '\s+public\s\w+\(\)\s+{\s+.+?}\s+','   ', [System.Text.RegularExpressions.RegexOptions]::Singleline );
    $content = [regex]::Replace($content, '(\n\r).*}', '$1}', [System.Text.RegularExpressions.RegexOptions]::Singleline );
    $content = [regex]::Replace($content, '(\s+)public', '$1', [System.Text.RegularExpressions.RegexOptions]::Singleline );
    

    $outBuffer=$outBuffer+$content;
    $i = $i + 1;

}

$outBuffer=$outBuffer+"`n}`n";

$formInterface = [string]::Concat($formDesignPath, "\", "Interfaces\EFInterfaces.cs");
$outBuffer | Set-Content $formInterface;

$setIgnore = Get-Location;
$setIgnore = [System.IO.Path]::Combine( $setIgnore, "SetJsonIgnore.ps1" );
# Split-Path $setIgnore; 

 & $setIgnore;
