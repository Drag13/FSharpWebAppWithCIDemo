namespace Web.Views
module Layout = 

    open Giraffe.GiraffeViewEngine

    let render pageTitle page = 
         html [] [
            head [] [
                link [_href "main.css"; _rel "stylesheet"]
                title [] [encodedText pageTitle]
            ]
            body [] [

                nav [_class "nav-component"] [ rawText "FSharpWebAppWithCIDemo" ]

                div [_class "content"] page

                footer [_class "footer-component"] [encodedText "Footer is here 2018"]
            ]
        ]   

