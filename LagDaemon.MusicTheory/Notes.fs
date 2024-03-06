namespace LagDaemon.MusicTheory

open System

module Notes =

    type Octave = int

    type Accidental =
    | Normal
    | Sharp
    | Flat

    type Note = 
    | A of Option<(Octave * Accidental)> 
    | B of Option<(Octave * Accidental)> 
    | C of Option<(Octave * Accidental)> 
    | D of Option<(Octave * Accidental)> 
    | E of Option<(Octave * Accidental)> 
    | F of Option<(Octave * Accidental)> 
    | G of Option<(Octave * Accidental)> 

    let frequency (note: Note) =
        match note with
        | A arg -> match arg with 
                    | Some (o,a) -> match a with
                                    | Normal -> Some( Math.Pow(2, o) * 27.5 )
                                    | Sharp ->  Some( Math.Pow(2, o) * 29.4 )
                                    | Flat ->  Some( Math.Pow(2, o) * 25.96 )
                    | Option.None -> Option.None
        | B arg -> match arg with
                    | Some (o,a) -> match a with
                                    | Normal ->  Some( Math.Pow(2, o) * 30.87 )
                                    | Sharp ->  Some( Math.Pow(2, o) * 16.35 )
                                    | Flat ->  Some( Math.Pow(2, o) * 29.14 )
                    | Option.None -> Option.None
        | C arg -> match arg with
                    | Some (o,a) -> match a with
                                    | Normal ->  Some( Math.Pow(2, o) * 16.35 )
                                    | Sharp ->  Some( Math.Pow(2, o) * 17.32 )
                                    | Flat ->  Some( Math.Pow(2, o) * 30.87 )
        | D arg -> match arg with
                    | Some (o,a) -> match a with
                                    | Normal ->  Some( Math.Pow(2, o) * 18.36 )
                                    | Sharp ->  Some( Math.Pow(2, o) * 19.45 )
                                    | Flat ->  Some( Math.Pow(2, o) * 17.32 )
                    | Option.None -> Option.None
        | E arg -> match arg with
                    | Some (o,a) -> match a with
                                    | Normal ->  Some( Math.Pow(2, o) * 20.60 )
                                    | Sharp ->  Some( Math.Pow(2, o) * 21.83 )
                                    | Flat ->  Some( Math.Pow(2, o) * 19.45 )
                    | Option.None -> Option.None
        | F arg -> match arg with
                    | Some (o,a) -> match a with
                                    | Normal ->  Some( Math.Pow(2, o) * 21.83 )
                                    | Sharp ->  Some( Math.Pow(2, o) * 23.12 )
                                    | Flat ->  Some( Math.Pow(2, o) * 20.60 )
                    | Option.None -> Option.None
        | G arg -> match arg with
                    | Some (o,a) -> match a with
                                    | Normal ->  Some( Math.Pow(2, o) * 24.50 )
                                    | Sharp ->  Some( Math.Pow(2, o) * 25.96 )
                                    | Flat ->  Some( Math.Pow(2, o) * 23.12 )
                    | Option.None -> Option.None
        
        
    let orderOfSharps = seq {
                                    F <| None;
                                    C <| None;
                                    G <| None;
                                    D <| None;
                                    A <| None;
                                    E <| None;
                                    B <| None
                                }

    let orderOfFlats = Seq.rev orderOfSharps

    let modifyNote octave accidental note =
        match note with
        | A _ -> A <| Some(octave, accidental)
        | B _ -> B <| Some(octave, accidental)
        | C _ -> C <| Some(octave, accidental)
        | D _ -> D <| Some(octave, accidental)
        | E _ -> E <| Some(octave, accidental)
        | F _ -> F <| Some(octave, accidental)
        | G _ -> G <| Some(octave, accidental)

