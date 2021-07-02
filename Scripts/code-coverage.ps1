dotnet test --collect:"XPlat Code Coverage" --results-directory ../TestResults ../JGarfield.DealerOnSalesTaxes.Tests

$filename = ls -r -ea silentlycontinue -fo -inc "coverage.cobertura.xml" ../TestResults | sort CreationTime | Select-Object -ExpandProperty fullname | Select-Object -First 1

reportgenerator `
	"-reports:$filename" `
	"-targetdir:../TestResults/coveragereport" `
	-reporttypes:Html

Start-Process ../TestResults/coveragereport/index.html
