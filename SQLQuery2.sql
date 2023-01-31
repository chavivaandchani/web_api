
create table Users
(
ID int IDENTITY(1,1) PRIMARY KEY,
Name nvarchar (20) not null,
Password nvarchar (15) not null,
FirstName nvarchar (30),
LastName nvarchar (30) 
)


CREATE TABLE Category
(
ID int IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(50) NOT NULL,
)


create table Product
(
ID int IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(50) not null,
Description nvarchar(100) not null,
CategoryID int not null constraint products_categoryID_fk references Category (ID),
Color nvarchar(50) not null,
Price int not null,
ImageUrl nvarchar(100) not null
)


CREATE TABLE Orders(
ID int IDENTITY(1,1) PRIMARY KEY,
Date date not null,
Price int not null,
UserId int not null constraint Orders_UserID_fk references Users (ID),
)

CREATE TABLE OrderItem
(
ItemID int IDENTITY(1,1) PRIMARY KEY,
ProductID int constraint OrderItem_ProductID_fk references Product(ID),
OrderId int constraint OrderItem_OrderId_fk references Orders(ID),
Quantity int not null

)