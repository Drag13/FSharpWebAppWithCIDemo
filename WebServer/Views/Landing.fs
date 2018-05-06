namespace Web.Views

module Landing = 
    open Giraffe.GiraffeViewEngine

    let content id = div [_class "landing"] [rawText ("Hello from Giraffe User# " + id)]

    let view id = Layout.render "OneTimePad" [content id]
    

