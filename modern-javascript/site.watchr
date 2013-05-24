watch('(.*\.haml)$')  { |hml| system("haml #{hml[0]} #{hml[0][0..-5]}html")}
watch('(.*\.scss)$') { |sass| system("sass #{sass[0]}:#{sass[0][0..-5]}css")} 
