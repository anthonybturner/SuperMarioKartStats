# SuperMarioKartStats
Web Application that displays and creates statistics for Mario Kart 7-8 driver builds.
Upon first init, the app reads an Excel sheet, which stores Mario Kart statistics. 
EG: Drivers, Bodies(Vehicles/Karts), Tires, Gliders and there related stat values:
Weight, Acceleration, OnRoadTraction, OffRoadTraction, MiniTurbo, GroundSpeed, WaterSpeed and other values.

The Excel sheet was manualy created by myself, using data from the Mario Kart Wikipedia.
Once this data is read into my app, Entity Framework and Object Relational Mappings are created to map the objects to my database (Code First Approach).
Since all parts use the same property statistics, simple programming abstraction and inheritance is used for the Drivers, Bodies, Tires, and Gliders parts.

Next, this data is used in the view (via ViewBags) with select and drop down list elements.

**The next part is a WIP.
Using server-side events, selecting a part, EG. Driver, Body, Tire, and/or Glider, triggers events to calculate the combined statistical points to create a specific level for a given build.

