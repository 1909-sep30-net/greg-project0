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
GO
CREATE TABLE Location
(
	LocationId INT IDENTITY(1000,1) PRIMARY KEY,
	LocationName NVARCHAR(50) NOT NULL,
	Street NVARCHAR(50) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	State NVARCHAR(50) NOT NULL,
	ZipCode NVARCHAR(10) NOT NULL,
);
GO
--Create Inventory Table (location, product)
GO
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

--Create Reciept (Order) Table
GO
CREATE TABLE Reciept
(
	RecieptId INT IDENTITY(100000, 1) PRIMARY KEY,
	LocationId INT NOT NULL, --Foreign Key
	CustomerId INT NOT NULL, --Foreign Key
	RecieptTimestamp DATETIME2 NOT NULL	
);
GO

ALTER TABLE Reciept ADD CONSTRAINT
FK_Reciept_Location FOREIGN KEY (LocationId) REFERENCES Location (LocationId)

ALTER TABLE Reciept ADD CONSTRAINT
FK_Reciept_Customer FOREIGN KEY (CustomerId) REFERENCES Customer (CustomerId)

--Create Basket Table (reciept, product)
GO
CREATE TABLE Basket
(
	BasketId INT IDENTITY(1000000, 1) PRIMARY KEY,
	RecieptId INT NOT NULL, --Foreign Key
	ProductId INT NOT NULL, --Foreign Key
	Quantity INT DEFAULT(0) NOT NULL
);
GO

ALTER TABLE Basket ADD CONSTRAINT
FK_Basket_Reciept FOREIGN KEY (RecieptId) REFERENCES Reciept (RecieptId);

ALTER TABLE Basket ADD CONSTRAINT
FK_Basket_Product FOREIGN KEY (ProductId) REFERENCES Product (ProductId)
