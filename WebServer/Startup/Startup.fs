module Startup

open System.IO
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Logging
open Giraffe
open Giraffe.HttpStatusCodeHandlers.Successful
open Microsoft.Extensions.DependencyInjection

let app() = choose [GET >=> route "/" >=> OK "hello from Jiraffe"]

let webRoot = Path.Combine(Directory.GetCurrentDirectory(), "public")

let configureLogging (loggerBuilder : ILoggingBuilder) =
          loggerBuilder
                .AddFilter(fun lvl -> lvl.Equals LogLevel.Error)
                .AddDebug() |> ignore

let configureServices (services : IServiceCollection) =
          services
                .AddResponseCompression()
                .AddGiraffe() |> ignore

let configureApp webApp =
          fun (app: IApplicationBuilder) -> 
            // if env.IsDevelopment() then app.UseDeveloperExceptionPage() |> ignore
             app
                .UseResponseCompression()
                .UseStaticFiles()
                .UseGiraffe(webApp)
