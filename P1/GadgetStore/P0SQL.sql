

CREATE TABLE Inventory
(
    ID INT IDENTITY(1, 1) PRIMARY KEY,
    ItemName VARCHAR(100) ,
    ItemPrice Float, 
    ItemLocation VARCHAR(100), 
    ItemQuantity Int
);

GO
INSERT INTO Inventory
    (ItemName, ItemPrice, ItemLocation,ItemQuantity)
VALUES
    ('Samsung 82 Inch TV', 1999.99, 'California',10),
    ('Sony Playstation 5', 599.99, 'New York',10);


CREATE TABLE Account
(
    ID INT IDENTITY PRIMARY KEY,
    FirstName VARCHAR(100) ,
    LastName VARCHAR(100),  
    StreetAddress VARCHAR(100), 
    City VARCHAR(100), 
    State VARCHAR(100) 
);



GO
INSERT INTO Account
    (FirstName, LastName, StreetAddress, City, State)
VALUES
    ('Mike','Tata', '100 Main St','Waterbury','CT'),
    ('John','state', '720 Main St','Hartford','Ny');



CREATE TABLE [Order]
(
    ID INT FOREIGN KEY REFERENCES Account(ID),
    ItemId INT FOREIGN KEY REFERENCES Inventory(ID),
    Cost Float ,
    Quantity VARCHAR(100)
    Time VARCHAR(100)
    
);




