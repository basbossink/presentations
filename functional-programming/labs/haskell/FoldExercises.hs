module FoldExercises
where
{-- 
write alternatives to the standard concat, takeWhile and groupBy functions
using a fold 
--} 

fconcat = foldr (++) []

ftakeWhile pred xs = foldr step [] xs 
    where step x ys | pred x = x : ys
                    | otherwise = []

fgroupBy eq xs = foldl step [] xs
    where step [] x = [[x]]
          step ys x = if eq ((head . last) ys) x  then (init ys) ++ [(last ys) ++ [x]]
                      else ys ++ [[x]]
