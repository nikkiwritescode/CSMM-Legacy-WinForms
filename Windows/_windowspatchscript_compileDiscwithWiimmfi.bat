@echo off
wit copy ..\_working_directory/ .\FS-Custom.iso --trunc --align-files --wiimmfi --quiet --overwrite

wit copy .\FS-Custom.iso "%~1" --psel=data --wiimmfi

del /f .\FS-Custom.iso

@RD /S /Q "..\_working_directory/"

exit