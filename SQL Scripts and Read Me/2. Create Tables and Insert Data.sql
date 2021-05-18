USE eHarambee
GO

CREATE TABLE Categories(CategoryID INT PRIMARY KEY IDENTITY(1,1), CategoryName VARCHAR(200) NOT NULL);
INSERT INTO Categories(CategoryName)  VALUES('Computers');
INSERT INTO Categories(CategoryName)  VALUES('TV and Video');
INSERT INTO Categories(CategoryName)  VALUES('Audio and Home Theater');
INSERT INTO Categories(CategoryName)  VALUES('Cameras');


CREATE TABLE Products(ProductID INT PRIMARY KEY IDENTITY(1,1), ProductName VARCHAR(200) NOT NULL, 
ProductDescription VARCHAR(MAX), CategoryID INT FOREIGN KEY REFERENCES Categories(CategoryID), Price Money NOT NULL);
INSERT INTO Products(ProductName, ProductDescription, CategoryID, Price) VALUES('Hisense-32-hd-smart-tv','hisense-32-hd-smart-tv-with-digital-tune',2,3500.00)
INSERT INTO Products(ProductName, ProductDescription, CategoryID, Price) VALUES('Nesty-1080p-full-hd-led-32-tv','nesty-1080p-full-hd-led-32-tv-nesty-100w-sound-bar-with-sub-woofer-combo',2,3099.00)
INSERT INTO Products(ProductName, ProductDescription, CategoryID, Price) VALUES('Samsung-55-display','samsung-55-display-crystal-processor-4kuhd-tv',2,5200.00)
INSERT INTO Products(ProductName, ProductDescription, CategoryID, Price) VALUES('Olympus-e-m1ii-body-black','olympus-e-m1ii-body-black-ez-m1240pro-black-incl-charger-battery-lens-hood',4,71697)
INSERT INTO Products(ProductName, ProductDescription, CategoryID, Price) VALUES('Nikon-b500-ultra-zoom','nikon-b500-ultra-zoom-digital-camera-black',4,3580)
INSERT INTO Products(ProductName, ProductDescription, CategoryID, Price) VALUES('Lowepro-adventura','lowepro-adventura-sh-160-ll-camera-shoulder-bag',4,699)
INSERT INTO Products(ProductName, ProductDescription, CategoryID, Price) VALUES('Microlab-m105r-2-1','microlab-m105r-2-1-subwoofer-speaker',3,1500)
INSERT INTO Products(ProductName, ProductDescription, CategoryID, Price) VALUES('Aiwa-3000w-5-1ch','aiwa-3000w-5-1ch-surround-sound',3,9000)
INSERT INTO Products(ProductName, ProductDescription, CategoryID, Price) VALUES('Monitor-audio-silver-300','monitor-audio-silver-300-system-speaker-package-black-gloss',3,8952)

CREATE TABLE Customers(CustomerID INT PRIMARY KEY IDENTITY(1,1) NOT NULL, CustomerNo VARCHAR(150) NOT NULL, CustomerIDNo VARCHAR(100) NOT NULL, CustomerName VARCHAR(200)
, CustomerSurname VARCHAR(200) NOT NULL)

INSERT INTO Customers(CustomerNo, CustomerIDNo, CustomerName, CustomerSurname) VALUES('A1000','000000000001','Jonh','Whick')
INSERT INTO Customers(CustomerNo, CustomerIDNo, CustomerName, CustomerSurname) VALUES('A1001','000000000112','Sylvester','Stallion')
INSERT INTO Customers(CustomerNo, CustomerIDNo, CustomerName, CustomerSurname) VALUES('A1002','000000000145','Jean Clued','van Daame')
INSERT INTO Customers(CustomerNo, CustomerIDNo, CustomerName, CustomerSurname) VALUES('A1003','000000000158','Cristiano','Ronaldo')
INSERT INTO Customers(CustomerNo, CustomerIDNo, CustomerName, CustomerSurname) VALUES('A1004','000000000148','Lionel','Messi')
INSERT INTO Customers(CustomerNo, CustomerIDNo, CustomerName, CustomerSurname) VALUES('A1005','000000000785','Eden','Hazard')


CREATE TABLE Bundles (BundleID INT PRIMARY KEY IDENTITY(1,1), BungleName VARCHAR(150), BundleDescription VARCHAR(255), DiscountPerc float, Cost money)
INSERT INTO Bundles(BungleName, BundleDescription, DiscountPerc) VALUES('Bundle01','3 TVs, 2 Radios and 1 Camera',0.25)
INSERT INTO Bundles(BungleName, BundleDescription, DiscountPerc) VALUES('Bundle02','2 TVs and 3 Radios',0.11)
INSERT INTO Bundles(BungleName, BundleDescription, DiscountPerc) VALUES('Bundle03','3 TVs and 3 Camera',0.24)
INSERT INTO Bundles(BungleName, BundleDescription, DiscountPerc) VALUES('Bundle04','2 Radios and 5 Camera',0.15)

CREATE TABLE ProductBundles(ProductID INT FOREIGN KEY REFERENCES Products(ProductID), BundleID INT FOREIGN KEY REFERENCES Bundles(BundleID), Quantity INT NOT NULL)

INSERT INTO ProductBundles(ProductID, BundleID, Quantity) VALUES(1,	1,	3)
INSERT INTO ProductBundles(ProductID, BundleID, Quantity) VALUES(8,	1,	1)
INSERT INTO ProductBundles(ProductID, BundleID, Quantity) VALUES(9,	1,	1)
INSERT INTO ProductBundles(ProductID, BundleID, Quantity) VALUES(3,	2,	1)
INSERT INTO ProductBundles(ProductID, BundleID, Quantity) VALUES(1,	2,	1)	
INSERT INTO ProductBundles(ProductID, BundleID, Quantity) VALUES(7,	2,	2)
INSERT INTO ProductBundles(ProductID, BundleID, Quantity) VALUES(8,	2,	1)
INSERT INTO ProductBundles(ProductID, BundleID, Quantity) VALUES(2,	3,	3)
INSERT INTO ProductBundles(ProductID, BundleID, Quantity) VALUES(5,	3,	2)
INSERT INTO ProductBundles(ProductID, BundleID, Quantity) VALUES(6,	3,	1)
INSERT INTO ProductBundles(ProductID, BundleID, Quantity) VALUES(8,	4,	1)
INSERT INTO ProductBundles(ProductID, BundleID, Quantity) VALUES(7,	4,	1)
INSERT INTO ProductBundles(ProductID, BundleID, Quantity) VALUES(5,	4,	2)
INSERT INTO ProductBundles(ProductID, BundleID, Quantity) VALUES(6,	1,	1)
