--Create Customer Table
GO
CREATE TABLE Customer
(
	CustomerId INT IDENTITY(1000,1) PRIMARY KEY, 
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Street NVARCHAR(50) NULL,
	City NVARCHAR(50) NULL,
	State NVARCHAR(50) NULL,
	ZipCode NVARCHAR(10) NULL,
);
GO

--Create Product Table
GO
CREATE TABLE Product
(
	ProductId INT IDENTITY(1000,1) PRIMARY KEY,
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
	LocationId INT IDENTITY(1000,1) PRIMARY KEY,
	LocationName NVARCHAR(50) NOT NULL,
	Street NVARCHAR(50) NULL,
	City NVARCHAR(50) NULL,
	State NVARCHAR(50) NULL,
	ZipCode NVARCHAR(10) NULL,
);
GO
--Create Inventory Table (location, product)
GO
--DROP TABLE Inventory
CREATE TABLE Inventory
(
	InventoryId INT IDENTITY(1000000, 1) PRIMARY KEY,
	LocationId INT NOT NULL, --Foreign Key
	ProductId INT NOT NULL, --Foreign Key
	Quantity INT DEFAULT(0) NOT NULL
);
GO

ALTER TABLE Inventory ADD CONSTRAINT
FK_Inventory_Location FOREIGN KEY (LocationId) REFERENCES Location (LocationId);

ALTER TABLE Inventory ADD CONSTRAINT
FK_Inventory_Product FOREIGN KEY (ProductId) REFERENCES Product (ProductId)

--Create Receipt (Order) Table
--DROP TABLE Receipt
GO
CREATE TABLE Receipt
(
	ReceiptId INT IDENTITY(100000, 1) PRIMARY KEY,
	LocationId INT NOT NULL, --Foreign Key
	CustomerId INT NOT NULL, --Foreign Key
	ReceiptTimestamp DATETIME2 NOT NULL	
);
GO

ALTER TABLE Receipt ADD CONSTRAINT
FK_Receipt_Location FOREIGN KEY (LocationId) REFERENCES Location (LocationId)

ALTER TABLE Receipt ADD CONSTRAINT
FK_Receipt_Customer FOREIGN KEY (CustomerId) REFERENCES Customer (CustomerId)

--Create Basket Table (receipt, product)
--DROP TABLE Basket
CREATE TABLE Basket
(
	BasketId INT IDENTITY(1000000, 1) PRIMARY KEY,
	ReceiptId INT NOT NULL, --Foreign Key
	ProductId INT NOT NULL, --Foreign Key
	Quantity INT DEFAULT(0) NOT NULL
);
GO

ALTER TABLE Basket ADD CONSTRAINT
FK_Basket_Receipt FOREIGN KEY (ReceiptId) REFERENCES Receipt (ReceiptId);

ALTER TABLE Basket ADD CONSTRAINT
FK_Basket_Product FOREIGN KEY (ProductId) REFERENCES Product (ProductId)
