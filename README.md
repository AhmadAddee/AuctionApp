# AuctionApp

A simplified version of a system for auctions, where users can jregister and then post auctions, and bid on other people's aucitons.

The program is an ASP.NET MVC application, version Core 6.0.
The application has a three-layer architecture, with a clear division between data layer (Persistence), business logic layer (Core or BLL) and presentation layer.
The boundary lines between the different layers are represented by two interfaces (for each object type or entity).
Dependency injection is used to provide a layer access to the underlying layer's implementation.
The presentations layer is implemented with MVC as well as view-models.
Entity Framework is used such as ORM in the data layer. EF-classes are written so that BidDb gets a FK to AuctionDb in the database.
Identity is used for login, logout, and registing of new users. User database is a separate one.
