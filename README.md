# Media Collection
This is an app to catalogue my growing collection of videogames, films, and books. 

### Functionality
> So first of all this app will allow access to a database that holds a representation of my owned videogames, films, and books. It will allow me to browse through them.
> I will be able to add to, remove from, and modify these records.
> The frontend will be ...

### Problems I ran into, and how I fixed them.
> - When I updated the projects from .Net8.0 to .Net10.0 the line of code that migrates the database threw an exception. Turns out .Net10.0 does not like random guid data as a property in the seeded data in the database.
> -- The solution was obvious of course. I hardcoded some simple guids to be entered into the database instead during seeding.
