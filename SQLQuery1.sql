Create database FPTBook;

USE FPTBook;

CREATE TABLE Users (
    UserID INT PRIMARY KEY identity(1, 1),
    UserEmail VARCHAR(255) UNIQUE NOT NULL,
    UserFullName VARCHAR(255) NOT NULL,
    UserPassword VARCHAR(255) NOT NULL,
    UserType INT NOT NULL,
	UserImage Varchar(100), 
    UserAddress NVARCHAR(100) NULL,
    UserPhone VARCHAR(12) NULL,
	UserBirthday Datetime,
	UserSex Varchar(15),
	UserSection INT not null default 1
);

CREATE TABLE Admin (
	AdminID INT PRIMARY KEY identity(1, 1),
	UserID INT UNIQUE,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY identity(1, 1),
    UserID INT UNIQUE,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE StoreOwners (
    StoreOwnerID INT PRIMARY KEY identity(1, 1),
    UserID INT UNIQUE,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE Category (
	CategoryID INT PRIMARY KEY identity(1, 1),
    CategoryName NVARCHAR(50) NOT NULL,
);


CREATE TABLE Publisher (
    PublisherID INT PRIMARY KEY identity(1, 1),
	PublisherName NVarchar(50)
);

CREATE TABLE Books (
    BookID INT PRIMARY KEY identity(1, 1),
    BookTitle NVARCHAR(200) NOT NULL,
    BookPrice INT NOT NULL DEFAULT 10,	
    BookNumber INT NOT NULL,
    BookDetails NVARCHAR(1000) NULL,
    PublisherID INT NOT NULL,
    CONSTRAINT fk_Book_Publisher FOREIGN KEY (PublisherID) REFERENCES Publisher(PublisherID),
);

CREATE TABLE ImageBooks (
    BookID INT,
	BookImage1 Varchar(100), 
	BookImage2 Varchar(100), 
	BookImage3 Varchar(100), 
	BookImage4 Varchar(100), 
	BookImage5 Varchar(100), 
	BookImage6 Varchar(100), 
	BookImage7 Varchar(100), 
    CONSTRAINT fk_Book_Image FOREIGN KEY (BookID) REFERENCES Books(BookID),
);

CREATE TABLE Category_Book (
	CategoryID INT Not null,
    BookID INT not null,
	Constraint fk_Category_Book  FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID),
    CONSTRAINT fk_Book_Category FOREIGN KEY (BookID) REFERENCES Books(BookID),
);

Create table Cart(
CartID INT PRIMARY KEY identity(1, 1),
    BookID INT Not null,	
    CustomerID INT Not null,
	Number int not null default 1,
	Constraint fk_Cart_Book foreign key (BookID) references Books(BookID),
	Constraint fk_Cart_Customer foreign key (CustomerID) references Customers(CustomerID)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY identity(1, 1),
    CustomerID INT,
    OrderDate DATETIME NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY identity(1, 1),
    OrderID INT,
    BookID INT,
    Quantity INT NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);

Create table StoreOwner_Book(
	StoreOwnerID INT Not null,
	BookID INT NOT NULL,
	Constraint fk_StoreOwner_Book foreign key (StoreOwnerID) References StoreOwners(StoreOwnerID),
	Constraint ft_Book_StoreOwner foreign key (BookID) References Books(BookID)
	);


INSERT INTO Users (UserEmail, UserFullName, UserPassword, UserType, UserImage, UserAddress, UserPhone, UserBirthday, UserSex, UserSection)
VALUES
    ('misanthrop@gmail.com', 'Le Nguyen Quoc Khanh', 'khanhlux', 1, '~/images/acount1.png', 'An Giang', '0974534233', '1990-01-01', 'Male', 1),
    ('reacthookadmin2@gmail.com', 'Vu Tien Phat', 'phatfiora', 1, '~/images/acount2.png', 'TP HCM', '0843543264', '1985-05-15', 'Male', 1),
    ('bruyne@gmail.com', 'Bui Huu Nghia', 'nghiaveigo', 2, '~/images/acount3.png', 'Hoc Mon', '0784334723', '1995-03-10', 'Male', 1),
    ('duyka@gmail.com', 'Nguyen Truong Hoang Duy', 'duysylas', 2, '~/images/acount4.png', 'An Giang', '0315373743', '1988-07-20', 'Male', 1),
    ('erisqueen@gmail.com', 'Dang Vien Hao', 'haoyasuo', 2, '~/images/acount5.png', 'TP HCM', '0942737476', '1992-11-25', 'Male', 1),
    ('turtle@gmail.com', 'Nguyen Quang Huy', 'huythresh', 2, '~/images/acount6.png', 'TP HCM', '0895363685', '1980-09-05', 'Male', 1),
    ('tuan@gmail.com', 'Phung Huu Hoai Tuan', 'tuanonechame', 2, '~/images/acount7.png', 'An Giang', '0326826369', '1998-02-14', 'Male', 1),
    ('phuc@gmail.com', 'Nguyen Vinh Phuc', 'phucillaoi', 3, '~/images/acount8.png', 'An Giang', '0675236792', '1982-04-30', 'Male', 1),
    ('duong@gmail.com', 'Trinh Anh Duong', 'duonglienquan', 3, '~/images/acount9.png', 'TP HCM', '0542373722', '1990-12-15', 'Male', 1),
    ('mazuong2k3@gmail.com', 'Do Thien An', 'thanhchemgio', 3, '~/images/acount10.png', 'TP HCM', '0632235633', '1985-08-22', 'Male', 1);

INSERT INTO Admin (UserID)
VALUES
    (1), 
    (2);

INSERT INTO Customers (UserID)
VALUES
    (3), 
    (4),
    (5),
    (6), 
    (7); 

INSERT INTO StoreOwners (UserID)
VALUES
    (8),
    (9),
    (10);

INSERT INTO Category (CategoryName)
VALUES
    ('Science'),
    ('Economics'),
    ('Romance'),
    ('Fantasy'),
    ('Culture'),
    ('Fiction'),
    ('Classic'),
    ('History'),
    ('Psychology'),
    ('Art'),
    ('Children'),
    ('Self-help');

INSERT INTO Publisher (PublisherName)
VALUES
    ('Nhà Xuất Bản Thế Giới'),
    ('Nhà Xuất Bản Thanh Niên'),
    ('Nhà Xuất Bản Dân Trí'),
    ('Nhà Xuất Bản Văn Học'),
    ('Nhà Xuất Bản Phụ Nữ Việt Nam');

INSERT INTO Books (BookTitle, BookPrice, BookNumber, BookDetails, PublisherID)
VALUES
    ('Đám Trẻ Ở Đại Dương Đen', 20, 100, 'Lời độc thoại và đối thoại độc đáo, thể hiện sự u uất và tổn thương của đám trẻ.
										  Sự tập trung vào quá trình tự chữa lành, thể hiện hy vọng và nỗ lực của đám trẻ.
										  Tác giả GenZ mang đến góc nhìn mới về gia đình và xã hội.', 1),
    ('Kinh Doanh Thời Trang', 15, 80, 'Chi tiết những việc cần thực hiện để mở và vận hành shop thời trang.
									   Cách tìm sản phẩm bán chạy và đặt hàng gia công hiệu quả với chi phí hợp lý.
									   Cách trang trí cửa hàng để giữ chân và thu hút khách mua hàng.', 1),
    ('999 Lá Thư Gửi Cho Chính Mình', 15, 90, 'Lá thư được chọn lọc kỹ càng, ý nghĩa và sâu sắc.
											   Song ngữ Trung - Việt giúp trau dồi ngoại ngữ và kiến thức.
											   Kích thước nhỏ gọn, dễ dàng mang theo bên mình.', 2),
    ('Tạm Biệt Tôi Của Nhiều Năm Về Trước', 10, 80, 'Lời khuyên và cảm nhận sâu sắc về việc buông bỏ và tìm kiếm sự thanh thản.
													 Minh họa đẹp mắt và chân thực giúp hiểu rõ hơn về tổn thương bên trong.
													 Phát hành bởi công ty Skybooks, có uy tín và chuyên về xuất bản sách.', 3),
    ('Những Điều Tốt Đẹp Luôn Đúng Hạn Mà Đến', 19, 80, 'Thông điệp tích cực và lạc quan, giúp nhìn cuộc sống tích cực hơn.
													     Nội dung chân thật, trong sáng và giản dị, gần gũi và thân thiện.
													     Kích thước nhỏ gọn, dễ dàng mang theo bên mình.', 4),
    ('Vẫn Là Mùa Hạ Nhưng Không Còn Chúng Ta', 25, 80, 'Tản văn đầy xúc cảm giúp bạn chấp nhận nỗi lo âu và ngày u ám.
														Thông điệp sống bằng niềm vui, không để yêu thương thay bằng thù ghét.
														Giúp bạn hiểu về chính mình và trưởng thành mạnh mẽ dù cô đơn.', 5),
    ('Dear, Darling', 8, 80, 'Kết nối tâm hồn và tạo tần số hạnh phúc, yêu thương.
							  Lời nhắn nhủ đánh thức hạt mầm yêu thương và trân trọng cuộc sống.
							  Kích thước nhỏ gọn, dễ mang theo và đọc mọi lúc mọi nơi.', 5),
    ('Phía Trước Là Bầu Trời', 15, 80, 'Góp mặt của hơn 40 tác giả nổi tiếng trong ngành văn học.
										Tạo cảm giác như một chuyến tàu thanh xuân kéo dài không có điểm dừng.
										Kích thước nhỏ gọn, dễ mang theo và đọc mọi lúc, mọi nơi.', 5),
    ('Thiên Tài Bên Trái, Kẻ Điên Bên Phải', 15, 80, 'Khám phá thế giới của những người đặc biệt, kẻ gây rối và người chống đối.
													  Ngôn ngữ sắc sảo, sâu sắc và gần gũi, khai mở suy nghĩ và tạo động lực.
													  Dịch giả Thu Hương có tài và kinh nghiệm.', 1),													  
    ('Mẹ làm gì có ước mơ', 17, 80, 'Thông điệp sâu sắc về tình yêu và hy vọng của mẹ.
									 Ngôn ngữ thân thiện, gần gũi và dễ hiểu.
									 Hình ảnh và câu chuyện đưa người đọc trở lại ký ức tuổi thơ.', 4);

INSERT INTO ImageBooks (BookImage1, BookImage2, BookImage3, BookImage4, BookImage5, BookImage6, BookImage7)
VALUES
    ('~/images/book-1-1.png', '~/images/book-1-2.png', '~/images/book-1-3.png', '~/images/book-1-4.png', '~/images/book-1-5.png', '~/images/book-1-6.png', '~/images/book-1-7.png'),
    ('~/images/book-2-1.png', '~/images/book-2-2.png', '~/images/book-2-3.png', '~/images/book-2-4.png', '~/images/book-2-5.png', '~/images/book-2-6.png', '~/images/book-2-7.png'),
    ('~/images/book-3-1.png', '~/images/book-3-2.png', '~/images/book-3-3.png', '~/images/book-3-4.png', '~/images/book-3-5.png', '~/images/book-3-6.png', '~/images/book-3-7.png'),
    ('~/images/book-4-1.png', '~/images/book-4-2.png', '~/images/book-4-3.png', '~/images/book-4-4.png', '~/images/book-4-5.png', '~/images/book-4-6.png', '~/images/book-4-7.png'),
    ('~/images/book-5-1.png', '~/images/book-5-2.png', '~/images/book-5-3.png', '~/images/book-5-4.png', '~/images/book-5-5.png', '~/images/book-5-6.png', '~/images/book-5-7.png'),
    ('~/images/book-6-1.png', '~/images/book-6-2.png', '~/images/book-6-3.png', '~/images/book-6-4.png', '~/images/book-6-5.png', '~/images/book-6-6.png', '~/images/book-6-7.png'),
    ('~/images/book-7-1.png', '~/images/book-7-2.png', '~/images/book-7-3.png', '~/images/book-7-4.png', '~/images/book-7-5.png', '~/images/book-7-6.png', '~/images/book-7-7.png'),
    ('~/images/book-8-1.png', '~/images/book-8-2.png', '~/images/book-8-3.png', '~/images/book-8-4.png', '~/images/book-8-5.png', '~/images/book-8-6.png', '~/images/book-8-7.png'),	
    ('~/images/book-9-1.png', '~/images/book-9-2.png', '~/images/book-9-3.png', '~/images/book-9-4.png', '~/images/book-9-5.png', '~/images/book-9-6.png', '~/images/book-9-7.png'),
    ('~/images/book-10-1.png', '~/images/book-10-2.png', '~/images/book-10-3.png', '~/images/book-10-4.png', '~/images/book-10-1.png', '~/images/book-10-2.png', '~/images/book-10-3.png');

INSERT INTO Category_Book (CategoryID, BookID)
VALUES
    (1, 1),
    (4, 1), 
    (3, 2),
    (2, 3), 
    (4, 3),
    (9, 4), 
    (8, 4),
    (4, 5), 
    (7, 5),
    (3, 5), 
    (5, 6),
    (7, 7), 
    (12, 7), 
    (2, 8), 
    (7, 9), 
    (8, 9), 
    (9, 9),
    (10, 10), 
    (11, 10), 
    (1, 10);

INSERT INTO Cart (BookID, CustomerID, Number)
VALUES
    (1, 1, 1),
    (2, 1, 1);

INSERT INTO Orders (CustomerID, OrderDate)
VALUES
    (1, '2023-01-15'),
    (1, '2023-01-16');

INSERT INTO OrderDetails (BookID, Quantity)
VALUES
    (1, 1),
    (2, 1); 

INSERT INTO StoreOwner_Book (StoreOwnerID, BookID)
VALUES
    (1, 1),
    (1, 2),
    (1, 3),
    (2, 4),
    (2, 5),
    (2, 6),
    (3, 7),
    (3, 8),
    (3, 9);
