# Storied API

## Overview
The Storied API is an ASP.NET Web Application designed to manage and maintain information about people. 
This API provides a set of endpoints for performing various actions related to person records, including retrieval, creation, and updates.

## Table of Contents
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Configuration](#configuration)
- [The Project](#theproject)
  - [Assumptions](#assumptions)
  - [Challenges](#challenges)
  - [Next Steps](#nextsteps)

## Getting Started
This section provides information on setting up and running the Storied API locally or in your own environment.

### Prerequisites
Before you begin, ensure you have met the following requirements:
- [.NET SDK](https://dotnet.microsoft.com/download/dotnet) installed
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) or [Visual Studio Code](https://code.visualstudio.com/) (or your preferred code editor)

### Installation
1. Clone the repository:
   ```shell
   git clone [https://github.com/yourusername/storied-api.git](https://github.com/horoxix/storied-api.git)https://github.com/horoxix/storied-api.git
   ```
2. Navigate to the project directory
   ```shell
   cd storied-api
   ```
3. Install the required dependencies
    ```shell
   dotnet restore
    ```
4. Build the application
    ```shell
   dotnet build
    ```

## Usage
To run the Storied API, follow these steps:

1. Run the application
   ```shell
   dotnet run
   ```
The API will be accessible at https://localhost:5001 by default, but you can configure the port and other settings in the app settings.

## API Endpoints

The Storied API provides full swagger documentation for all endpoints. To view after running, navigate to : https://localhost:7143/swagger/index.html

## Configuration
The Storied API can be configured using environment variables or an appsettings.json file. Refer to the configuration section in the documentation for details on available settings.
A full postman collection is included in the repository to import and use.

## The Project
### Assumptions
There were a few assumptions I made when completing this challenge. For brevity, I will list them out here.
1. GetPersonId - (Assumed this was GetPersonById and ran with that, as I wasn't sure the purpose of Getting a Person's Id).
2. GetAll - (Assumed that we wouldn't want to query the full database every single time and added filters, such as dates, locations etc.)
3. Ids - (Went ahead and used Guids for all Ids instead of integers or longs)
4. Auth - (Did not apply any auth for the challenge to make testing it easier and didn't see any in the requirements, but would love to, given more time)

### Challenges
I will also list the challenges and my responses to them here.
1. Time - (I'm sure this is a common one but I have had a very busy holiday weekend full of work, so I fit this in my free time and would love to have had more to put towards it)
2. Integration Tests - (I know firsthand the value of solid integration tests and so was determined to get them working, the initial WebApplication Program.cs made it difficult so I added a Startup that I can initialize in the Test Server)
3. Domain Entities - (I originally had a very clean and simplified version containing the initial recommended structure for "Person". Once switching to more complex and robust classes for things such as gender, location etc, it really ballooned and became more complex. It was really exciting and I have so many more ideas I wanted to implement)

### Next Steps
There are many next steps I wanted and still want to take. I tried to give as robust of a system as possible without going too deep.
1. Domain Entities - (I would implement this much more complex.
   a. Location - (City, State, Country, etc.) more entities and relationships than just a locationId and name
   b. Add relationships between Persons. If this was a full-fledged family tree app, It would only make sense to do this.
     x. I started this with EventType "Marriage" but didn't take it any further.
   c.Repositories and endpoints for the various entities. Right now it's all done via the PersonController and PersonRepository but in a fully-fledged system we would have ways to insert/update Genders, Cities, etc.
 2. Queries - There are places where we can add indexes for increased performance as well as separate queries from the large "Include" chains to find the best performance sweet spot.
 3. Logging - Right now the logging is very plain and while it works in the console I would implement logging to various platforms (local files, databases, appinsights, etc.)
 4. Domain Layer - (I didn't need to currently, but in the future I would separate the Handlers from the Repositories via a domain layer.
   a. This would allow for mocking and testing of the domain services.
   b. This would be a better separation as having the handlers touching the data layer can grow into something more problematic.
 5. Integration Test Framework - I want to expand this not only in number and quality of tests(edge cases etc.) but in a more robust framework. Right now there is some fair hardcoding being done via the DataSeed, but it works really well as-is. In the long term I would make perhaps a common library to share Integration test framework features amongst projects.


### Conclusion
Overall, I had a ton of fun with this project. I am a big history nerd, and have done lots of my own personal genealogy so just playing around in the space was exciting. I wanted to spend more time on it but due to work, and hearing from the recruitment team that we want to move quickly on this, I wanted to get it to you as soon as possible. Thank you for the opportunity and I hope to hear from you soon!
