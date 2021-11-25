module BowlingCalculator.Calculator

type Frame =
    | Score of int
    | Spare
    | Strike

let rec score x =
    match x with
    | "X" -> Strike
    | "-" -> Score 0
    | group when x.Length > 1 ->
        group
        |> Seq.map string
        |> Seq.map score
        |> Seq.choose
            (function
            | Score s -> Some s
            | _ -> None)
        |> Seq.sum
        |> Score
    | _ -> Score 0

let acc (score, prev) x =
    match x with
    | Strike | Spare -> (score, x :: prev)
    | Score s ->
        match prev with
        | [Spare] -> (score + s + 10, [])
        | Strike::tail -> (score + s, [Strike; Score s])
        | [] -> (score + s, [])

let calculate (x: string) =
    x.Split [| ' ' |]
    |> Seq.map score
    |> Seq.fold acc (10, [])
