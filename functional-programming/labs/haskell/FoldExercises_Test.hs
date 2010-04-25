module FoldExercises_Test
where

import Test.QuickCheck
import Data.List(groupBy)

import qualified FoldExercises as F

prop_concat xs = concat xs == F.concat xs
    where types = xs ::[[Int]]

prop_takeWhile predicate xs = 
    takeWhile predicate xs == F.takeWhile predicate xs
    where types = xs::[Int]

prop_groupBy predicate xs = groupBy predicate xs == F.groupBy predicate xs
    where types = xs::[Int]

equal x y = (y `mod` 3) == 0 

intListChecks = [ 
              prop_takeWhile (\x -> x < 37),
              prop_takeWhile (\x -> x > 37),
              prop_takeWhile (\x -> x /= 37),
              prop_groupBy (==),
              prop_groupBy (/=),
              prop_groupBy equal
            ]
testables = map quickCheck intListChecks
allTestables = (quickCheck prop_concat):testables
main = do
  sequence_ allTestables
