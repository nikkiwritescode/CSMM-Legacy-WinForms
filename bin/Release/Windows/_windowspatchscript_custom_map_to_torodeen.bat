@echo off
wit extract ..\_place_vanilla_iso_here\original.iso ..\_working_directory/ -v --enc decrypt

xcopy ..\_place_one_map_file_here_at_a_time\*.frb ..\_working_directory\files\param\torodeen.frb /y

wit copy ..\_working_directory/ ..\_patched_iso_will_go_here\FS-Custom.iso --trunc -vv --align-files

pause