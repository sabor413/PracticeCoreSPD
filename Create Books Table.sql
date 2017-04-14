CREATE TABLE Books
(
ID int IDENTITY(1,1) PRIMARY KEY,
ISBN varchar(255) NOT NULL,
Title varchar(255) NOT NULL,
Publisher varchar(255) NOT NULL,
Author varchar(255) NOT NULL,
Price decimal NOT NULL,
Source varchar(255) NOT NULL,
PurchaseUrl varchar(255)
)