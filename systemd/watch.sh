#!/bin/sh
while true; do
  file=`inotifywait -q -r . -e modify --format '%w%f'`
  case $file in
    *.haml) echo "Running haml on ${file}"; haml ${file} ${file/haml/html} ;;
    *.scss) echo "Running sass on ${file}"; sass ${file}:${file/scss/css} ;;
    *) ;;
  esac
done


