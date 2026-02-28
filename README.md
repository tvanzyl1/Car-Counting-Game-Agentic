# CarCounter

An ASP.NET Core MVC application for counting cars by colour.

Car Counting game is my go-to Hello World for coding. So why not try it through an agent. 

This was purely created through agent promts. I've not looked or touched the code. 
## Prerequisites

- .NET 10 SDK (or later)

## Build

`dotnet build CarCounter.slnx``n
## Run

`dotnet run --project src/CarCounter``n
Then open http://localhost:5267

- Home - default landing page
- Car Counter - click colour buttons to count cars
- Settings - Change the colours of the cars
- /health - returns healthy status

## Test

`dotnet test CarCounter.slnx``n
## CI

GitHub Actions runs build + test on every push/PR to main.

## License

MIT
