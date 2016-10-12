if (-NOT ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator))
{
    $arguments = "-ExecutionPolicy UnRestricted -File """ + $myinvocation.mycommand.definition + """"
    Start-Process powershell -Verb runAs -ArgumentList $arguments
    Break
}

$services = @{}
$services.Add("CalculatorHost",  "5000")
$services.Add("FigureCalculatorHost",   "5001")

$userName = "$([Environment]::UserDomainName)\$([Environment]::UserName)"

foreach($pair in $services.GetEnumerator()){
    $serviceName = $pair.Name
    $port = $pair.Value

    $deleteCommand1 = "netsh http delete urlacl url=http://*:$($port)/"
    $deleteCommand2 = "netsh http delete urlacl url=http://+:$($port)/"
    $addCommand = "netsh http add urlacl url=http://+:$($port)/ listen=yes user=$userName"

    Write-Host "Setting up $($serviceName) at port $($port) for user $($userName)"
    Invoke-Expression $deleteCommand1
    Invoke-Expression $deleteCommand2
    Invoke-Expression $addCommand
    Write-Host "$($serviceName) ready!"
}


Start-Process "$PSScriptRoot\CalculatorHost\bin\Debug\Calculator.Host.exe"
Start-Process "$PSScriptRoot\FigureCalculatorHost\bin\Debug\FigureCalculator.Host.exe"
Start-Process "$PSScriptRoot\SampleApp\bin\Debug\SampleApp.exe"