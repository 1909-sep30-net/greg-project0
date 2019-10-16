DROP TABLE Basket
DROP TABLE Inventory
DROP TABLE Product
DROP TABLE Receipt
DROP TABLE Location
DROP TABLE Customer
--Create Customer Table
GO
CREATE TABLE Customer
(
	CustomerId INT IDENTITY(1,1) PRIMARY KEY, 
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	CustomerAddress NVARCHAR(300) NOT NULL
);
GO

--Create Product Table
GO
CREATE TABLE Product
(
	ProductId INT IDENTITY(1,1) PRIMARY KEY,
	ProductName NVARCHAR(50) NOT NULL,
	ProductDescription NVARCHAR(200) NULL,
	UnitCost money NOT NULL
);
GO

--Create Location Table
--DROP TABLE LOCATION
GO
CREATE TABLE Location
(
	LocationId INT IDENTITY(1,1) PRIMARY KEY,
	LocationName NVARCHAR(50) NOT NULL,
	LocationAddress NVARCHAR(300) NOT NULL
);
GO
--Create Inventory Table (location, product)
GO
--DROP TABLE Inventory
CREATE TABLE Inventory
(
	InventoryId INT IDENTITY(1, 1) PRIMARY KEY,
	LocationId INT NOT NULL, --Foreign Key
	ProductId INT NOT NULL, --Foreign Key
	Quantity INT DEFAULT(0) NOT NULL
);
GO

ALTER TABLE Inventory ADD CONSTRAINT
FK_Inventory_Location FOREIGN KEY (LocationId) REFERENCES Location (LocationId) ON DELETE CASCADE;

ALTER TABLE Inventory ADD CONSTRAINT
FK_Inventory_Product FOREIGN KEY (ProductId) REFERENCES Product (ProductId) ON DELETE CASCADE

--Create Receipt (Order) Table
--DROP TABLE Receipt
GO
CREATE TABLE Receipt
(
	ReceiptId INT IDENTITY(1, 1) PRIMARY KEY,
	LocationId INT NOT NULL, --Foreign Key
	CustomerId INT NOT NULL, --Foreign Key	
	ReceiptTimestamp DateTime NOT NULL 
);
GO

ALTER TABLE Receipt ADD CONSTRAINT
FK_Receipt_Location FOREIGN KEY (LocationId) REFERENCES Location (LocationId) ON DELETE CASCADE

ALTER TABLE Receipt ADD CONSTRAINT
FK_Receipt_Customer FOREIGN KEY (CustomerId) REFERENCES Customer (CustomerId) ON DELETE CASCADE

--Create Basket Table (receipt, product)
--DROP TABLE Basket
CREATE TABLE Basket
(
	BasketId INT IDENTITY(1, 1) PRIMARY KEY,
	ReceiptId INT NOT NULL, --Foreign Key
	ProductId INT NOT NULL, --Foreign Key
	Quantity INT DEFAULT(0) NOT NULL
);
GO

ALTER TABLE Basket ADD CONSTRAINT
FK_Basket_Receipt FOREIGN KEY (ReceiptId) REFERENCES Receipt (ReceiptId) ON DELETE CASCADE;

ALTER TABLE Basket ADD CONSTRAINT
FK_Basket_Product FOREIGN KEY (ProductId) REFERENCES Product (ProductId) ON DELETE CASCADE
