watch('(.*\.haml)$')  { |hml| system("haml #{hml[0]} #{hml[0][0..-5]}html")}
watch('(.*\.dot)$')  { |hml| system("dot -Tsvg -o #{hml[0][0..-4]}svg #{hml[0]}") }
watch('(.*\.scss)$') { |sass| system("sass #{sass[0]}:#{sass[0][0..-5]}css")} 
