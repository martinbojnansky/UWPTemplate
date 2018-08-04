$oldSlnName = Read-Host "Please enter the old solution name"
$newSlnName = Read-Host "Please enter the new solution name"

Write-Host "Rename files from " $oldSlnName " to " $newSlnName   
$files = Get-ChildItem $projectpath -include *.cs, *.csproj, *.sln, * -Filter *$oldSlnName* -Recurse 

$files |
    Sort-Object -Descending -Property { $_.FullName } |
    Rename-Item -newname { $_.name -replace $oldSlnName, $newSlnName } -force

Write-Host "Rename files sucessfull"

Write-Host "Replace content in files"
$files = Get-ChildItem $projectpath -File -include *.cs, *.csproj, *.sln, * -Recurse 

foreach($file in $files) 
{ 
    ((Get-Content $file.fullname) -creplace $oldSlnName, $newSlnName) | set-content $file.fullname -Encoding UTF8
}

Write-Host "Rename complete!" -ForegroundColor Green

git init
(git add .) | out-null
(git commit -m "Renames solution.") | out-null

#create basic alias for git stash pul
git config alias.stash-update "!git stash && git fetch && git pull && git stash pop"
#you can't register alias to alias
git config alias.su "!git stash && git fetch && git pull && git stash pop"
Write-Host "Initialize git complete!" -ForegroundColor Green

Write-Host "Done!" -ForegroundColor Green
