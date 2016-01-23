//
// Author:
//     Nicolas VERINAUD <n.verinaud@gmail.com>
//
// Copyright (c) 2016 Nicolas VERINAUD. All Rights Reserved.
//

open System
open System.Net
open System.Collections.Specialized
open FSharp.Data

// 1. POST http://www.sncf.com/fr/itineraire with params
// 2. Get the cookies
// 3. GET http://www.sncf.com/fr/horaires-info-trafic/trajet/resultats with the cookies

let f =
    let cookieContainer = CookieContainer()
    let url = "http://www.sncf.com/fr/itineraire"
    Http.Request (
        url, 
        query = [
            "datemax", ""; 
            "sncfdirect", ""; 
            "gareOrigne", "Mutzig"; 
            "codeOrigine", ""; 
            "gareDestination", "Strasbourg";
            "codeDestination", "";
            "date", "25/01/2016";
            "timeSettings", "0";
            "heure", "0730";
            "gareVia", "";
            "codeVia", ""],
        cookieContainer = cookieContainer,
        httpMethod = "post"
    ) |> ignore

    let response = Http.RequestString ("http://www.sncf.com/fr/horaires-info-trafic/trajet/resultats", cookieContainer = cookieContainer)
    response

[<EntryPoint>]
let main argv = 
    printfn "%s" f
    0
