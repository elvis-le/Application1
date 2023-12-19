using FPTBook.Models;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Net;
using static NuGet.Packaging.PackagingConstants;
using static System.Reflection.Metadata.BlobBuilder;

namespace FPTBook.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<FptbookContext>();

                context.Database.EnsureCreated();

                //if (!context.Users.Any())
                //{
                //    context.Users.AddRange(new List<User>()
                //    {
                //        new User
                //{
                //    UserEmail = "misanthrop@gmail.com",
                //    UserFullName = "Lê Nguyễn Quốc Khánh",
                //    UserPassword = "khanhlux",
                //    UserType = 1,
                //    UserImage = "acount1.png",
                //    UserAddress = "An Giang",
                //    UserPhone = "0974534233",
                //    UserBirthday = DateTime.Parse("1990-01-01"),
                //    UserSex = "Male",
                //    UserSection = 1
                //},
                //new User
                //{
                //    UserEmail = "reacthookadmin2@gmail.com",
                //    UserFullName = "Vũ Tiến Phát",
                //    UserPassword = "phatfiora",
                //    UserType = 1,
                //    UserImage = "acount2",
                //    UserAddress = "TP HCM",
                //    UserPhone = "0843543264",
                //    UserBirthday = DateTime.Parse("1985-05-15"),
                //    UserSex = "Male",
                //    UserSection = 1
                //},
                //new User
                //{
                //    UserEmail = "bruyne@gmail.com",
                //    UserFullName = "Bùi Hữu Nghĩa",
                //    UserPassword = "nghiaveigo",
                //    UserType = 2,
                //    UserImage = "acount3",
                //    UserAddress = "Hoc Mon",
                //    UserPhone = "0784334723",
                //    UserBirthday = DateTime.Parse("1995-03-10"),
                //    UserSex = "Male",
                //    UserSection = 1
                //},
                //new User
                //{
                //    UserEmail = "duyka@gmail.com",
                //    UserFullName = "Nguyễn Trương Hoàng Duy",
                //    UserPassword = "duysylas",
                //    UserType = 2,
                //    UserImage = "acount4",
                //    UserAddress = "An Giang",
                //    UserPhone = "0315373743",
                //    UserBirthday = DateTime.Parse("1988-07-20"),
                //    UserSex = "Male",
                //    UserSection = 1
                //},
                //new User
                //{
                //    UserEmail = "erisqueen@gmail.com",
                //    UserFullName = "Đặng Viễn Hào",
                //    UserPassword = "haoyasuo",
                //    UserType = 2,
                //    UserImage = "acount5",
                //    UserAddress = "TP HCM",
                //    UserPhone = "0942737476",
                //    UserBirthday = DateTime.Parse("1992-11-25"),
                //    UserSex = "Male",
                //    UserSection = 1
                //},
                //new User
                //{
                //    UserEmail = "turtle@gmail.com",
                //    UserFullName = "Nguyễn Quang Huy",
                //    UserPassword = "huythresh",
                //    UserType = 2,
                //    UserImage = "acount6",
                //    UserAddress = "TP HCM",
                //    UserPhone = "0895363685",
                //    UserBirthday = DateTime.Parse("1980-09-05"),
                //    UserSex = "Male",
                //    UserSection = 1
                //},
                //new User
                //{
                //    UserEmail = "tuan@gmail.com",
                //    UserFullName = "Phùng Hữu Hoài Tuấn",
                //    UserPassword = "tuanonechame",
                //    UserType = 2,
                //    UserImage = "acount7",
                //    UserAddress = "An Giang",
                //    UserPhone = "0326826369",
                //    UserBirthday = DateTime.Parse("1998-02-14"),
                //    UserSex = "Male",
                //    UserSection = 1
                //},
                //new User
                //{
                //    UserEmail = "phuc@gmail.com",
                //    UserFullName = "Nguyễn Vĩnh Phúc",
                //    UserPassword = "phucillaoi",
                //    UserType = 3,
                //    UserImage = "acount8",
                //    UserAddress = "An Giang",
                //    UserPhone = "0675236792",
                //    UserBirthday = DateTime.Parse("1982-04-30"),
                //    UserSex = "Male",
                //    UserSection = 1
                //},
                //new User
                //{
                //    UserEmail = "duong@gmail.com",
                //    UserFullName = "Trịnh Ánh Dương",
                //    UserPassword = "duonglienquan",
                //    UserType = 3,
                //    UserImage = "acount9",
                //    UserAddress = "TP HCM",
                //    UserPhone = "0542373722",
                //    UserBirthday = DateTime.Parse("1990-12-15"),
                //    UserSex = "Male",
                //    UserSection = 1
                //},
                //new User
                //{
                //    UserEmail = "mazuong2k3@gmail.com",
                //    UserFullName = "Đỗ Thiên Ân",
                //    UserPassword = "thanhchemgio",
                //    UserType = 3,
                //    UserImage = "acount10",
                //    UserAddress = "TP HCM",
                //    UserPhone = "0632235633",
                //    UserBirthday = DateTime.Parse("1985-08-22"),
                //    UserSex = "Male",
                //    UserSection = 1
                //},

                //    });
                //    context.SaveChanges();
                //}

                //if (!context.Admins.Any())
                //{
                //    context.Admins.AddRange(new List<Admin>()
                //    {
                //        new Admin { UserId = 1 },
                //new Admin { UserId = 2 },

                //    });
                //    context.SaveChanges();
                //}

                //if (!context.Customers.Any())
                //{
                //    context.Customers.AddRange(new List<Customer>()
                //    {
                //        new Customer { UserId = 3 },
                //new Customer { UserId = 4 },
                //new Customer { UserId = 5 },
                //new Customer { UserId = 6 },
                //new Customer { UserId = 7 },

                //    });
                //    context.SaveChanges();
                //}

                //if (!context.StoreOwners.Any())
                //{
                //    context.StoreOwners.AddRange(new List<StoreOwner>()
                //    {
                //        new StoreOwner { UserId = 8, StoreOwnerName = "Gift of life" },
                //new StoreOwner { UserId = 9, StoreOwnerName = "VADATABOOKS" },
                //new StoreOwner { UserId = 10, StoreOwnerName = "MoonBook" },

                //    });
                //    context.SaveChanges();
                //}

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category { CategoryName = "Science" },
                new Category { CategoryName = "Economics" },
                new Category { CategoryName = "Romance" },
                new Category { CategoryName = "Fantasy" },
                new Category { CategoryName = "Culture" },
                new Category { CategoryName = "Fiction" },
                new Category { CategoryName = "Classic" },
                new Category { CategoryName = "History" },
                new Category { CategoryName = "Psychology" },
                new Category { CategoryName = "Art" },
                new Category { CategoryName = "Children" },
                new Category { CategoryName = "Self-help" },

                    });
                    context.SaveChanges();
                }

                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(new List<Publisher>()
                    {
                        new Publisher { PublisherName = "Nhà Xuất Bản Thế Giới" },
                new Publisher { PublisherName = "Nhà Xuất Bản Thanh Niên" },
                new Publisher { PublisherName = "Nhà Xuất Bản Dân Trí" },
                new Publisher { PublisherName = "Nhà Xuất Bản Văn Học" },
                new Publisher { PublisherName = "Nhà Xuất Bản Phụ Nữ Việt Nam" },
                new Publisher { PublisherName = "Nhà Xuất Bản Hà Nội" },

                    });
                    context.SaveChanges();
                }

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book
                {
                    BookTitle = "Đám Trẻ Ở Đại Dương Đen",
                    BookPrice = 20,
                    BookNumber = 100,
                    BookDetails = "Lời độc thoại và đối thoại độc đáo, thể hiện sự u uất và tổn thương của đám trẻ.\nSự tập trung vào quá trình tự chữa lành, thể hiện hy vọng và nỗ lực của đám trẻ.",
                    PublisherId = 1
                },
                new Book
                {
                    BookTitle = "Kinh Doanh Thời Trang",
                    BookPrice = 15,
                    BookNumber = 80,
                    BookDetails = "Chi tiết những việc cần thực hiện để mở và vận hành shop thời trang.\nCách tìm sản phẩm bán chạy và đặt hàng gia công hiệu quả với chi phí hợp lý.\nCách trang trí cửa hàng để giữ chân và thu hút khách mua hàng.",
                    PublisherId = 1
                },
                new Book
                {
                    BookTitle = "999 Lá Thư Gửi Cho Chính Mình",
                    BookPrice = 15,
                    BookNumber = 90,
                    BookDetails = "Lá thư được chọn lọc kỹ càng, ý nghĩa và sâu sắc.\nSong ngữ Trung - Việt giúp trau dồi ngoại ngữ và kiến thức.\nKích thước nhỏ gọn, dễ dàng mang theo bên mình.",
                    PublisherId = 2
                },
                new Book
                {
                    BookTitle = "Tạm Biệt Tôi Của Nhiều Năm Về Trước",
                    BookPrice = 10,
                    BookNumber = 80,
                    BookDetails = "Lời khuyên và cảm nhận sâu sắc về việc buông bỏ và tìm kiếm sự thanh thản.\nMinh họa đẹp mắt và chân thực giúp hiểu rõ hơn về tổn thương bên trong.\nPhát hành bởi công ty Skybooks, có uy tín và chuyên về xuất bản sách.",
                    PublisherId = 3
                },
                new Book
                {
                    BookTitle = "Những Điều Tốt Đẹp Luôn Đúng Hạn Mà Đến",
                    BookPrice = 19,
                    BookNumber = 80,
                    BookDetails = "Thông điệp tích cực và lạc quan, giúp nhìn cuộc sống tích cực hơn.\nNội dung chân thật, trong sáng và giản dị, gần gũi và thân thiện.\nKích thước nhỏ gọn, dễ dàng mang theo bên mình.",
                    PublisherId = 4
                },
                new Book
                {
                    BookTitle = "Vẫn Là Mùa Hạ Nhưng Không Còn Chúng Ta",
                    BookPrice = 25,
                    BookNumber = 80,
                    BookDetails = "Tản văn đầy xúc cảm giúp bạn chấp nhận nỗi lo âu và ngày u ám.\nThông điệp sống bằng niềm vui, không để yêu thương thay bằng thù ghét.\nGiúp bạn hiểu về chính mình và trưởng thành mạnh mẽ dù cô đơn.",
                    PublisherId = 5
                },
                new Book
                {
                    BookTitle = "Dear, Darling",
                    BookPrice = 8,
                    BookNumber = 80,
                    BookDetails = "Kết nối tâm hồn và tạo tần số hạnh phúc, yêu thương.\nLời nhắn nhủ đánh thức hạt mầm yêu thương và trân trọng cuộc sống.\nKích thước nhỏ gọn, dễ mang theo và đọc mọi lúc mọi nơi.",
                    PublisherId = 5
                },
                new Book
                {
                    BookTitle = "Phía Trước Là Bầu Trời",
                    BookPrice = 15,
                    BookNumber = 80,
                    BookDetails = "Những câu chuyện tình yêu đẹp, ngọt ngào và ý nghĩa.\nNhững trở ngại và thách thức giúp tình yêu trở nên cường thêm.\nMột cuốn sách dành cho những người tin vào tình yêu và niềm tin.",
                    PublisherId = 6
                },
                new Book
                    {
                        BookTitle = "Thiên Tài Bên Trái, Kẻ Điên Bên Phải",
                        BookPrice = 15,
                        BookNumber = 80,
                        BookDetails = "Khám phá thế giới của những người đặc biệt, kẻ gây rối và người chống đối.\nNgôn ngữ sắc sảo, sâu sắc và gần gũi, khai mở suy nghĩ và tạo động lực.\nDịch giả Thu Hương có tài và kinh nghiệm.",
                        PublisherId = 1
                    },
                    new Book
                    {
                        BookTitle = "Mẹ làm gì có ước mơ",
                        BookPrice = 17,
                        BookNumber = 80,
                        BookDetails = "Thông điệp sâu sắc về tình yêu và hy vọng của mẹ.\nNgôn ngữ thân thiện, gần gũi và dễ hiểu.\nHình ảnh và câu chuyện đưa người đọc trở lại ký ức tuổi thơ.",
                        PublisherId = 4
                    },
                    new Book
                    {
                        BookTitle = "Nanh Trắng Và Tiếng Gọi Của Hoang Dã",
                        BookPrice = 18,
                        BookNumber = 100,
                        BookDetails = "Tính biểu tượng và sâu sắc, thể hiện sự tranh đấu và tình yêu.\nCung cấp cái nhìn độc đáo về cuộc sống hoang dã và tương tác con người và động vật.\nNhiều người dịch, chất lượng và chính xác trong chuyển ngữ.",
                        PublisherId = 4
                    },
                    new Book
                    {
                        BookTitle = "Nhà Giả Kim",
                        BookPrice = 10,
                        BookNumber = 100,
                        BookDetails = "Câu chuyện cổ tích giản dị, giàu chất thơ và nhân ái.\nThấm đẫm những minh triết huyền bí của phương Đông.\nCó khả năng thay đổi cuộc sống người đọc.",
                        PublisherId = 6
                    },
                    new Book
                    {
                        BookTitle = "Bố Già",
                        BookPrice = 8,
                        BookNumber = 100,
                        BookDetails = "Cốt truyện hấp dẫn, gay cấn và đầy bất ngờ.\nNgôn ngữ giang hồ, tạo không khí kình địch đến nghẹt thở.\nTác giả nổi tiếng, chuyên viết về mafia và tội phạm.",
                        PublisherId = 4
                    },
                    new Book
                    {
                        BookTitle = "Ông già và biển cả",
                        BookPrice = 12,
                        BookNumber = 100,
                        BookDetails = "Câu chuyện đầy cảm xúc và đối đầu cam go.\nNgôn ngữ sâu sắc và nhân vật đa chiều.\nBản dịch của giáo sư Lê Huy Bắc được đánh giá cao.",
                        PublisherId = 4
                    },
                    new Book
                    {
                        BookTitle = "Dịch Hạch",
                        BookPrice = 14,
                        BookNumber = 100,
                        BookDetails = "Cảm động về sự đối mặt với đại dịch và nhân loại.\nBối cảnh khắc nghiệt và áp lực tạo nên câu chuyện ý nghĩa.\nNgôn ngữ sắc sảo và tinh tế tạo cảm xúc sâu sắc.",
                        PublisherId = 3
                    },
                    new Book
                    {
                        BookTitle = "TỘI ÁC VÀ HÌNH PHẠT",
                        BookPrice = 5,
                        BookNumber = 100,
                        BookDetails = "Tác giả Fyodor Dostoyevsky - một nhà văn vĩ đại.\nTội ác và hình phạt - tiểu thuyết vĩ đại nhất mọi thời.\nKích thước lớn và bìa cứng - sang trọng và bền bỉ.",
                        PublisherId = 4
                    },
                    new Book
                    {
                        BookTitle = "Trí Thông Minh Trên Giường",
                        BookPrice = 6,
                        BookNumber = 100,
                        BookDetails = "Khám phá sự gần gũi và bí ẩn của tình dục và tình yêu.\nTác giả có kinh nghiệm lâu năm và giúp hàng trăm cặp vợ chồng duy trì hạnh phúc.\nCuốn sách đã trở thành hiện tượng toàn cầu và được dịch sang 24 ngôn ngữ.",
                        PublisherId = 2
                    },
                    new Book
                    {
                        BookTitle = "Không Diệt Không Sinh Đừng Sợ Hãi",
                        BookPrice = 9,
                        BookNumber = 100,
                        BookDetails = "Sách mang thông điệp về sự tự do và giải thoát khỏi nỗi sợ hãi.\nThiền sư Thích Nhất Hạnh chia sẻ tri kiến sâu sắc và tế nhị về sống và chết.\nSách giúp nhìn sâu vào bản chất của sự trái ngược trong cuộc sống.",
                        PublisherId = 1
                    },
                    new Book
                    {
                        BookTitle = "Chiến Thắng Con Quỷ Trong Bạn",
                        BookPrice = 11,
                        BookNumber = 100,
                        BookDetails = "Sách giúp bạn nhận biết và hiểu rõ hơn về sự tồn tại của Thiên thần và Ác quỷ trong con người.\nCuốn sách khám phá cuộc đối thoại sâu thẳm trong tâm thức, giúp bạn vượt qua khó khăn.\nNapoleon Hill chia sẻ hướng dẫn cụ thể để xây dựng kỷ luật tự nhân.",
                        PublisherId = 4
                    },
                    new Book
                    {
                        BookTitle = "Rèn Luyện Tư Duy Phản Biện",
                        BookPrice = 17,
                        BookNumber = 100,
                        BookDetails = "Nhận ra lý do và lý giải cho suy nghĩ khiếm khuyết của mình.\nMở rộng tầm nhìn và tri thức thông qua thu thập ý tưởng và đức tin từ mọi người.\nTham gia vào cuộc thảo luận phản biện để rèn luyện tư duy hiệu quả.",
                        PublisherId = 5
                    },
                    new Book
                    {
                        BookTitle = "Bạn Thật Sự Là Ai?",
                        BookPrice = 12,
                        BookNumber = 100,
                        BookDetails = "Giới thiệu về \"bản tính thứ ba\" và tầm quan trọng của tính cách.\nVăn phong dí dỏm, mạch lạc và dễ hiểu.\nPhù hợp cho mọi người quan tâm đến tính cách con người.",
                        PublisherId = 3
                    },
                    new Book
                    {
                        BookTitle = "Hành Tinh Của Một Kẻ Nghĩ Nhiều",
                        BookPrice = 14,
                        BookNumber = 100,
                        BookDetails = "Chứa kiến thức từ podcast Amateur Psychology, giúp hiểu sâu về bản thân.\nDẫn lối qua ngóc ngách hành tinh nội tâm, góc nhìn tinh tế.\nKích thước nhỏ gọn, dễ mang theo và đọc mọi lúc.",
                        PublisherId = 1
                    },
                    new Book
                    {
                        BookTitle = "Muôn Kiếp Nhân Sinh 3",
                        BookPrice = 6,
                        BookNumber = 100,
                        BookDetails = "Triết lý và tâm linh sâu sắc, mở rộng suy nghĩ về con người.\nNgôn ngữ giản dị, dễ tiếp cận, giúp hiểu sâu về tâm linh.\nXâu chuỗi tiền kiếp, giúp thấu hiểu và trân trọng nhân duyên.",
                        PublisherId = 6
                    },
                    new Book
                    {
                        BookTitle = "Tết ở làng Địa Ngục",
                        BookPrice = 9,
                        BookNumber = 100,
                        BookDetails = "Kích thước tiểu thuyết phù hợp để đọc và cầm nắm.\nSố trang đủ dài và chi tiết để mang đến một câu chuyện sâu sắc.\nBìa mềm dễ dàng cầm nắm và vận chuyển.",
                        PublisherId = 2
                    },
                    new Book
                    {
                        BookTitle = "Harvard Bốn Rưỡi Sáng",
                        BookPrice = 10,
                        BookNumber = 100,
                        BookDetails = "Hình ảnh Harvard thu hút và tạo sự quan tâm.\nChứa nhiều chỉ dẫn và thông điệp thực dụng và bay bổng.\nKhuyến khích việc tạo lập niềm tin và tự tin trong cuộc sống.",
                        PublisherId = 1
                    },
                    new Book
                    {
                        BookTitle = "Sức Hút Của Sự Điềm Tĩnh",
                        BookPrice = 12,
                        BookNumber = 100,
                        BookDetails = "Xây dựng sự điềm tĩnh trong hành động, lời nói và thái độ.\nPhát triển khả năng làm chủ cảm xúc và tạo ra khí chất riêng.\nTác giả có kinh nghiệm và kiến thức sâu sắc về vấn đề này.",
                        PublisherId = 1
                    },
                    new Book
                    {
                        BookTitle = "Đắc Nhân Tâm",
                        BookPrice = 17,
                        BookNumber = 100,
                        BookDetails = "Bản dịch hoàn hảo nhất, dễ hiểu và gần gũi.\nCung cấp nguyên tắc vàng về giao tiếp và phát triển bản thân.\nTruyền cảm hứng và thay đổi cuộc sống hàng triệu người.",
                        PublisherId = 3
                    },
                    new Book
                    {
                        BookTitle = "Thao Túng Tâm Lý Trong Tình Yêu",
                        BookPrice = 19,
                        BookNumber = 100,
                        BookDetails = "Cuốn sách dựa trên câu chuyện đời thực, giúp bạn đồng cảm và hiểu rõ hơn về tình huống.\nLời khuyên từ những người đã trải qua tổn thương, giúp bạn tìm đến giải thoát.\nNhận ra các hành vi thao túng, giúp bạn tỉnh táo và không rơi vào khổ sở.",
                        PublisherId = 2
                    },
                    new Book
                    {
                        BookTitle = "Giao Tiếp Thông Minh Nói Đâu Trúng Đó",
                        BookPrice = 11,
                        BookNumber = 100,
                        BookDetails = "Phương pháp luyện tập hữu ích để nâng cao kỹ năng giao tiếp.\nTruyền đạt thông điệp súc tích và thu hút đối tượng nghe.\nCung cấp phương pháp giảm thiểu ngôn ngữ và tạo lời nói trọng tâm.",
                        PublisherId = 1
                    },
                    new Book
                    {
                        BookTitle = "Cách Đánh Thức Con Người Phi Thường Trong Bạn",
                        BookPrice = 12,
                        BookNumber = 100,
                        BookDetails = "Tác giả thành đạt và là nhân chứng sống về sự phi thường.\nChia sẻ bí quyết thành công và khuyến khích khai thác sức mạnh bên trong.\nGiới thiệu 3 nguyên tắc nền tảng và 5 khía cạnh để phát triển cuộc sống.",
                        PublisherId = 1
                    },

                    });
                    context.SaveChanges();
                }

                if (!context.ImageBooks.Any())
                {
                    context.ImageBooks.AddRange(new List<ImageBook>()
                    {
                        new ImageBook
                    {
                        BookId = 1,
                        BookImage1 = "book-1-1.png",
                        BookImage2 = "book-1-2.png",
                        BookImage3 = "book-1-3.png",
                        BookImage4 = "book-1-4.png",
                        BookImage5 = "book-1-5.png",
                        BookImage6 = "book-1-6.png",
                        BookImage7 = "book-1-7.png"
                    },
                    new ImageBook
                    {
                        BookId = 2,
                        BookImage1 = "book-2-1.png",
                        BookImage2 = "book-2-2.png",
                        BookImage3 = "book-2-3.png",
                        BookImage4 = "book-2-4.png",
                        BookImage5 = "book-2-5.png",
                        BookImage6 = "book-2-6.png",
                        BookImage7 = "book-2-7.png"
                    },
                    new ImageBook
                    {
                        BookId = 3,
                        BookImage1 = "book-3-1.png",
                        BookImage2 = "book-3-2.png",
                        BookImage3 = "book-3-3.png",
                        BookImage4 = "book-3-4.png",
                        BookImage5 = "book-3-5.png",
                        BookImage6 = "book-3-6.png",
                        BookImage7 = "book-3-7.png"
                    },
                    new ImageBook
                    {
                        BookId = 4,
                        BookImage1 = "book-4-1.png",
                        BookImage2 = "book-4-2.png",
                        BookImage3 = "book-4-3.png",
                        BookImage4 = "book-4-4.png",
                        BookImage5 = "book-4-5.png",
                        BookImage6 = "book-4-6.png",
                        BookImage7 = "book-4-7.png"
                    },
                    new ImageBook
                    {
                        BookId = 5,
                        BookImage1 = "book-5-1.png",
                        BookImage2 = "book-5-2.png",
                        BookImage3 = "book-5-3.png",
                        BookImage4 = "book-5-4.png",
                        BookImage5 = "book-5-5.png",
                        BookImage6 = "book-5-6.png",
                        BookImage7 = "book-5-7.png"
                    },
                    new ImageBook
                    {
                        BookId = 6,
                        BookImage1 = "book-6-1.png",
                        BookImage2 = "book-6-2.png",
                        BookImage3 = "book-6-3.png",
                        BookImage4 = "book-6-4.png",
                        BookImage5 = "book-6-5.png",
                        BookImage6 = "book-6-6.png",
                        BookImage7 = "book-6-7.png"
                    },
                    new ImageBook
                    {
                        BookId = 7,
                        BookImage1 = "book-7-1.png",
                        BookImage2 = "book-7-2.png",
                        BookImage3 = "book-7-3.png",
                        BookImage4 = "book-7-4.png",
                        BookImage5 = "book-7-5.png",
                        BookImage6 = "book-7-6.png",
                        BookImage7 = "book-7-7.png"
                    },
                    new ImageBook
                    {
                        BookId = 8,
                        BookImage1 = "book-8-1.png",
                        BookImage2 = "book-8-2.png",
                        BookImage3 = "book-8-3.png",
                        BookImage4 = "book-8-4.png",
                        BookImage5 = "book-8-5.png",
                        BookImage6 = "book-8-6.png",
                        BookImage7 = "book-8-7.png"
                    },
                    new ImageBook
                    {
                        BookId = 9,
                        BookImage1 = "book-9-1.png",
                        BookImage2 = "book-9-2.png",
                        BookImage3 = "book-9-3.png",
                        BookImage4 = "book-9-4.png",
                        BookImage5 = "book-9-5.png",
                        BookImage6 = "book-9-6.png",
                        BookImage7 = "book-9-7.png"
                    },
                    new ImageBook
                    {
                        BookId = 10,
                        BookImage1 = "book-10-1.png",
                        BookImage2 = "book-10-2.png",
                        BookImage3 = "book-10-3.png",
                        BookImage4 = "book-10-4.png",
                        BookImage5 = "book-10-5.png",
                        BookImage6 = "book-10-6.png",
                        BookImage7 = "book-10-7.png"
                    },
                    new ImageBook
                    {
                        BookId = 11,
                        BookImage1 = "book-11-1.png",
                        BookImage2 = "book-11-2.png",
                        BookImage3 = "book-11-3.png",
                        BookImage4 = "book-11-4.png",
                        BookImage5 = "book-11-5.png",
                        BookImage6 = "book-11-6.png",
                        BookImage7 = "book-11-7.png"
                    },
                    new ImageBook
                    {
                        BookId = 12,
                        BookImage1 = "book-12-1.png",
                        BookImage2 = "book-12-2.png",
                        BookImage3 = "book-12-3.png",
                        BookImage4 = "book-12-4.png",
                        BookImage5 = "book-12-5.png",
                        BookImage6 = "book-12-6.png",
                        BookImage7 = "book-12-7.png"
                    },
                    new ImageBook
                    {
                        BookId = 13,
                        BookImage1 = "book-13-1.png",
                        BookImage2 = "book-13-2.png",
                        BookImage3 = "book-13-3.png",
                        BookImage4 = "book-13-4.png",
                        BookImage5 = "book-13-5.png",
                        BookImage6 = "book-13-6.png",
                        BookImage7 = "book-13-7.png"
                    },
                    new ImageBook
                    {
                        BookId = 14,
                        BookImage1 = "book-14-1.png",
                        BookImage2 = "book-14-2.png",
                        BookImage3 = "book-14-3.png",
                        BookImage4 = "book-14-4.png",
                        BookImage5 = "book-14-5.png",
                        BookImage6 = "book-14-6.png",
                        BookImage7 = "book-14-7.png"
                    },
                    new ImageBook
                    {
                        BookId = 15,
                        BookImage1 = "book-15-1.png",
                        BookImage2 = "book-15-2.png",
                        BookImage3 = "book-15-3.png",
                        BookImage4 = "book-15-4.png",
                        BookImage5 = "book-15-5.png",
                        BookImage6 = "book-15-6.png",
                        BookImage7 = "book-15-7.png"
                    },
                    new ImageBook
                    {
                        BookId = 16,
                        BookImage1 = "book-16-1.png",
                        BookImage2 = "book-16-2.png",
                        BookImage3 = "book-16-3.png",
                        BookImage4 = "book-16-4.png",
                        BookImage5 = "book-16-5.png",
                        BookImage6 = "book-16-6.png",
                        BookImage7 = "book-16-7.png"
                    },
                    new ImageBook
                    {
                        BookId = 17,
                        BookImage1 = "book-17-1.png",
                        BookImage2 = "book-17-2.png",
                        BookImage3 = "book-17-3.png",
                        BookImage4 = "book-17-4.png",
                        BookImage5 = "book-17-5.png",
                        BookImage6 = "book-17-6.png",
                        BookImage7 = "book-17-7.png"
                    },
                    new ImageBook
                    {
                        BookId = 18,
                        BookImage1 = "book-18-1.png",
                        BookImage2 = "book-18-2.png",
                        BookImage3 = "book-18-3.png",
                        BookImage4 = null,
                        BookImage5 = null,
                        BookImage6 = null,
                        BookImage7 = null
                    },
                    new ImageBook
                    {
                        BookId = 19,
                        BookImage1 = "book-19-1.png",
                        BookImage2 = "book-19-2.png",
                        BookImage3 = "book-19-3.png",
                        BookImage4 = null,
                        BookImage5 = null,
                        BookImage6 = null,
                        BookImage7 = null
                    },
                    new ImageBook
                    {
                        BookId = 20,
                        BookImage1 = "book-20-1.png",
                        BookImage2 = "book-20-2.png",
                        BookImage3 = "book-20-3.png",
                        BookImage4 = null,
                        BookImage5 = null,
                        BookImage6 = null,
                        BookImage7 = null
                    },
                    new ImageBook
                    {
                        BookId = 21,
                        BookImage1 = "book-21-1.png",
                        BookImage2 = null,
                        BookImage3 = null,
                        BookImage4 = null,
                        BookImage5 = null,
                        BookImage6 = null,
                        BookImage7 = null
                    },
                    new ImageBook
                    {
                        BookId = 22,
                        BookImage1 = "book-22-1.png",
                        BookImage2 = "book-22-2.png",
                        BookImage3 = "book-22-3.png",
                        BookImage4 = null,
                        BookImage5 = null,
                        BookImage6 = null,
                        BookImage7 = null
                    },
                    new ImageBook
                    {
                        BookId = 23,
                        BookImage1 = "book-23-1.png",
                        BookImage2 = "book-23-2.png",
                        BookImage3 = "book-23-3.png",
                        BookImage4 = "book-23-4.png",
                        BookImage5 = null,
                        BookImage6 = null,
                        BookImage7 = null
                    },
                    new ImageBook
                    {
                        BookId = 24,
                        BookImage1 = "book-24-1.png",
                        BookImage2 = "book-24-2.png",
                        BookImage3 = null,
                        BookImage4 = null,
                        BookImage5 = null,
                        BookImage6 = null,
                        BookImage7 = null
                    },
                    new ImageBook
                    {
                        BookId = 25,
                        BookImage1 = "book-25-1.png",
                        BookImage2 = "book-25-2.png",
                        BookImage3 = "book-25-3.png",
                        BookImage4 = null,
                        BookImage5 = null,
                        BookImage6 = null,
                        BookImage7 = null
                    },
                    new ImageBook
                    {
                        BookId = 26,
                        BookImage1 = "book-26-1.png",
                        BookImage2 = "book-26-2.png",
                        BookImage3 = "book-26-3.png",
                        BookImage4 = "book-26-4.png",
                        BookImage5 = "book-26-5.png",
                        BookImage6 = null,
                        BookImage7 = null
                    },
                    new ImageBook
                    {
                        BookId = 27,
                        BookImage1 = "book-27-1.png",
                        BookImage2 = "book-27-2.png",
                        BookImage3 = "book-27-3.png",
                        BookImage4 = "book-27-4.png",
                        BookImage5 = "book-27-5.png",
                        BookImage6 = "book-27-6.png",
                        BookImage7 = "book-27-7.png"
                    },
                    new ImageBook
                    {
                        BookId = 28,
                        BookImage1 = "book-28-1.png",
                        BookImage2 = "book-28-2.png",
                        BookImage3 = "book-28-3.png",
                        BookImage4 = null,
                        BookImage5 = null,
                        BookImage6 = null,
                        BookImage7 = null
                    },
                    new ImageBook
                    {
                        BookId = 29,
                        BookImage1 = "book-29-1.png",
                        BookImage2 = "book-29-2.png",
                        BookImage3 = "book-29-3.png",
                        BookImage4 = "book-29-4.png",
                        BookImage5 = "book-29-5.png",
                        BookImage6 = "book-29-6.png",
                        BookImage7 = null
                    },
                    new ImageBook
                    {
                        BookId = 30,
                        BookImage1 = "book-30-1.png",
                        BookImage2 = "book-30-2.png",
                        BookImage3 = "book-30-3.png",
                        BookImage4 = null,
                        BookImage5 = null,
                        BookImage6 = null,
                        BookImage7 = null
                    },


                    });
                    context.SaveChanges();
                }

                if (!context.CategoryBooks.Any())
                {
                    context.CategoryBooks.AddRange(new List<CategoryBook>()
                    {
                        new CategoryBook { CategoryId = 1, BookId = 1 },
                        new CategoryBook { CategoryId = 4, BookId = 1 },
                        new CategoryBook { CategoryId = 3, BookId = 2 },
                        new CategoryBook { CategoryId = 2, BookId = 3 },
                        new CategoryBook { CategoryId = 4, BookId = 3 },
                        new CategoryBook { CategoryId = 9, BookId = 4 },
                        new CategoryBook { CategoryId = 8, BookId = 4 },
                        new CategoryBook { CategoryId = 4, BookId = 5 },
                        new CategoryBook { CategoryId = 7, BookId = 5 },
                        new CategoryBook { CategoryId = 3, BookId = 5 },
                        new CategoryBook { CategoryId = 5, BookId = 6 },
                        new CategoryBook { CategoryId = 7, BookId = 7 },
                        new CategoryBook { CategoryId = 12, BookId = 7 },
                        new CategoryBook { CategoryId = 2, BookId = 8 },
                        new CategoryBook { CategoryId = 7, BookId = 9 },
                        new CategoryBook { CategoryId = 8, BookId = 9 },
                        new CategoryBook { CategoryId = 9, BookId = 9 },
                        new CategoryBook { CategoryId = 10, BookId = 10 },
                        new CategoryBook { CategoryId = 11, BookId = 10 },
                        new CategoryBook { CategoryId = 1, BookId = 10 },
                        new CategoryBook { CategoryId = 12, BookId = 11 },
                        new CategoryBook { CategoryId = 10, BookId = 11 },
                        new CategoryBook { CategoryId = 3, BookId = 12 },
                        new CategoryBook { CategoryId = 6, BookId = 13 },
                        new CategoryBook { CategoryId = 3, BookId = 13 },
                        new CategoryBook { CategoryId = 6, BookId = 14 },
                        new CategoryBook { CategoryId = 8, BookId = 14 },
                        new CategoryBook { CategoryId = 11, BookId = 15 },
                        new CategoryBook { CategoryId = 1, BookId = 15 },
                        new CategoryBook { CategoryId = 10, BookId = 15 },
                        new CategoryBook { CategoryId = 11, BookId = 16 },
                        new CategoryBook { CategoryId = 6, BookId = 17 },
                        new CategoryBook { CategoryId = 8, BookId = 17 },
                        new CategoryBook { CategoryId = 10, BookId = 17 },
                        new CategoryBook { CategoryId = 12, BookId = 18 },
                        new CategoryBook { CategoryId = 1, BookId = 18 },
                        new CategoryBook { CategoryId = 3, BookId = 19 },
                        new CategoryBook { CategoryId = 5, BookId = 20 },
                        new CategoryBook { CategoryId = 7, BookId = 21 },
                        new CategoryBook { CategoryId = 9, BookId = 22 },
                        new CategoryBook { CategoryId = 11, BookId = 22 },
                        new CategoryBook { CategoryId = 2, BookId = 23 },
                        new CategoryBook { CategoryId = 4, BookId = 23 },
                        new CategoryBook { CategoryId = 6, BookId = 23 },
                        new CategoryBook { CategoryId = 8, BookId = 24 },
                        new CategoryBook { CategoryId = 10, BookId = 24 },
                        new CategoryBook { CategoryId = 12, BookId = 24 },
                        new CategoryBook { CategoryId = 1, BookId = 24 },
                        new CategoryBook { CategoryId = 3, BookId = 25 },
                        new CategoryBook { CategoryId = 5, BookId = 25 },
                        new CategoryBook { CategoryId = 7, BookId = 25 },
                        new CategoryBook { CategoryId = 9, BookId = 26 },
                        new CategoryBook { CategoryId = 11, BookId = 26 },
                        new CategoryBook { CategoryId = 2, BookId = 26 },
                        new CategoryBook { CategoryId = 4, BookId = 27 },
                        new CategoryBook { CategoryId = 6, BookId = 27 },
                        new CategoryBook { CategoryId = 8, BookId = 27 },
                        new CategoryBook { CategoryId = 10, BookId = 28 },
                        new CategoryBook { CategoryId = 12, BookId = 28 },
                        new CategoryBook { CategoryId = 1, BookId = 29 },
                        new CategoryBook { CategoryId = 3, BookId = 29 },
                        new CategoryBook { CategoryId = 5, BookId = 29 },
                        new CategoryBook { CategoryId = 7, BookId = 30 },
                        new CategoryBook { CategoryId = 9, BookId = 30 },
                        new CategoryBook { CategoryId = 11, BookId = 30 }

                    });
                    context.SaveChanges();
                }

                if (!context.Carts.Any())
                {
                    context.Carts.AddRange(new List<Cart>()
                    {
                        new Cart { BookId = 1, CustomerId = 1, Number = 1 },
                        new Cart { BookId = 2, CustomerId = 1, Number = 1 }

                    });
                    context.SaveChanges();
                }

                if (!context.Orders.Any())
                {
                    context.Orders.AddRange(new List<Order>()
                    {
                        new Order { CustomerId = 1, OrderDate = DateTime.Parse("2023-01-15") },
                        new Order { CustomerId = 1, OrderDate = DateTime.Parse("2023-01-16") }

                    });
                    context.SaveChanges();
                }

                if (!context.OrderDetails.Any())
                {
                    context.OrderDetails.AddRange(new List<OrderDetail>()
                    {
                        new OrderDetail { BookId = 1, Quantity = 1 },
                        new OrderDetail { BookId = 2, Quantity = 1 }

                    });
                    context.SaveChanges();
                }

                if (!context.StoreOwnerBooks.Any())
                {
                    context.StoreOwnerBooks.AddRange(new List<StoreOwnerBook>()
                    {
                        new StoreOwnerBook { StoreOwnerId = 1, BookId = 1 },
                        new StoreOwnerBook { StoreOwnerId = 1, BookId = 2 },
                        new StoreOwnerBook { StoreOwnerId = 1, BookId = 3 },
                        new StoreOwnerBook { StoreOwnerId = 2, BookId = 4 },
                        new StoreOwnerBook { StoreOwnerId = 2, BookId = 5 },
                        new StoreOwnerBook { StoreOwnerId = 2, BookId = 6 },
                        new StoreOwnerBook { StoreOwnerId = 3, BookId = 7 },
                        new StoreOwnerBook { StoreOwnerId = 3, BookId = 8 },
                        new StoreOwnerBook { StoreOwnerId = 3, BookId = 9 },
                        new StoreOwnerBook { StoreOwnerId = 3, BookId = 10 },
                        new StoreOwnerBook { StoreOwnerId = 1, BookId = 11 },
                        new StoreOwnerBook { StoreOwnerId = 1, BookId = 12 },
                        new StoreOwnerBook { StoreOwnerId = 1, BookId = 13 },
                        new StoreOwnerBook { StoreOwnerId = 2, BookId = 14 },
                        new StoreOwnerBook { StoreOwnerId = 2, BookId = 15 },
                        new StoreOwnerBook { StoreOwnerId = 2, BookId = 16 },
                        new StoreOwnerBook { StoreOwnerId = 3, BookId = 17 },
                        new StoreOwnerBook { StoreOwnerId = 3, BookId = 18 },
                        new StoreOwnerBook { StoreOwnerId = 3, BookId = 19 },
                        new StoreOwnerBook { StoreOwnerId = 3, BookId = 20 },
                        new StoreOwnerBook { StoreOwnerId = 1, BookId = 21 },
                        new StoreOwnerBook { StoreOwnerId = 1, BookId = 22 },
                        new StoreOwnerBook { StoreOwnerId = 1, BookId = 23 },
                        new StoreOwnerBook { StoreOwnerId = 2, BookId = 24 },
                        new StoreOwnerBook { StoreOwnerId = 2, BookId = 25 },
                        new StoreOwnerBook { StoreOwnerId = 2, BookId = 26 },
                        new StoreOwnerBook { StoreOwnerId = 3, BookId = 27 },
                        new StoreOwnerBook { StoreOwnerId = 3, BookId = 28 },
                        new StoreOwnerBook { StoreOwnerId = 3, BookId = 29 },
                        new StoreOwnerBook { StoreOwnerId = 3, BookId = 30 }

                    });
                    context.SaveChanges();
                }

            }
        }

        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        //Roles
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //        //Users
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
        //        string adminUserEmail = "misanthrop@gmail.com";

        //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if (adminUser == null)
        //        {
        //            var newAdminUser = new User()
        //            {
        //                UserFullName = "Lê Nguyễn Quốc Khánh",
        //                UserEmail = adminUserEmail,
        //                UserType = 1,
        //                UserImage = "acount1.png",
        //                EmailConfirmed = true,
        //            };
        //            await userManager.CreateAsync(newAdminUser, "misanthrop@");
        //            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        //        }

        //        string appUserEmail = "NguyenVinhPhuc123@gmail.com";

        //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //        if (appUser == null)
        //        {
        //            var newAppUser = new User()
        //            {

        //            };
        //            await userManager.CreateAsync(newAppUser, "NguyenVinhPhuc123@");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }

        //        string appUserEmail1 = "BuiHuuNghia123@gmail.com";

        //        var appUser1 = await userManager.FindByEmailAsync(appUserEmail1);
        //        if (appUser1 == null)
        //        {
        //            var newAppUser = new User()
        //            {

        //            };
        //            await userManager.CreateAsync(newAppUser, "BuiHuuNghia123@");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }

        //        string appUserEmail2 = "VuTienPhat123@gmail.com";

        //        var appUser2 = await userManager.FindByEmailAsync(appUserEmail2);
        //        if (appUser2 == null)
        //        {
        //            var newAppUser = new User()
        //            {

        //            };
        //            await userManager.CreateAsync(newAppUser, "VuTienPhat123@");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }

        //        string appUserEmail3 = "TrinhAnhDuong123@gmail.com";

        //        var appUser3 = await userManager.FindByEmailAsync(appUserEmail3);
        //        if (appUser3 == null)
        //        {
        //            var newAppUser = new User()
        //            {

        //            };
        //            await userManager.CreateAsync(newAppUser, "TrinhAnhDuong123@");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }
        //    }
        //}
    }
}