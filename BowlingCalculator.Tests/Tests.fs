module Tests

open System
open Xunit
open BowlingCalculator.Calculator

[<Fact>]
let ``All Strikes`` () =
    let result = calculate "X X X X X X X X X XXX"
    Assert.Equal(300, result)

[<Fact>]
let ``All Spares`` () =
    let result = calculate "5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5"
    Assert.Equal(150, result)

[<Theory>]
[<InlineData("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-", 90)>]
[<InlineData("1- 1- 1- 1- 1- 1- 1- 1- 1- 1-", 10)>]
let ``Some Misses`` input expected =
    let result = calculate input
    Assert.Equal(expected, result)
