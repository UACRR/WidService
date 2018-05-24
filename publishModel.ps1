[string]$modelPath=Get-Location;
[string]$formDesignPath=[string]::Concat( $modelPath, "\ipsFormsDesign");
$modelPath=[string]::Concat( $modelPath,"\ipsmedserviceapp\Model");
$files = Get-ChildItem -Path $modelPath  -Exclude MediaServiceContext*.cs  -Name -Filter "*.cs";
$i = 0;
[string]$outBuffer = "using System;`nnamespace ipsFormsDesign.Interfaces`n{`n";


foreach( $fileName in $files )
{
    $fullName = [string]::Concat( $modelPath, "\", $fileName );
    $formDesignFile = [string]::Concat( $formDesignPath, '\Model\', $fileName );
    $content = [System.IO.File]::ReadAllText($fullName);
    $designContent = [regex]::Replace($content, 'namespace ipsmedserviceapp.Model', 'namespace ipsFormsDesign.Model', [System.Text.RegularExpressions.RegexOptions]::Singleline );  
    $designContent = [regex]::Replace($designContent, 'public partial class (\w+)', 'public partial class $1 : I$1', [System.Text.RegularExpressions.RegexOptions]::Singleline );  
    $designContent = "using ipsFormsDesign.Interfaces;`n" + $designContent;
    $designContent | Set-Content $formDesignFile;
    $content = [regex]::Replace($content, 'using.*?{\s+(.*)}.*}', '$1}', [System.Text.RegularExpressions.RegexOptions]::Singleline );
    $content = [regex]::Replace($content, 'public partial class (\w+)', 'public interface I$1', [System.Text.RegularExpressions.RegexOptions]::Singleline );
    $content = [regex]::Replace($content, '\s+public\s\w+\(\)\s+{\s+.+?}\s+','   ', [System.Text.RegularExpressions.RegexOptions]::Singleline );
    $content = [regex]::Replace($content, '(\n)\r.*}', '$1}', [System.Text.RegularExpressions.RegexOptions]::Singleline );
    $content = [regex]::Replace($content, '(\s+)public', '$1', [System.Text.RegularExpressions.RegexOptions]::Singleline );

    $outBuffer=$outBuffer+$content;
    $i = $i + 1;
    # if($i -ge 2 )
    # {
    #     break;
    # }
}

$outBuffer=$outBuffer+"`n}`n";

$formInterface = [string]::Concat($formDesignPath, "\", "Interfaces\EFInterfaces.cs");
$outBuffer | Set-Content $formInterface;
