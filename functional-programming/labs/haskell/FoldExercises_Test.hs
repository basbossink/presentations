module FoldExercises_Test
where

import Test.QuickCheck
import Data.List(groupBy)

import FoldExercises

prop_concat xs = concat xs == fconcat xs
    where types = xs ::[[Int]]

predicate x = x < 37
prop_takeWhile xs = takeWhile predicate xs == ftakeWhile predicate xs
    where types = xs::[Int] 

prop_groupBy predicate xs = groupBy predicate xs == fgroupBy predicate xs
    where types = xs::[Int]

equal x y = (y `mod` 3) == 0 
intListChecks = [ 
              prop_takeWhile,
              prop_groupBy (==),
              prop_groupBy (/=),
              prop_groupBy equal
            ]
testables = map quickCheck intListChecks
allTestables = (quickCheck prop_concat):testables
main = do
  sequence_ allTestables
