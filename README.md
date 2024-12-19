[![Version](https://img.shields.io/nuget/vpre/mcs.ServiceUtilities.svg)](https://www.nuget.org/packages/mcs.ServiceUtilities/)
[![Downloads](https://img.shields.io/nuget/dt/mcs.ServiceUtilities.svg)](https://www.nuget.org/packages/mcs.ServiceUtilities/)
[![Codecov](https://img.shields.io/codecov/c/github/mcsEngineeringAg/ServiceUtilities)](https://app.codecov.io/gh/mcsEngineeringAg/ServiceUtilities)
# ServiceUtilities
The project contains helper functionality for building .Net REST Services.

## How To Use the nuget
### Logging
Adding a consecutive number scheme to your Serilog log file. This facilitates analyzing the log file since you can clearly identify service restarts in your log file.
- add the following source code:
```
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration.Enrich.With<MessageIdEnricher>();
});
```
- extend your logging configuration with the ```MessageId```:
```
"outputTemplate": "{MessageId}|{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{SourceContext}] [ReqId: {RequestId}] {Message}{NewLine}{Exception}"
```
example output:
```
2228|2024-12-13 08:16:08.547 +01:00|DBG|Microsoft.AspNetCore.Server.Kestrel.Connections|Connection id ""0HN8R8M70T9KT"" stopped.
2229|2024-12-13 08:16:08.553 +01:00|DBG|Microsoft.AspNetCore.Server.Kestrel.Connections|Connection id ""0HN8R8M70T9KS"" stopped.
1|2024-12-13 08:12:50.455 +01:00|INF|Trumpf.TruTops.FluxRestService.Program|FluxRESTServiceVersion: 1.0.0.0
2|2024-12-13 08:12:50.458 +01:00|DBG|Microsoft.Extensions.Hosting.Internal.Host|Hosting starting
3|2024-12-13 08:12:50.500 +01:00|INF|Man.Dapr.Sidekick.DaprSidecarHost|Dapr Process Status Change: Started 
```

## Architecture documentation
- [Architecture documentation](arcDoc/arc42/01_introduction_and_goals.md)

## Contributing
- Programming guidelines: https://codingconventions.mcscorp.ch/richtlinien-csharp-extended.html