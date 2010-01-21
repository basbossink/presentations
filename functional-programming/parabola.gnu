set terminal png nocrop enhanced 8 size 550,550
set output 'parabola.png'
set samples 50, 50
set xzeroaxis linestyle -1
set yzeroaxis linestyle -1
f(x)=x**2-x-6 
plot [-10:10] f(x)
