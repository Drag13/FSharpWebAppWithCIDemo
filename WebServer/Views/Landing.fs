namespace Web.Views

module Landing = 
    open Giraffe.GiraffeViewEngine

    let content = div [] [rawText "Hello from Giraffe"]

    let view = Layout.render "OneTimePad" [content]
    

