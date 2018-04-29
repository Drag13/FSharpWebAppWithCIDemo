module Tests

open Xunit
open Bll

[<Fact>]
let ``Two greetings should be different`` () =
    let firstGreeting = Say.hello()
    let secondGreeting = Say.hello()

    Assert.NotEqual<string>(firstGreeting, secondGreeting)
