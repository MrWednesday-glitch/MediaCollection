# Media Collection
This is an app to catalogue my growing collection of videogames, films, and books. 

### Functionality
> So first of all this app will allow access to a database that holds a representation of my owned videogames, films, and books. It will allow me to browse through them.
> I will be able to add to, remove from, and modify these records.
> The frontend will be ...
> Learned that in production apis often have a standardized json that is returned, specifically for errors. I figured I could use the result pattern for this. I think that there is a specific format that these types of json error responses should have but I will declare that technical debt and come back to it later. It did need a bit of a rewrite of the code I already have because instead of having try-catch blocks to deal with exceptions I had to remove a lot of them and set up checks to see if the result is a failure or success and deal with the details after that.

### Problems I ran into, and how I fixed them.
- When I updated the projects from .Net8.0 to .Net10.0 the line of code that migrates the database threw an exception. Turns out .Net10.0 does not like random guid data as a property in the seeded data in the database.
    - The solution was obvious of course. I hardcoded some simple guids to be entered into the database instead during seeding.
