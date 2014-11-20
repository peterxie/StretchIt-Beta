@echo off

set name=%1
set src_image_file=%2
set src_audio_file=%3
set dst_image_path=%4
set dst_audio_path=%5

copy %src_image_file% %dst_image_path%\%name%.jpg >nul

copy %src_audio_file% %dst_audio_path%\%name%.wav >nul

