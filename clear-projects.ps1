# Delete "bin" and "obj" folders from the current directory and all subdirectories
Get-ChildItem -Path . -Directory -Recurse -Force | Where-Object { $_.Name -in @('bin', 'obj') } | ForEach-Object { 
    try {
        Remove-Item -Path $_.FullName -Recurse -Force -ErrorAction Stop
        Write-Host "Deleted folder: $($_.FullName)"
    } catch {
        Write-Host "Failed to delete folder: $($_.FullName). Error: $($_.Exception.Message)"
    }
}
