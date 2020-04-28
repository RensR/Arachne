## Arachne
Core network tool for a wide range of applications. Let Arachne manage the social networking and focus on creating apps run on top of it.

At the moment, many social interactions rely on services like Facebook, Whatsapp, LinkedIn, Eventbrite, etc.
You probably have many social networks, some (partly) duplicated and many out of date. 
What about the friends made in high school, they are probably on Facebook and a few on LinkedIn, some in your phone with just a phone number, first and last name.
You might have a collection of email addresses in a Google or Apple app. 
What if we could bring all social networks together in one single place.

We introduce Arachne, the web between all social interactions. 
Combine all networks in one single application and give friends permission so view your information in one of the many apps connection with Arachne.
How does it work? Sign up with basic information, your name and email address. 
You get a unique arachne-name that you can share with friends, family, that one guy you met when on that night that neither of you can remember. 
Anyone.
You decide what to share. It could just be your first name and phone number.
It could be your birthday (hello birthday wishes!) or, more personal, birthdate. 

What about giving selected people the option to invite you to events?
Create an event and quickly see all the people you can invite via Arachne, the convenience of a facebook friends list without your data being sold.

Sounds great? Sign ups start soon.

#### CI/CD
[![Build Status](https://dev.azure.com/TheColourOrange/Arachne/_apis/build/status/RensR.Arachne?branchName=master)](https://dev.azure.com/TheColourOrange/Arachne/_build/latest?definitionId=1&branchName=master)

`.net core 3.1` `Vue.js` `Entity Framework` `Azure Functions` `Yarn`
#### How to run

Install the `.net core 3.1` SDK, `Azure Functions Core Tools 3.x` and setup a `MSSQL database` as described below.

##### Database setup using Docker
- Download and install docker [macOS](https://docs.docker.com/docker-for-mac/release-notes/)
- `docker run --name mssql -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Password1!' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-CU8-ubuntu`
- `docker exec -it mssql /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Password1!`
- Create database: 
```
CREATE DATABASE Arachne
GO
```

- Go to 'local.settings.json' in Arachne.API and Arachne.Data and change the property 'ConnectionString' with following: 
`Data Source=localhost;Initial Catalog=Arachne;User ID=sa;Password=Password1!`

make sure you have the `dotnet ef` tools installed

```
dotnet tool install --global dotnet-ef
```
##### Update database
```
cd Arachne.Data
dotnet ef database update
```

##### Run Arachne.API
```
cd Arachne.API
dotnet restore
func host start --port 7071 --pause-on-error --cors=*
```
##### Run Arachne.web

```
cd arachne.web
yarn install
npm run serve
```