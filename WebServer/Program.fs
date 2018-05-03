namespace FSharpWebAppWithCIDemo

module Program =
    
    open Microsoft.AspNetCore.Hosting
    open Microsoft.AspNetCore.Builder
    open Giraffe
    open Giraffe.HttpStatusCodeHandlers.Successful

    let exitCode = 0

    [<EntryPoint>]
    let main args =
        WebHostBuilder()
            .UseKestrel()
            .ConfigureServices(fun services-> services.AddGiraffe()|>ignore)
            .Configure(fun (appBuilder: IApplicationBuilder)-> 
                appBuilder.UseGiraffe(GET >=> route "/" >=> OK "hello from Jiraffe"))
            .UseIISIntegration()
            .Build()
            .Run()

        exitCode
