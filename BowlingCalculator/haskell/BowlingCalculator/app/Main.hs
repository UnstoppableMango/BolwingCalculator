module Main where

import Data.List.Split (splitOn)

getInput :: String -> IO [String]
getInput f = map read . lines <$> readFile f

calculate :: [String] -> Integer
calculate = sum . map read

main :: IO ()
main = do
    input <- getInput "./input.txt"
    print $ calculate input
    -- print . calculate <$> getInput ""
