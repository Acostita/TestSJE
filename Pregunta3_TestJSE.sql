CREATE TABLE Products ( -- creación de tablas de Productos
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(50),
    Category VARCHAR(50),
    Price INT
);

CREATE TABLE Orders ( -- creación de tablas de Ordenes
    OrderID INT PRIMARY KEY,
    CustomerName VARCHAR(50),
    ProductID INT,
    Quantity INT,
	OrderDate DATE
);


INSERT INTO Products (ProductID, ProductName, Category, Price) -- insertamos valores en la tablas de Products
VALUES (1, 'Laptop','Electronics',800),
        (2, 'Smartphone','Electronics',500),
        (3, 'T-shirt','Clothing',20),
        (4, 'Headphones ','Electronics',50);
		

INSERT INTO Orders (OrderID, CustomerName, ProductID, Quantity, OrderDate) -- insertamos valores en la tablas de Orders
VALUES (101, 'John',1,2,'2022-01-01'),
        (102, 'Jane',3,5,'2023-11-22'),
        (103, 'Robert',2,3,'2023-11-18'),
        (104, 'Sarah',4,2,'2023-11-18'); 

SELECT * FROM Products; -- Vemos nuestra información
SELECT * FROM Orders;

SELECT SUM(Orders.Quantity * Products.Price) AS TotalRevenue -- Calculamos el total de cada veta por producto
FROM Orders JOIN Products ON Orders.ProductID = Products.ProductID -- Hacemos un join por ProductID_para vincular las ventas
WHERE Products.Category = 'Electronics'  -- Seleccionamos la categoría y fijamos las fechas.
    AND Orders.OrderDate >= '2023-01-01'
    AND Orders.OrderDate <= '2023-12-31';
