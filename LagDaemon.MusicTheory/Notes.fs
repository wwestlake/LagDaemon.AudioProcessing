namespace LagDaemon.MusicTheory

open System

module Notes =

    type Octave = int

    type Accidental =
    | None
    | Sharp
    | Flat

    type Note = 
    | A of Octave * Accidental 
    | B of Octave * Accidental
    | C of Octave * Accidental
    | D of Octave * Accidental
    | E of Octave * Accidental
    | F of Octave * Accidental
    | G of Octave * Accidental

    let frequency (note: Note) =
        match note with
        | A (o,a) -> match a with
                        | None ->  Math.Pow(2, o) * 27.5
                        | Sharp ->  Math.Pow(2, o) * 29.4
                        | Flat ->  Math.Pow(2, o) * 25.96
        | B (o,a) -> match a with
                        | None ->  Math.Pow(2, o) * 30.87
                        | Sharp ->  Math.Pow(2, o) * 16.35
                        | Flat ->  Math.Pow(2, o) * 29.14
        | C (o,a) -> match a with
                        | None ->  Math.Pow(2, o) * 16.35
                        | Sharp ->  Math.Pow(2, o) * 17.32
                        | Flat ->  Math.Pow(2, o) * 30.87
        | D (o,a) -> match a with
                        | None ->  Math.Pow(2, o) * 18.36
                        | Sharp ->  Math.Pow(2, o) * 19.45
                        | Flat ->  Math.Pow(2, o) * 17.32
        | E (o,a) -> match a with
                        | None ->  Math.Pow(2, o) * 20.60
                        | Sharp ->  Math.Pow(2, o) * 21.83
                        | Flat ->  Math.Pow(2, o) * 19.45
        | F (o,a) -> match a with
                        | None ->  Math.Pow(2, o) * 21.83
                        | Sharp ->  Math.Pow(2, o) * 23.12
                        | Flat ->  Math.Pow(2, o) * 20.60
        | G (o,a) -> match a with
                        | None ->  Math.Pow(2, o) * 24.50
                        | Sharp ->  Math.Pow(2, o) * 25.96
                        | Flat ->  Math.Pow(2, o) * 23.12
        
        
        

