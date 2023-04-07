# Initialize the project setup and run unit tests.

# install neccessary tool
dotnet tool install -g dotnet-reportgenerator-globaltool

# Requirements: dotnet cli, dotnet .net 
dotnet build "$PSScriptRoot\RoomBookingApp.sln"

# Run unit tests that will generate code coverage in TestResult in each of Test projects.
dotnet test "$PSScriptRoot\RoomBookingApp.Core.Tests" --collect:"XPlat Code Coverage"
dotnet test "$PSScriptRoot\RoomBookingApp.Persistance.Tests" --collect:"XPlat Code Coverage"
dotnet test "$PSScriptRoot\RoomBookingApp.Api.Tests" --collect:"XPlat Code Coverage"

#region reportgenerator for RoomBookingApp.Core.Tests
# Set the parent directory path
$parentDirectory = "$PSScriptRoot\RoomBookingApp.Core.Tests\TestResults\"

# Get the most recent .xml file in the parent directory and its subdirectories
$latestXmlFile = Get-ChildItem -Path $parentDirectory -Filter "coverage.cobertura.xml" -Recurse | Sort-Object LastWriteTime -Descending | Select-Object -First 1

# Get the full path to the most recent .xml file
$fullPath = $latestXmlFile.FullName

# Run the report generator
reportgenerator "-reports:$fullPath" "-targetdir:$PSScriptRoot\RoomBookingApp.Core.Tests\coverageresults" -reporttypes:Html
#endregion

#region reportgenerator for RoomBookingApp.Persistance.Tests
# Set the parent directory path
$parentDirectory = "$PSScriptRoot\RoomBookingApp.Persistance.Tests\TestResults\"

# Get the most recent .xml file in the parent directory and its subdirectories
$latestXmlFile = Get-ChildItem -Path $parentDirectory -Filter "coverage.cobertura.xml" -Recurse | Sort-Object LastWriteTime -Descending | Select-Object -First 1

# Get the full path to the most recent .xml file
$fullPath = $latestXmlFile.FullName

# Run the report generator
reportgenerator "-reports:$fullPath" "-targetdir:$PSScriptRoot\RoomBookingApp.Persistance.Tests\coverageresults" -reporttypes:Html
#endregion

#region reportgenerator for RoomBookingApp.Api.Tests
# Set the parent directory path
$parentDirectory = "$PSScriptRoot\RoomBookingApp.Api.Tests\TestResults\"

# Get the most recent .xml file in the parent directory and its subdirectories
$latestXmlFile = Get-ChildItem -Path $parentDirectory -Filter "coverage.cobertura.xml" -Recurse | Sort-Object LastWriteTime -Descending | Select-Object -First 1

# Get the full path to the most recent .xml file
$fullPath = $latestXmlFile.FullName

# Run the report generator
reportgenerator "-reports:$fullPath" "-targetdir:$PSScriptRoot\RoomBookingApp.Api.Tests\coverageresults" -reporttypes:Html
#endregion