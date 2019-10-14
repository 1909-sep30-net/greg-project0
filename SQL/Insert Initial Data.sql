INSERT INTO Customer(FirstName, LastName,Street,City,State,ZipCode) VALUES
	('Greg', 'Favrot', '12 Main Street', 'Arlington', 'TX', '70601'),
	('Ellie', 'Barrilleaux', '34 South Street', 'Lake Charles', 'LA', '70721'),
	('Jim', 'Doe', '56 North Boulevard', 'Dallas', 'TX', '70707'),
	('Jim', 'Broussard', '78 West Road', 'New Orleans', 'LA', '70001')

--SELECT * FROM Customer

INSERT INTO Product(ProductName, ProductDescription, UnitCost) VALUES
	('Coke', 'A tasty beverage','1.49'),
	('Pepsi', 'Inflicts 2d10 posion damage when consumed', '.99'),
	('Water', 'For general hydration', '1.19')

--SELECT * FROM Product

INSERT INTO Location(LocationName, Street, City, State, ZipCode) VALUES
	('Walmart', '123 Main Street', 'Arlington', 'TX', '70601'),
	('Walmart', '344 South Street', 'Lake Charles', 'LA', '70721')

--SELECT * FROM Location

INSERT INTO Inventory(LocationId, ProductId, Quantity) VALUES
	(1000, 1000, 15),
	(1000, 1001, 30),
	(1000, 1002, 60),

	(1001, 1002, 400)


--SELECT * FROM Inventory 

INSERT INTO Receipt(LocationId, CustomerId, ReceiptTimestamp) VALUES
	(1000,1000,GETDATE()), --Greg, walmart tx
	(1000, 1002,GETDATE()), --Jim d, walmart tx
	(1000, 1001,GETDATE()), --Ellie, walmart tx
	(1001, 1001,GETDATE()) --Ellie, walmart la


--SELECT * FROM Receipt

INSERT INTO Basket(ReceiptId, ProductId, Quantity) VALUES
	--Greg, walmart tx
	(100000, 1000, 2), --coke
	(100000, 1002, 30), --water
	
	--Jim d, walmart tx
	(100001, 1001, 5), --pepsi

	--Ellie, walmart tx
	(100002, 1001, 20), --coke
	
	--Ellie, walmart la
	(100003, 1001, 25) --coke

SELECT * FROM Customer
SELECT * FROM Product
SELECT * FROM Location
SELECT * FROM Inventory
SELECT * FROM Receipt
SELECT * FROM Basket