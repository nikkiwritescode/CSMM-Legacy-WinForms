@echo off
wit copy ..\_working_directory/ "%~1" --trunc -vv --align-files --quiet --overwrite
@RD /S /Q "..\_working_directory/"
exit