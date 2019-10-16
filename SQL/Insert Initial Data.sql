INSERT INTO Customer(FirstName, LastName, CustomerAddress) VALUES
	('Greg', 'Favrot', '12 Main Street Arlington TX 70601'),
	('Ellie', 'Barrilleaux', '34 South Street Lake Charles LA 70721'),
	('Jim', 'Doe', '56 North Boulevard Dallas TX 70707'),
	('Jim', 'Broussard', '78 West Road New Orleans LA 70001')

--SELECT * FROM Customer

INSERT INTO Product(ProductName, ProductDescription, UnitCost) VALUES
	('Coke', 'A tasty beverage','1.49'),
	('Pepsi', 'Inflicts 2d10 posion damage when consumed', '.99'),
	('Water', 'For general hydration', '1.19')

--SELECT * FROM Product

INSERT INTO Location(LocationName, LocationAddress) VALUES
	('Walmart', '123 Main Street Arlington TX 70601'),
	('Kroger', '344 South Street Lake Charles LA 70721')

--SELECT * FROM Location

INSERT INTO Inventory(LocationId, ProductId, Quantity) VALUES
	(1, 1, 15),
	(1, 2, 30),
	(1, 3, 60),

	(2, 3, 400)


--SELECT * FROM Inventory 

INSERT INTO Receipt(LocationId, CustomerId, ReceiptTimestamp) VALUES
	(1, 1, GETDATE()), --Greg, walmart tx
	(1, 3, GETDATE()), --Jim d, walmart tx
	(1, 2, GETDATE()), --Ellie, walmart tx
	(2, 2, GETDATE()) --Ellie, walmart la


--SELECT * FROM Receipt

INSERT INTO Basket(ReceiptId, ProductId, Quantity) VALUES
	--Greg, walmart tx
	(1, 1, 2), --coke
	(1, 3, 30), --water
	
	--Jim d, walmart tx
	(2, 2, 5), --pepsi

	--Ellie, walmart tx
	(3, 1, 20), --coke
	
	--Ellie, walmart la
	(4, 1, 25) --coke

SELECT * FROM Customer
SELECT * FROM Product
SELECT * FROM Location
SELECT * FROM Inventory
SELECT * FROM Receipt
SELECT * FROM Basket

