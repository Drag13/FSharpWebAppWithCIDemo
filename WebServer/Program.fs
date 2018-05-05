namespace Web

module Program =
    
    open Microsoft.AspNetCore.Hosting
    open Microsoft.AspNetCore.Builder
    open Giraffe
    open Web.Views

    let exitCode = 0

    [<EntryPoint>]
    let main args =
        WebHostBuilder()
            .UseKestrel()
            .ConfigureServices(fun services-> services.AddGiraffe()|>ignore)
            .Configure(fun (appBuilder: IApplicationBuilder)-> 
                appBuilder.UseGiraffe(GET >=> route "/" >=> htmlView Landing.view))
            .Build()
            .Run()

        exitCode
