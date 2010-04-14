set terminal png nocrop enhanced 8 size 550,550
set output 'curve.png'
set xzeroaxis linestyle -1
set yzeroaxis linestyle -1
set parametric 
set size square
set xrange [-10:10]
set yrange [-5:5]
set nokey
plot [-10:10] (t + 2) **2 -3, t 
