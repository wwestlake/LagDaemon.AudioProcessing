

module NotesTests
open System
open Xunit
open FsUnit.Xunit
open LagDaemon.MusicTheory.Notes

// Test cases for the frequency function
[<Fact>]
let ``A4 Note Frequency without Accidental`` () =
    let note = A(4, None)
    let expectedFrequency = Math.Pow(2.0, 4.0) * 27.5
    let actualFrequency = frequency note
    actualFrequency |> should equal expectedFrequency

[<Fact>]
let ``B3 Note Frequency with Sharp`` () =
    let note = B(3, Sharp)
    let expectedFrequency = Math.Pow(2.0, 3.0) * 16.35
    let actualFrequency = frequency note
    actualFrequency |> should equal expectedFrequency

[<Fact>]
let ``C5 Note Frequency with Flat`` () =
    let note = C(5, Flat)
    let expectedFrequency = Math.Pow(2.0, 5.0) * 30.87
    let actualFrequency = frequency note
    actualFrequency |> should equal expectedFrequency

// Add more test cases as needed
