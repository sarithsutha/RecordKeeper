[![Build status](https://ci.appveyor.com/api/projects/status/a5qyif75sc3gxwoo?svg=true)](https://ci.appveyor.com/project/sarithsutha/recordkeeper)
[![codecov](https://codecov.io/gh/sarithsutha/RecordKeeper/branch/master/graph/badge.svg)](https://codecov.io/gh/sarithsutha/RecordKeeper)

# Record Keeper
A simple record keeping application with a Web API and a CLI

## Assumptions made to keep the solution simple: 
- None of the delimiters (commas, pipes and spaces) appear anywhere in the data values themselves.
- The delimited files are not too large.
- The file are of valid format, for simplicity file format is not validated.
- No authentication needed for the API.

## Solution Structure
To make the application testable and maintainable, the solution was structured using Onion Architecture.
And the concerns are clearly separated into layers.

![Record Keeper Solution Structure](Images/SolutionStructure.png)

|Project|Description|
|-------|-----------|
|RecordKeeper.Core | It forms the core of the application. It is meant for the domain entities.|
|RecordKeeper.Repo | This layer is for handling the persistence of data to a database. For now, it would be an in memory data store.|
|RecordKeeper.Service | The layer where the business logic resides.|
|RecordKeeper.API | Restful API for other applications to consume.|
|RecordKeeper.CLI | The interactive command line interface for the application.|
|RecordKeeper.Tests | The test project for unit tests.|
|RecordKeeper.Utility | This layer is home for the utility and the helper classes used by any of the layers.|

## Testing
For testing the APIs, if Postman is being used the request collection is made available in this repository.
Look for the file "postman_collection.json" in the root of the repository.