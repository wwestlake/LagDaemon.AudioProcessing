

module NotesTests
open System
open FsUnit
open NUnit.Framework
open LagDaemon.MusicTheory.Notes

// Test cases for the frequency function

[<SetUpFixture>]
type NoteFrequencyTEsts() =
    inherit FSharpCustomMessageFormatter()


[<Test>]
let ``A4 Note Frequency without Accidental`` () =
    let note = A <| Some (4, Normal)
    let expectedFrequency = Math.Pow(2.0, 4.0) * 27.5
    let actualFrequency = frequency note
    match actualFrequency with
    | Some (f) -> f |> should equal expectedFrequency
    | None -> should failwith "Out of range" |> ignore

[<Test>]
let ``B3 Note Frequency with Sharp`` () =
    let note = B <| Some (3, Sharp)
    let expectedFrequency = Math.Pow(2.0, 3.0) * 16.35
    let actualFrequency = frequency note
    match actualFrequency with
    | Some (f) -> f |> should equal expectedFrequency
    | None -> should failwith "Out of range" |> ignore

[<Test>]
let ``C5 Note Frequency with Flat`` () =
    let note = C <| Some (5, Flat)
    let expectedFrequency = Math.Pow(2.0, 5.0) * 30.87
    let actualFrequency = frequency note
    match actualFrequency with
    | Some (f) -> f |> should equal expectedFrequency
    | None -> should failwith "Out of range" |> ignore

// Add more test cases as needed

[<Test>]
let ``Order of Sharps should contain F C G D A E B`` () =
    // Arrange
    let expectedOrder = [ F None; C None; G None; D None; A None; E None; B None ]

    // Act
    let actualOrder = orderOfSharps |> Seq.toList

    // Assert
    actualOrder |> should equal expectedOrder

[<Test>]
let ``Order of Flats should be reversed Order of Sharps`` () =
    // Arrange
    let expectedOrder = [ B None; E None; A None; D None; G None; C None; F None ]

    // Act
    let actualOrder = orderOfFlats |> Seq.toList

    // Assert
    actualOrder |> should equal expectedOrder

[<Test>]
let ``Modify Note should update the note with the provided octave and accidental`` () =
    // Arrange
    let inputNote = F None
    let octave = 4
    let accidental = Sharp

    // Act
    let modifiedNote = modifyNote octave accidental inputNote

    // Assert
    modifiedNote |> should equal (F (Some (4, Sharp)))


