namespace FSharpWebAppWithCIDemo

module Program =

    open System
    open Microsoft.AspNetCore.Hosting
    open Microsoft.AspNetCore.Builder
    open Startup

    [<EntryPoint>]
    let main _ =
        WebHostBuilder()
            .UseKestrel()
            .Configure(Action<IApplicationBuilder> (configureApp (app())))
            .ConfigureServices(configureServices)
            .UseWebRoot(webRoot)
            .UseContentRoot(webRoot)
            .UseIISIntegration()
            .ConfigureLogging(configureLogging)
            .Build()
            .Run()
        0