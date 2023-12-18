Create database FPTBook;

USE FPTBook;

CREATE TABLE Users (
    UserID INT PRIMARY KEY identity(1, 1),
    UserEmail VARCHAR(255) UNIQUE NOT NULL,
    UserFullName NVARCHAR(255) NOT NULL,
    UserPassword VARCHAR(255) NOT NULL,
    UserType INT NOT NULL,
	UserImage Varchar(100), 
    UserAddress NVARCHAR(100) NULL,
    UserPhone VARCHAR(12) NULL,
	UserBirthday Date,
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
	StoreOwnerName Nvarchar(50) not null,
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
    OrderDate Date NOT NULL,
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
    ('misanthrop@gmail.com', N'Lê Nguyễn Quốc Khánh', 'khanhlux', 1, 'acount1.png', 'An Giang', '0974534233', '1990-01-01', 'Male', 1),
    ('reacthookadmin2@gmail.com', N'Vũ Tiến Phát', 'phatfiora', 1, 'acount2', 'TP HCM', '0843543264', '1985-05-15', 'Male', 1),
    ('bruyne@gmail.com', N'Bùi Hữu Nghĩa', 'nghiaveigo', 2, 'acount3', 'Hoc Mon', '0784334723', '1995-03-10', 'Male', 1),
    ('duyka@gmail.com', N'Nguyễn Trương Hoàng Duy', 'duysylas', 2, 'acount4', 'An Giang', '0315373743', '1988-07-20', 'Male', 1),
    ('erisqueen@gmail.com', N'Đặng Viễn Hào', 'haoyasuo', 2, 'acount5', 'TP HCM', '0942737476', '1992-11-25', 'Male', 1),
    ('turtle@gmail.com', N'Nguyễn Quang Huy', 'huythresh', 2, 'acount6', 'TP HCM', '0895363685', '1980-09-05', 'Male', 1),
    ('tuan@gmail.com', N'Phùng Hữu Hoài Tuấn', 'tuanonechame', 2, 'acount7', 'An Giang', '0326826369', '1998-02-14', 'Male', 1),
    ('phuc@gmail.com', N'Nguyễn Vĩnh Phúc', 'phucillaoi', 3, 'acount8', 'An Giang', '0675236792', '1982-04-30', 'Male', 1),
    ('duong@gmail.com', N'Trịnh Ánh Dương', 'duonglienquan', 3, 'acount9', 'TP HCM', '0542373722', '1990-12-15', 'Male', 1),
    ('mazuong2k3@gmail.com', N'Đỗ Thiên Ân', 'thanhchemgio', 3, 'acount10', 'TP HCM', '0632235633', '1985-08-22', 'Male', 1);

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

INSERT INTO StoreOwners (UserID, StoreOwnerName)
VALUES
    (8, N'Gift of life'),
    (9, N'VADATABOOKS'),
    (10, N'MoonBook');

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
    (N'Nhà Xuất Bản Thế Giới'),
    (N'Nhà Xuất Bản Thanh Niên'),
    (N'Nhà Xuất Bản Dân Trí'),
    (N'Nhà Xuất Bản Văn Học'),
    (N'Nhà Xuất Bản Phụ Nữ Việt Nam'),
    (N'Nhà Xuất Bản Hà Nội');

INSERT INTO Books (BookTitle, BookPrice, BookNumber, BookDetails, PublisherID)
VALUES
    (N'Đám Trẻ Ở Đại Dương Đen', 20, 100, N'Lời độc thoại và đối thoại độc đáo, thể hiện sự u uất và tổn thương của đám trẻ.
										  Sự tập trung vào quá trình tự chữa lành, thể hiện hy vọng và nỗ lực của đám trẻ.
										  Tác giả GenZ mang đến góc nhìn mới về gia đình và xã hội.', 1),
    (N'Kinh Doanh Thời Trang', 15, 80, N'Chi tiết những việc cần thực hiện để mở và vận hành shop thời trang.
									   Cách tìm sản phẩm bán chạy và đặt hàng gia công hiệu quả với chi phí hợp lý.
									   Cách trang trí cửa hàng để giữ chân và thu hút khách mua hàng.', 1),
    (N'999 Lá Thư Gửi Cho Chính Mình', 15, 90, N'Lá thư được chọn lọc kỹ càng, ý nghĩa và sâu sắc.
											   Song ngữ Trung - Việt giúp trau dồi ngoại ngữ và kiến thức.
											   Kích thước nhỏ gọn, dễ dàng mang theo bên mình.', 2),
    (N'Tạm Biệt Tôi Của Nhiều Năm Về Trước', 10, 80, N'Lời khuyên và cảm nhận sâu sắc về việc buông bỏ và tìm kiếm sự thanh thản.
													 Minh họa đẹp mắt và chân thực giúp hiểu rõ hơn về tổn thương bên trong.
													 Phát hành bởi công ty Skybooks, có uy tín và chuyên về xuất bản sách.', 3),
    (N'Những Điều Tốt Đẹp Luôn Đúng Hạn Mà Đến', 19, 80, N'Thông điệp tích cực và lạc quan, giúp nhìn cuộc sống tích cực hơn.
													     Nội dung chân thật, trong sáng và giản dị, gần gũi và thân thiện.
													     Kích thước nhỏ gọn, dễ dàng mang theo bên mình.', 4),
    (N'Vẫn Là Mùa Hạ Nhưng Không Còn Chúng Ta', 25, 80, N'Tản văn đầy xúc cảm giúp bạn chấp nhận nỗi lo âu và ngày u ám.
														Thông điệp sống bằng niềm vui, không để yêu thương thay bằng thù ghét.
														Giúp bạn hiểu về chính mình và trưởng thành mạnh mẽ dù cô đơn.', 5),
    (N'Dear, Darling', 8, 80, N'Kết nối tâm hồn và tạo tần số hạnh phúc, yêu thương.
							  Lời nhắn nhủ đánh thức hạt mầm yêu thương và trân trọng cuộc sống.
							  Kích thước nhỏ gọn, dễ mang theo và đọc mọi lúc mọi nơi.', 5),
    (N'Phía Trước Là Bầu Trời', 15, 80, N'Góp mặt của hơn 40 tác giả nổi tiếng trong ngành văn học.
										Tạo cảm giác như một chuyến tàu thanh xuân kéo dài không có điểm dừng.
										Kích thước nhỏ gọn, dễ mang theo và đọc mọi lúc, mọi nơi.', 5),
    (N'Thiên Tài Bên Trái, Kẻ Điên Bên Phải', 15, 80, N'Khám phá thế giới của những người đặc biệt, kẻ gây rối và người chống đối.
													  Ngôn ngữ sắc sảo, sâu sắc và gần gũi, khai mở suy nghĩ và tạo động lực.
													  Dịch giả Thu Hương có tài và kinh nghiệm.', 1),													  
    (N'Mẹ làm gì có ước mơ', 17, 80, N'Thông điệp sâu sắc về tình yêu và hy vọng của mẹ.
									 Ngôn ngữ thân thiện, gần gũi và dễ hiểu.
									 Hình ảnh và câu chuyện đưa người đọc trở lại ký ức tuổi thơ.', 4),
									 (N'Nanh Trắng Và Tiếng Gọi Của Hoang Dã', 18, 100, N'Tính biểu tượng và sâu sắc, thể hiện sự tranh đấu và tình yêu.
Cung cấp cái nhìn độc đáo về cuộc sống hoang dã và tương tác con người và động vật.
Nhiều người dịch, chất lượng và chính xác trong chuyển ngữ.', 4),
    (N'Nhà Giả Kim ', 10, 100, N'Câu chuyện cổ tích giản dị, giàu chất thơ và nhân ái.
Thấm đẫm những minh triết huyền bí của phương Đông.
Có khả năng thay đổi cuộc sống người đọc.', 6),
    (N'Bố Già', 8, 100, N'Cốt truyện hấp dẫn, gay cấn và đầy bất ngờ.
Ngôn ngữ giang hồ, tạo không khí kình địch đến nghẹt thở.
Tác giả nổi tiếng, chuyên viết về mafia và tội phạm.', 4),
    (N'Ông già và biển cả', 12, 100, N'Câu chuyện đầy cảm xúc và đối đầu cam go.
Ngôn ngữ sâu sắc và nhân vật đa chiều.
Bản dịch của giáo sư Lê Huy Bắc được đánh giá cao.', 4),
    (N'Dịch Hạch', 14, 100, N'Cảm động về sự đối mặt với đại dịch và nhân loại.
Bối cảnh khắc nghiệt và áp lực tạo nên câu chuyện ý nghĩa.
Ngôn ngữ sắc sảo và tinh tế tạo cảm xúc sâu sắc.', 3),
    (N'TỘI ÁC VÀ HÌNH PHẠT', 5, 100, N'Tác giả Fyodor Dostoyevsky - một nhà văn vĩ đại.
Tội ác và hình phạt - tiểu thuyết vĩ đại nhất mọi thời.
Kích thước lớn và bìa cứng - sang trọng và bền bỉ.', 4),
    (N'Trí Thông Minh Trên Giường', 6, 100, N'Khám phá sự gần gũi và bí ẩn của tình dục và tình yêu.
Tác giả có kinh nghiệm lâu năm và giúp hàng trăm cặp vợ chồng duy trì hạnh phúc.
Cuốn sách đã trở thành hiện tượng toàn cầu và được dịch sang 24 ngôn ngữ.', 2),
    (N'Không Diệt Không Sinh Đừng Sợ Hãi', 9, 100, N'Sách mang thông điệp về sự tự do và giải thoát khỏi nỗi sợ hãi.
Thiền sư Thích Nhất Hạnh chia sẻ tri kiến sâu sắc và tế nhị về sống và chết.
Sách giúp nhìn sâu vào bản chất của sự trái ngược trong cuộc sống.', 1),
    (N'Chiến Thắng Con Quỷ Trong Bạn', 11, 100, N'Sách giúp bạn nhận biết và hiểu rõ hơn về sự tồn tại của Thiên thần và Ác quỷ trong con người.
Cuốn sách khám phá cuộc đối thoại sâu thẳm trong tâm thức, giúp bạn vượt qua khó khăn.
Napoleon Hill chia sẻ hướng dẫn cụ thể để xây dựng kỷ luật tự nhân.', 4),
    (N'Rèn Luyện Tư Duy Phản Biện', 17, 100, N'Nhận ra lý do và lý giải cho suy nghĩ khiếm khuyết của mình.
Mở rộng tầm nhìn và tri thức thông qua thu thập ý tưởng và đức tin từ mọi người.
Tham gia vào cuộc thảo luận phản biện để rèn luyện tư duy hiệu quả.', 5),
    (N'Bạn Thật Sự Là Ai?', 12, 100, N'Giới thiệu về "bản tính thứ ba" và tầm quan trọng của tính cách.
Văn phong dí dỏm, mạch lạc và dễ hiểu.
Phù hợp cho mọi người quan tâm đến tính cách con người.', 3),
    (N'Hành Tinh Của Một Kẻ Nghĩ Nhiều', 14, 100, N'Chứa kiến thức từ podcast Amateur Psychology, giúp hiểu sâu về bản thân.
Dẫn lối qua ngóc ngách hành tinh nội tâm, góc nhìn tinh tế.
Kích thước nhỏ gọn, dễ mang theo và đọc mọi lúc.', 1),
    (N'Muôn Kiếp Nhân Sinh 3', 6, 100, N'Triết lý và tâm linh sâu sắc, mở rộng suy nghĩ về con người.
Ngôn ngữ giản dị, dễ tiếp cận, giúp hiểu sâu về tâm linh.
Xâu chuỗi tiền kiếp, giúp thấu hiểu và trân trọng nhân duyên.', 6),
    (N'Tết ở làng Địa Ngục', 9, 100, N'Kích thước tiểu thuyết phù hợp để đọc và cầm nắm.
Số trang đủ dài và chi tiết để mang đến một câu chuyện sâu sắc.
Bìa mềm dễ dàng cầm nắm và vận chuyển.', 2),
    (N'Harvard Bốn Rưỡi Sáng', 10, 100, N'Hình ảnh Harvard thu hút và tạo sự quan tâm.
Chứa nhiều chỉ dẫn và thông điệp thực dụng và bay bổng.
Khuyến khích việc tạo lập niềm tin và tự tin trong cuộc sống.', 1),
    (N'Sức Hút Của Sự Điềm Tĩnh', 12, 100, N'Xây dựng sự điềm tĩnh trong hành động, lời nói và thái độ.
Phát triển khả năng làm chủ cảm xúc và tạo ra khí chất riêng.
Tác giả có kinh nghiệm và kiến thức sâu sắc về vấn đề này.', 1),
    (N'Đắc Nhân Tâm', 17, 100, N'Bản dịch hoàn hảo nhất, dễ hiểu và gần gũi.
Cung cấp nguyên tắc vàng về giao tiếp và phát triển bản thân.
Truyền cảm hứng và thay đổi cuộc sống hàng triệu người.', 3),
    (N'Thao Túng Tâm Lý Trong Tình Yêu', 19, 100, N'Cuốn sách dựa trên câu chuyện đời thực, giúp bạn đồng cảm và hiểu rõ hơn về tình huống.
Lời khuyên từ những người đã trải qua tổn thương, giúp bạn tìm đến giải thoát.
Nhận ra các hành vi thao túng, giúp bạn tỉnh táo và không rơi vào khổ sở.', 2),
    (N'Giao Tiếp Thông Minh Nói Đâu Trúng Đó', 11, 100, N'Phương pháp luyện tập hữu ích để nâng cao kỹ năng giao tiếp.
Truyền đạt thông điệp súc tích và thu hút đối tượng nghe.
Cung cấp phương pháp giảm thiểu ngôn ngữ và tạo lời nói trọng tâm.', 1),
    (N'Cách Đánh Thức Con Người Phi Thường Trong Bạn', 12, 100, N'Tác giả thành đạt và là nhân chứng sống về sự phi thường.
Chia sẻ bí quyết thành công và khuyến khích khai thác sức mạnh bên trong.
Giới thiệu 3 nguyên tắc nền tảng và 5 khía cạnh để phát triển cuộc sống.', 1);

INSERT INTO ImageBooks (BookID, BookImage1, BookImage2, BookImage3, BookImage4, BookImage5, BookImage6, BookImage7)
VALUES
    (1, 'book-1-1.png', 'book-1-2.png', 'book-1-3.png', 'book-1-4.png', 'book-1-5.png', 'book-1-6.png', 'book-1-7.png'),
    (2, 'book-2-1.png', 'book-2-2.png', 'book-2-3.png', 'book-2-4.png', 'book-2-5.png', 'book-2-6.png', 'book-2-7.png'),
    (3, 'book-3-1.png', 'book-3-2.png', 'book-3-3.png', 'book-3-4.png', 'book-3-5.png', 'book-3-6.png', 'book-3-7.png'),
    (4, 'book-4-1.png', 'book-4-2.png', 'book-4-3.png', 'book-4-4.png', 'book-4-5.png', 'book-4-6.png', 'book-4-7.png'),
    (5, 'book-5-1.png', 'book-5-2.png', 'book-5-3.png', 'book-5-4.png', 'book-5-5.png', 'book-5-6.png', 'book-5-7.png'),
    (6, 'book-6-1.png', 'book-6-2.png', 'book-6-3.png', 'book-6-4.png', 'book-6-5.png', 'book-6-6.png', 'book-6-7.png'),
    (7, 'book-7-1.png', 'book-7-2.png', 'book-7-3.png', 'book-7-4.png', 'book-7-5.png', 'book-7-6.png', 'book-7-7.png'),
    (8, 'book-8-1.png', 'book-8-2.png', 'book-8-3.png', 'book-8-4.png', 'book-8-5.png', 'book-8-6.png', 'book-8-7.png'),	
    (9, 'book-9-1.png', 'book-9-2.png', 'book-9-3.png', 'book-9-4.png', 'book-9-5.png', 'book-9-6.png', 'book-9-7.png'),
    (10, 'book-10-1.png', 'book-10-2.png', 'book-10-3.png', 'book-10-4.png', 'book-10-5.png', 'book-10-6.png', 'book-10-7.png'),
    (11, 'book-11-1.png', 'book-11-2.png', 'book-11-3.png', 'book-11-4.png', 'book-11-5.png', 'book-11-6.png', 'book-11-7.png'),
    (12, 'book-12-1.png', 'book-12-2.png', 'book-12-3.png', 'book-12-4.png', 'book-12-5.png', 'book-12-6.png', 'book-12-7.png'),
    (13, 'book-13-1.png', 'book-13-2.png', 'book-13-3.png', 'book-13-4.png', 'book-13-5.png', 'book-13-6.png', 'book-13-7.png'),
    (14, 'book-14-1.png', 'book-14-2.png', 'book-14-3.png', 'book-14-4.png', 'book-14-5.png', 'book-14-6.png', 'book-14-7.png'),
    (15, 'book-15-1.png', 'book-15-2.png', 'book-15-3.png', 'book-15-4.png', 'book-15-5.png', 'book-15-6.png', 'book-15-7.png'),
    (16, 'book-16-1.png', 'book-16-2.png', 'book-16-3.png', 'book-16-4.png', 'book-16-5.png', 'book-16-6.png', 'book-16-7.png'),
    (17, 'book-17-1.png', 'book-17-2.png', 'book-17-3.png', 'book-17-4.png', 'book-17-5.png', 'book-17-6.png', 'book-17-7.png'),
    (18, 'book-18-1.png', 'book-18-2.png', 'book-18-3.png', Null, Null, Null, Null),
    (19, 'book-19-1.png', 'book-19-2.png', 'book-19-3.png', Null, Null, Null, Null),
    (20, 'book-20-1.png', 'book-20-2.png', 'book-20-3.png', Null, Null, Null, Null),
    (21, 'book-21-1.png', Null, Null, Null, Null, Null, Null),
    (22, 'book-22-1.png', 'book-22-2.png', 'book-22-3.png', Null, Null, Null, Null),
    (23, 'book-23-1.png', 'book-23-2.png', 'book-23-3.png', 'book-23-4.png', Null, Null, Null),
    (24, 'book-24-1.png', 'book-24-2.png', Null, Null, Null, Null, Null),
    (25, 'book-25-1.png', 'book-25-2.png', 'book-25-3.png', Null, Null, Null, Null),
    (26, 'book-26-1.png', 'book-26-2.png', 'book-26-3.png', 'book-26-4.png', 'book-26-5.png', Null, Null),
    (27, 'book-27-1.png', 'book-27-2.png', 'book-27-3.png', 'book-27-4.png', 'book-27-5.png', 'book-27-6.png', 'book-27-7.png'),
    (28, 'book-28-1.png', 'book-28-2.png', 'book-28-3.png', Null, Null, Null, Null),
    (29, 'book-29-1.png', 'book-29-2.png', 'book-29-3.png', 'book-29-4.png', 'book-29-5.png', 'book-29-6.png', Null),
    (30, 'book-30-1.png', 'book-30-2.png', 'book-30-3.png', Null, Null, Null, Null);
    

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
    (1, 10),
    (12, 11), 
    (10, 11), 
    (3, 12),
    (6, 13), 
    (3, 13), 
    (6, 14),
    (8, 14), 
    (11, 15), 
    (1, 15),
    (10, 15), 
    (11, 16), 
    (6, 17),
    (8, 17), 
    (10, 17), 
    (12, 18),
    (1, 18), 
    (3, 19), 
    (5, 20),
    (7, 21), 
    (9, 22), 
    (11, 22),
    (2, 23), 
    (4, 23), 
    (6, 23),
    (8, 24), 
    (10, 24), 
    (12, 24),
    (1, 24), 
    (3, 25), 
    (5, 25),
    (7, 25), 
    (9, 26), 
    (11, 26),
    (2, 26), 
    (4, 27), 
    (6, 27),
    (8, 27), 
    (10, 28), 
    (12, 28),
    (1, 29), 
    (3, 29), 
    (5, 29),
    (7, 30), 
    (9, 30), 
    (11, 30);

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
    (3, 9),
    (3, 10),
	(1, 11),
    (1, 12),
    (1, 13),
    (2, 14),
    (2, 15),
    (2, 16),
    (3, 17),
    (3, 18),
    (3, 19),
    (3, 20),
	(1, 21),
    (1, 22),
    (1, 23),
    (2, 24),
    (2, 25),
    (2, 26),
    (3, 27),
    (3, 28),
    (3, 29),
    (3, 30);
   