CREATE DATABASE MC
USE Mc

 CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(30)
)

CREATE TABLE Products(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50),
CategoryId INT FOREIGN KEY REFERENCES Categories(Id)
)
INSERT INTO Products
VALUES('Milk',2),('Yogurt',2)

INSERT INTO Categories
VALUES('Meat'),('Dairy')

select * from Products
select * from Categories


SELECT C.Id 'CategoryId', C.Name 'CategoryName',P.Name 'ProductName' from Categories 
as C LEFT JOIN Products as P ON C.Id=P.CategoryId 
