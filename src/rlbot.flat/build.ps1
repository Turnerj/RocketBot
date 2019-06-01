Write-Host "Removing existing code files..."
Remove-Item .\rlbot -Recurse

Write-Host "Downloading FlatBuffers definition files..."

$tmpFlatBuffersReference = New-TemporaryFile
Rename-Item $tmpFlatBuffersReference "$tmpFlatBuffersReference.fbs"
$tmpFlatBuffersReference = "$tmpFlatBuffersReference.fbs"
Invoke-WebRequest -Uri "https://github.com/RLBot/RLBot/raw/master/src/main/flatbuffers/rlbot.fbs" -OutFile $tmpFlatBuffersReference

Write-Host "Building Flat"

$tmpFlatBuffersExecutable = New-TemporaryFile
Rename-Item $tmpFlatBuffersExecutable "$tmpFlatBuffersExecutable.exe"
$tmpFlatBuffersExecutable = "$tmpFlatBuffersExecutable.exe"
Write-Host "FlatBuffers Executable: $tmpFlatBuffersExecutable"
Invoke-WebRequest -Uri "https://github.com/RLBot/RLBot/raw/master/src/main/flatbuffers/flatc.exe" -OutFile $tmpFlatBuffersExecutable

Write-Host "Generating code files..."
$cmd = "& $tmpFlatBuffersExecutable --csharp -o .\ $tmpFlatBuffersReference"
Invoke-Expression $cmd