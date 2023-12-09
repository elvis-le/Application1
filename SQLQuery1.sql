Create database FPTBook;

USE FPTBook;

-- Create the Admin table
CREATE TABLE Admin (
AdminEmail Varchar(50) Primary key,
AdminFullname NVARCHAR(30) NOT NULL,
AdminPassword VARCHAR(300) NOT NULL,
AdminImage Varchar(100)
);


-- Create the Customer table
CREATE TABLE Customer (
    CustomerEmail VARCHAR(50) PRIMARY KEY,
    CustomerFullname NVARCHAR(30) NOT NULL,
    CustomerPassword VARCHAR(300) NOT NULL,
	CustomerImage Varchar(100), 
    CustomerAddress NVARCHAR(100) NULL,
    CustomerPhone VARCHAR(12) NULL,
	CustomerBirthday Datetime,
	CustomerSex Varchar(15),
	CustomerSection INT not null default 1
);

-- Create the StoreOwner table
CREATE TABLE StoreOwner (    
    OwnerEmail VARCHAR(50) PRIMARY KEY,
    OwnerFullname NVARCHAR(30) NOT NULL,
    OwnerPassword VARCHAR(300) NOT NULL,
	OwnerImage Varchar(100), 
    OwnerAddress NVARCHAR(50) NOT NULL,
    OwnerPhone VARCHAR(12) NULL,
	OwnerBirthday Datetime,
	OwnerSex Varchar(15),
	OwnerSection INT,
);

-- Create the Category table
CREATE TABLE Category (
	CategoryID VARCHAR(5) PRIMARY KEY,
    CategoryName NVARCHAR(50) NOT NULL,
);

-- Create the Author table
CREATE TABLE Author (
    AuthorID VARCHAR(5) PRIMARY KEY,
    AuthorName NVARCHAR(30) NOT NULL
);

-- Create the Publisher table
CREATE TABLE Publisher (
    PublisherID int identity(1, 1) not null primary key,
	PublisherName NVarchar(50)
);

-- Create the Book table
CREATE TABLE Book (
    BookID VARCHAR(10) PRIMARY KEY,
    BookTitle NVARCHAR(30) NOT NULL,
    BookPrice INT NOT NULL DEFAULT 10,
    BookAuthor NVARCHAR(50) NOT NULL,
    BookDetails NVARCHAR(500) NULL,
    AuthorID VARCHAR(5) NOT NULL,
    PublisherID INT NOT NULL,
    CONSTRAINT fk_Book_Publisher FOREIGN KEY (PublisherID) REFERENCES Publisher(PublisherID),
	CONSTRAINT fk_Book_Author FOREIGN KEY (AuthorID) REFERENCES Author(AuthorID)
);

-- Create the Category_Book table
CREATE TABLE Category_Book (
	CategoryID VARCHAR(5) Not null,
    BookID VARCHAR(10) not null,
	Constraint fk_Category_Book  FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId),
    CONSTRAINT fk_Book_Category FOREIGN KEY (BookID) REFERENCES Book(BookID),
);

--Create Cart table
Create table Cart(
    BookID VARCHAR(10) Not null,	
    CustomerEmail VARCHAR(50) Not null,
	Number int not null default 1,
	Constraint fk_Cart_Book foreign key (BookID) references Book(BookID),
	Constraint fk_Cart_Customer foreign key (CustomerEmail) references Customer(CustomerEmail)
);

--Create Order table
Create table [Order](
	OrderID INT PRIMARY KEY IDENTITY(1,1),
    BookID VARCHAR(10) NOT NULL,
    CustomerEmail VARCHAR(50) NOT NULL,
    OrderNumber INT NOT NULL,
    OrderPrice INT NOT NULL,
    OrderPayment VARCHAR(20) NOT NULL,
    CONSTRAINT fk_Order_Book FOREIGN KEY (BookID) REFERENCES Book(BookID),
    CONSTRAINT fk_Order_Customer FOREIGN KEY (CustomerEmail) REFERENCES Customer(CustomerEmail)
);

--Create table Store Owner Book
Create table StoreOwner_Book(
	OwnerEmail VARCHAR(50) Not null,
	BookID VARCHAR(10) NOT NULL,
	Constraint fk_StoreOwner_Book foreign key (OwnerEmail) References StoreOwner(OwnerEmail),
	Constraint ft_Book_StoreOwner foreign key (BookID) References Book(BookID)
	);