DELETE FROM Basket 
DELETE FROM Inventory 
DELETE FROM Product 
DELETE FROM Receipt 
DELETE FROM Location 
DELETE FROM Customer 
DBCC CHECKIDENT ('dbo.Customer', RESEED, 0);  
DBCC CHECKIDENT ('dbo.Location', RESEED, 0);  
DBCC CHECKIDENT ('dbo.Receipt', RESEED, 0);  
DBCC CHECKIDENT ('dbo.Product', RESEED, 0);  
DBCC CHECKIDENT ('dbo.Inventory', RESEED, 0);  
DBCC CHECKIDENT ('dbo.Basket', RESEED, 0);  
