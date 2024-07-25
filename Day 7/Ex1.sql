/* How many tables are in the northwind database? */

SELECT COUNT(*) AS TableCount
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';

/* List all category data */
SELECT * FROM CATEGORIES;

/* List category id and category name of all categories sorted by id */
SELECT CategoryID, CategoryName
FROM Categories
ORDER BY CategoryID;

/* List the id, product name, and unit price of all products */
SELECT ProductID, ProductName, UnitPrice
FROM Products;

/* List the id, product name, and unit price of all products that cost less that $10.00 */

SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE UnitPrice < 10.00;

/* Do a join between categories and products so that you can list the id, product name, unit price, and category name of all products */

SELECT 
    p.ProductID, 
    p.ProductName, 
    p.UnitPrice, 
    c.CategoryName
FROM Products p
INNER JOIN Categories c
    ON p.CategoryID = c.CategoryID;

	/* Challenge:  List the product id, product name, unit price, category name, and  supplier name of all products that cost between %5.00 and $20.00 */

	SELECT 
    p.ProductID, 
    p.ProductName, 
    p.UnitPrice, 
    c.CategoryName, 
    s.CompanyName AS SupplierName
FROM Products p
INNER JOIN Categories c
    ON p.CategoryID = c.CategoryID
INNER JOIN Suppliers s
    ON p.SupplierID = s.SupplierID
WHERE p.UnitPrice BETWEEN 5.00 AND 20.00;