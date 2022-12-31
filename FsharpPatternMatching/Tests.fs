module Tests

open System
open System.Collections.Generic
open Xunit

[<Fact>]
let ``Pattern Matching Simple Example`` () =
    (* Let's try to create a name constant function*)
    
    (*
        This function returns the character equivalent 
        for 
        1. π = pi = 3.14
        2. e = Euler's number = 2.71 
        3. ß = Bernstein's constant = 0.28
    *)
    let letMeGuessTheConstant constant = 
        match constant with 
        | 3.14 -> "π"
        | 2.71 -> "e"
        | 0.28 -> "ß"
        | _ -> "Not Available"   (* This is a wildcard symbol that matches all possible values *) 

    Assert.Equal(letMeGuessTheConstant 3.14, "π")
    Assert.Equal(letMeGuessTheConstant 2.71, "e")
    Assert.Equal(letMeGuessTheConstant 0.28, "ß")
    Assert.Equal(letMeGuessTheConstant 234234, "Not Available")

[<Fact>]
let ``Pattern Matching When All Possible Cases Aren't Covered`` () = 
     
     let letterIndex l = 
        match l with 
        | 'a' -> 1 
        | 'b' -> 2 

     Assert.Throws<MatchFailureException>(fun () -> letterIndex 'c' |> ignore) 

[<Fact>]
let ``Pattern Matching With Guard Expressions``() =
    
    let isYourAgeLegalAdultHood (age:float) :string = 
        match age with 
        | x when x < 0.0 -> "You're not even born yet."
        | x when x > 0 && x <0.99 -> "Approxiametly less than 1 year old."  
        | x when x >= 1 && x <= 17 ->  "Still not in legal age."    
        | x when x >= 18 && x <= 60 ->  "Legal Age."    
        | x when x >= 61 && x <= 80 ->  "Congrats still alive."    
        | x when x >= 81 && x <= 100 ->  "Legal age but seniors."   
        | x when x >= 100 ->  "Legal age hopefully your still alive."     
        | _ -> "Age unable to proces."     

    let isLegal1 = isYourAgeLegalAdultHood 0.9
    Assert.Equal(isLegal1, "Approxiametly less than 1 year old.")

    let isLegal2 = isYourAgeLegalAdultHood 10 
    Assert.Equal(isLegal2, "Still not in legal age.")

    let isLegal3 = isYourAgeLegalAdultHood 20 
    Assert.Equal(isLegal3, "Legal Age.")

    let isLegal4 = isYourAgeLegalAdultHood 30
    Assert.Equal(isLegal4, "Legal Age.")

    let isLegal5 = isYourAgeLegalAdultHood 40
    Assert.Equal(isLegal5, "Legal Age.")

    let isLegal6 = isYourAgeLegalAdultHood 50 
    Assert.Equal(isLegal6, "Legal Age.")

    let isLegal7 = isYourAgeLegalAdultHood 80 
    Assert.Equal(isLegal7, "Congrats still alive.")

    let isLegal8 = isYourAgeLegalAdultHood 90
    Assert.Equal(isLegal8, "Legal age but seniors.")

    let isLegal9 = isYourAgeLegalAdultHood 150
    Assert.Equal(isLegal9, "Legal age hopefully your still alive.")
    
[<Fact>]
let ``Pattern Matching As Keyword``() = 
    
    let isOdd num1 = 
        match num1 with 
        | (num1)  as n -> 
                match (n % 2 = 1) with 
                | true -> "It is odd"
                | false -> "It is even"

    let resultEven = isOdd 2
    let resultOdd = isOdd 3

    Assert.Equal("It is odd", resultOdd)


       

        



