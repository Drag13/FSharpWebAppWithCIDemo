namespace Web

module Program =
    
    open Microsoft.AspNetCore.Hosting
    open Microsoft.AspNetCore.Builder
    open Giraffe
    open Web.Views
    open System.IO
    open System

    let exitCode = 0
    let id() = Guid.NewGuid().ToString()

    [<EntryPoint>]
    let main args =
        WebHostBuilder()
            .UseKestrel()
            .ConfigureServices(fun services-> services.AddGiraffe().AddResponseCompression()|>ignore)
            .Configure(fun (appBuilder: IApplicationBuilder)-> 
                appBuilder
                    .UseResponseCompression()
                    .UseStaticFiles()
                    .UseGiraffe(GET >=> route "/" >=>  warbler (fun _ -> htmlView (Landing.view (id()))) ))
            .UseContentRoot(Path.Combine(Directory.GetCurrentDirectory(), "public"))
            .UseWebRoot(Path.Combine(Directory.GetCurrentDirectory(), "public"))
            .Build()
            .Run()

        exitCode
