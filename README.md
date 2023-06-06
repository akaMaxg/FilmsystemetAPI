# Filmsystemet, Max Guclu, FS.NET, 2023-06-06

## Introduction 
This console application was created by *Max Guclu* The project was conducted as part of a *C#-course* in a *Fullstack .NET* program at **Chas Academy**.   

## Application structure and Requirements
This Web-API-App was developed in **C#** and utilizes a SQL database along with **Entity Framework** and **Swagger*. The purpose of this application is to create and demonstrate REST-Api through a webapplication.

The program revolves around a few primary objects *Person* and *Genre* *Movie* with list of properties. Furthermore there are a few relational table that joins the primary objects together, e.g. *PersonGenre*. The application also contains a number of functionalities as per required by the assignment:

- ***Det ska gå att lagra personer med grundläggande information om dem som namn och epostadresser.***   
OK,  An API endpoint allows for posting Person-objects - "id": should be omitted   
- ***Systemet ska kunna lagra ett obegränsat antal genres som de gillar. Varje genre ska ha en titel och en kort beskrivning.***   
OK,  An API endpoint allows for posting a Person-Genre entity which connects a person to a genre. All genres have names and description. The GET request for Person-Genres returns an object of Persons.FirstName, Genre.Name and Genre.Description  
- ***Varje person ska kunna vara intresserad av valfritt antal genres***   
Ok,  See above   
- ***Det ska gå att lagra ett obegränsat antal länkar (till filmer) till varje genre för varje person. Om en person lägger in en länk så är den alltså 
kopplad både till den personen och till den genren.***   
OK,  An API endpoint allows for posting a Movie-Person-Genre entity which connects a person to a movie and genre. Another API endpoint allows the user to retrieve information off Persons.id. 
- ***Hämta alla personer i systemet***   
OK,  An API endpoint allows GET request to get all users 
- ***Hämta alla genrer som är kopplade till en specifik person***   
OK   An API endpoint allows GET request to get one users genres 
- ***Hämta alla filmer som är kopplade till en specifik person***
OK   An API endpoint allows GET request to get one users movies 
- ***Lägga in och hämta "rating" på filmer kopplat till en person***   
OK   An API endpoint allows GET request to get one users ratings 
- ***Koppla en person till en ny genre***   
OK   An API endpoint allows POST request to add a genre to a user
- ***Lägga in nya länkar för en specifik person och en specifik genre***   
OK   See previous API-endpoint for MovieGenrePerson 
- ***Få förslag på filmer i en viss genre från ett externt API, t.ex TMDB.Links to an external site.***   
OK   An API call is made to TMDB which allows a query for genres 
- ***Gör ett anrop för varje krav ovan för API:et***   
OK,  See API-calls header.

### Additional functionality
-> Used *Entity Framework*
 
## To run program
1.  Download or clone the project files from the Git repository.  
2.  Open the solution or project in an C# IDE.  
3.  Build the project by pressing F6 or navigating to Build > Build Solution.    

-- *API-Key is hardcoded into url* --  

## Usage
No log-in required. The applications provides the information necessary to test it.

## Contribution  
If you would like to contribute to this project, please feel free to submit a pull request on the Git repository.


## API-calls   
-   GET Genre -> Try it out -> Execute (response 200))   
-   GET Movie -> Try it out -> Execute (response 200))   
-   POST Movie -> Try it out -> Omit "id", add "title" and "releaseYear" -> Execute (response 200)   
-   GET MovieGenrePerson -> Try it out -> Execute (response 200 [unformatted])   
-   POST MovieGenrePerson -> Try it out -> Enter all field that exists in Db -> Execute (respnose 201)   
-   GET Person/All genres for one person -> Try it out -> Enter existing personId = 1 -> Execute (response 200)   
-   GET Person/All ratings for one person -> Try it out -> Enter existing personId = 1 -> Execute (response 200)   
-   GET Person/All movies for one person -> Try it out -> Enter existing personId = 1 -> Execute (response 200)   
-   GET Person/All all persons -> Try it out -> Execute (response 200)   
-   GET Person/Id -> Try it out -> Enter existing personId = 1 -> Execute (response 200)   
-   POST Person/Create new genre for a person -> Try it out -> personId = 2, genreId = 6 -> Execute (response 200)  
-   POST Person -> Try it out -> omit "id", enter firstname, lastname, email -> Execute (Response 200) 
-   GET TMDB/genres-suggestion -> Try it out -> Enter query = eg. Comedy -> Execute (response 200)   

## SQL-Dump
Get the SQL script from: SQLDump_MovieSystem_Magu in root folder
