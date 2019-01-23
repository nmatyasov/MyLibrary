using BooksOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
using WpfApplication1.Converters;

namespace BooksOrganizer.Database
{
    public class Seeds
    {
        private static BitmapImage LoadImage(string filename)
        {
            return new BitmapImage(new Uri("pack://application:,,,/Images/" + filename));
        }
        public static void Run()
        {
            DataContext db = new DataContext();
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {

                    BookGenre _bg1 = new BookGenre(); _bg1.BookId = 1; _bg1.GenreId = 30; db.BookGenries.Add(_bg1);
                    BookGenre _bg2 = new BookGenre(); _bg2.BookId = 2; _bg2.GenreId = 12; db.BookGenries.Add(_bg2);
                    BookGenre _bg3 = new BookGenre(); _bg3.BookId = 3; _bg3.GenreId = 30; db.BookGenries.Add(_bg3);
                    BookGenre _bg4 = new BookGenre(); _bg4.BookId = 4; _bg4.GenreId = 17; db.BookGenries.Add(_bg4);
                    BookGenre _bg5 = new BookGenre(); _bg5.BookId = 5; _bg5.GenreId = 12; db.BookGenries.Add(_bg5);


                    BookAuthor _ba1 = new BookAuthor(); _ba1.BookId = 1; _ba1.AuthorId = 1; db.BookAuthors.Add(_ba1);
                    BookAuthor _ba2 = new BookAuthor(); _ba2.BookId = 1; _ba1.AuthorId = 2; db.BookAuthors.Add(_ba2);
                    BookAuthor _ba3 = new BookAuthor(); _ba3.BookId = 2; _ba1.AuthorId = 3; db.BookAuthors.Add(_ba3);
                    BookAuthor _ba4 = new BookAuthor(); _ba4.BookId = 3; _ba4.AuthorId = 4; db.BookAuthors.Add(_ba4);
                    BookAuthor _ba5 = new BookAuthor(); _ba5.BookId = 4; _ba5.AuthorId = 5; db.BookAuthors.Add(_ba5);
                    BookAuthor _ba6 = new BookAuthor(); _ba6.BookId = 4; _ba6.AuthorId = 6; db.BookAuthors.Add(_ba6);
                    BookAuthor _ba7 = new BookAuthor(); _ba7.BookId = 4; _ba7.AuthorId = 7; db.BookAuthors.Add(_ba7);
                    BookAuthor _ba8 = new BookAuthor(); _ba8.BookId = 5; _ba8.AuthorId = 8; db.BookAuthors.Add(_ba8);
                    BookAuthor _ba9 = new BookAuthor(); _ba9.BookId = 5; _ba9.AuthorId = 9; db.BookAuthors.Add(_ba9);
                    BookAuthor _ba10 = new BookAuthor(); _ba10.BookId = 5; _ba10.AuthorId = 10; db.BookAuthors.Add(_ba10);


                    BookISBN _bi1 = new BookISBN(); _bi1.BookId = 1; _bi1.ISBNId = 1; db.BookISBNs.Add(_bi1);
                    BookISBN _bi2 = new BookISBN(); _bi2.BookId = 1; _bi1.ISBNId = 2; db.BookISBNs.Add(_bi2);
                    BookISBN _bi3 = new BookISBN(); _bi3.BookId = 2; _bi3.ISBNId = 3; db.BookISBNs.Add(_bi3);
                    BookISBN _bi4 = new BookISBN(); _bi4.BookId = 2; _bi4.ISBNId = 4; db.BookISBNs.Add(_bi4);
                    BookISBN _bi5 = new BookISBN(); _bi5.BookId = 3; _bi5.ISBNId = 5; db.BookISBNs.Add(_bi5);
                    BookISBN _bi6 = new BookISBN(); _bi6.BookId = 3; _bi6.ISBNId = 6; db.BookISBNs.Add(_bi6);
                    BookISBN _bi7 = new BookISBN(); _bi7.BookId = 4; _bi7.ISBNId = 7; db.BookISBNs.Add(_bi7);
                    BookISBN _bi8 = new BookISBN(); _bi8.BookId = 4; _bi8.ISBNId = 8; db.BookISBNs.Add(_bi8);
                    BookISBN _bi9 = new BookISBN(); _bi9.BookId = 5; _bi9.ISBNId = 9; db.BookISBNs.Add(_bi9);

                    BookPublishier _bp1 = new BookPublishier(); _bp1.BookId = 1; _bp1.PublisherId = 3; db.BookPublishiers.Add(_bp1);
                    BookPublishier _bp2 = new BookPublishier(); _bp2.BookId = 2; _bp2.PublisherId = 1; db.BookPublishiers.Add(_bp2);
                    BookPublishier _bp3 = new BookPublishier(); _bp3.BookId = 3; _bp3.PublisherId = 4; db.BookPublishiers.Add(_bp3);
                    BookPublishier _bp4 = new BookPublishier(); _bp4.BookId = 4; _bp4.PublisherId = 2; db.BookPublishiers.Add(_bp4);
                    BookPublishier _bp5 = new BookPublishier(); _bp5.BookId = 5; _bp5.PublisherId = 5; db.BookPublishiers.Add(_bp5);



                    Genre _g1 = new Genre(); _g1.GenreId = 1; _g1.Name = "Arts & Photography"; db.Genries.Add(_g1);
                    Genre _g2 = new Genre(); _g2.GenreId = 2; _g2.Name = "Audible Audiobooks"; db.Genries.Add(_g2);
                    Genre _g3 = new Genre(); _g3.GenreId = 3; _g3.Name = "Biographies & Memoirs"; db.Genries.Add(_g3);
                    Genre _g4 = new Genre(); _g4.GenreId = 4; _g4.Name = "Books on CD"; db.Genries.Add(_g4);
                    Genre _g5 = new Genre(); _g5.GenreId = 5; _g5.Name = "Business & Money"; db.Genries.Add(_g5);
                    Genre _g6 = new Genre(); _g6.GenreId = 6; _g6.Name = "Calendars"; db.Genries.Add(_g6);
                    Genre _g7 = new Genre(); _g7.GenreId = 7; _g7.Name = "Children's Books"; db.Genries.Add(_g7);
                    Genre _g8 = new Genre(); _g8.GenreId = 8; _g8.Name = "Christian Books & Bibles"; db.Genries.Add(_g8);
                    Genre _g9 = new Genre(); _g9.GenreId = 9; _g9.Name = "Comics & Graphic Novels"; db.Genries.Add(_g9);
                    Genre _g10 = new Genre(); _g10.GenreId = 10; _g10.Name = "Computers & Technology"; db.Genries.Add(_g10);
                    Genre _g11 = new Genre(); _g11.GenreId = 11; _g11.Name = "Cookbooks, Food & Wine"; db.Genries.Add(_g11);

                    Genre _g12 = new Genre()
                    {
                        GenreId = 12,
                        Name = "Crafts, Hobbies & Home",
                        BookGenries = new List<BookGenre>()
                         {
                            _bg2
                         },
                    };
                    db.Genries.Add(_g12);

                    Genre _g13 = new Genre(); _g13.GenreId = 13; _g13.Name = "Deals in Books"; db.Genries.Add(_g13);
                    Genre _g14 = new Genre(); _g14.GenreId = 14; _g14.Name = "Education & Teaching"; db.Genries.Add(_g14);
                    Genre _g15 = new Genre(); _g15.GenreId = 15; _g15.Name = "Engineering & Transportation"; db.Genries.Add(_g15);
                    Genre _g16 = new Genre(); _g16.GenreId = 16; _g16.Name = "Health, Fitness & Dieting"; db.Genries.Add(_g16);
                    Genre _g17 = new Genre()
                    {
                        GenreId = 17,
                        Name = "History",
                        BookGenries = new List<BookGenre>()
                         {
                            _bg4
                         }
                    };
                    db.Genries.Add(_g17);
                    Genre _g18 = new Genre(); _g18.GenreId = 18; _g18.Name = "Humor & Entertainment"; db.Genries.Add(_g18);
                    Genre _g19 = new Genre(); _g19.GenreId = 19; _g19.Name = "Law"; db.Genries.Add(_g19);
                    Genre _g20 = new Genre(); _g20.GenreId = 20; _g20.Name = "Lesbian, Gay, Bisexual & Transgender Books"; db.Genries.Add(_g20);
                    Genre _g21 = new Genre(); _g21.GenreId = 21; _g21.Name = "Libros en espanol"; db.Genries.Add(_g21);
                    Genre _g22 = new Genre(); _g22.GenreId = 22; _g22.Name = "Literature & Fiction"; db.Genries.Add(_g22);
                    Genre _g23 = new Genre(); _g23.GenreId = 23; _g23.Name = "Medical Books"; db.Genries.Add(_g23);
                    Genre _g24 = new Genre(); _g24.GenreId = 24; _g24.Name = "Mystery, Thriller & Suspense"; db.Genries.Add(_g24);
                    Genre _g25 = new Genre(); _g25.GenreId = 25; _g25.Name = "Parenting & Relationships"; db.Genries.Add(_g25);
                    Genre _g26 = new Genre(); _g26.GenreId = 26; _g26.Name = "Politics & Social Sciences"; db.Genries.Add(_g26);
                    Genre _g27 = new Genre(); _g27.GenreId = 27; _g27.Name = "Reference"; db.Genries.Add(_g27);
                    Genre _g28 = new Genre(); _g28.GenreId = 28; _g28.Name = "Religion & Spirituality"; db.Genries.Add(_g28);
                    Genre _g29 = new Genre(); _g29.GenreId = 29; _g29.Name = "Romance"; db.Genries.Add(_g29);
                    Genre _g30 = new Genre()
                    {
                        GenreId = 30,
                        Name = "Science & Math",
                        BookGenries = new List<BookGenre>()
                         {
                            _bg1,
                            _bg3
                         },
                    };
                    db.Genries.Add(_g30);
                    Genre _g31 = new Genre(); _g31.GenreId = 31; _g31.Name = "Science Fiction & Fantasy"; db.Genries.Add(_g31);
                    Genre _g32 = new Genre(); _g32.GenreId = 32; _g32.Name = "Self - Help"; db.Genries.Add(_g32);
                    Genre _g33 = new Genre(); _g33.GenreId = 33; _g33.Name = "Sports & Outdoors"; db.Genries.Add(_g33);
                    Genre _g34 = new Genre(); _g34.GenreId = 34; _g34.Name = "Teens"; db.Genries.Add(_g34);
                    Genre _g35 = new Genre(); _g35.GenreId = 35; _g35.Name = "Test Preparation"; db.Genries.Add(_g35);
                    Genre _g36 = new Genre(); _g36.GenreId = 36; _g36.Name = "Textbooks"; db.Genries.Add(_g36);
                    Genre _g37 = new Genre(); _g37.GenreId = 37; _g37.Name = "Travel"; db.Genries.Add(_g37);



                    Author _a1 = new Author()
                    {
                        AuthorId = 1,
                        Name = "Peter J. Olver",
                        BookAuthors = new List<BookAuthor>()
                         {
                            _ba1
                         }
                    };
                    db.Authors.Add(_a1);
                    Author _a2 = new Author()
                    {
                        AuthorId = 2,
                        Name = "Cheri Shakiban",
                        BookAuthors = new List<BookAuthor>()
                         {
                            _ba2
                         }
                    };
                    db.Authors.Add(_a2);
                    Author _a3 = new Author()
                    {
                        AuthorId = 3,
                        Name = "J. Benton Jones, Jr.",
                        BookAuthors = new List<BookAuthor>()
                         {
                            _ba3
                         }
                    };
                    db.Authors.Add(_a3);
                    Author _a4 = new Author()
                    {
                        AuthorId = 4,
                        Name = "Dr. Norman Matloff",
                        BookAuthors = new List<BookAuthor>()
                         {
                            _ba4
                         }
                    };
                    db.Authors.Add(_a4);
                    Author _a5 = new Author()
                    {
                        AuthorId = 5,
                        Name = "EJames Kinnear (Author)",
                        BookAuthors = new List<BookAuthor>()
                         {
                            _ba5
                         }
                    };
                    db.Authors.Add(_a5);
                    Author _a6 = new Author()
                    {
                        AuthorId = 6,
                        Name = "Stephen Sewell (Author)",
                        BookAuthors = new List<BookAuthor>()
                         {
                            _ba6
                         }
                    };
                    db.Authors.Add(_a6);
                    Author _a7 = new Author()
                    {
                        AuthorId = 7,
                        Name = "Andrey Aksenov (Illustrator)",
                        BookAuthors = new List<BookAuthor>()
                         {
                            _ba7
                         }
                    };
                    db.Authors.Add(_a7);
                    Author _a8 = new Author()
                    {
                        AuthorId = 8,
                        Name = "Elizabeth Letcavage",
                        BookAuthors = new List<BookAuthor>()
                         {
                            _ba8
                         }
                    };
                    db.Authors.Add(_a8);
                    Author _a9 = new Author()
                    {
                        AuthorId = 9,
                        Name = "Alan Wycheck",
                        BookAuthors = new List<BookAuthor>()
                         {
                            _ba9
                         }
                    };
                    db.Authors.Add(_a9);
                    Author _a10 = new Author()
                    {
                        AuthorId = 10,
                        Name = " William Hollis",
                        BookAuthors = new List<BookAuthor>()
                         {
                            _ba10
                         }
                    };
                    db.Authors.Add(_a10);

                    ISBN _i1 = new ISBN()
                    {
                        ISBNId = 1,
                        Value = "0131473824",
                        BookISBNs= new List<BookISBN>()
                         {
                            _bi1
                         }
                    };
                    db.ISBNs.Add(_i1);
                    ISBN _i2 = new ISBN()
                    {
                        ISBNId = 2,
                        Value = "978-0131473829",
                        BookISBNs = new List<BookISBN>()
                         {
                            _bi2
                         }
                    };
                    db.ISBNs.Add(_i2);
                    ISBN _i3 = new ISBN()
                    {
                        ISBNId = 3,
                        Value = "1439876681",
                        BookISBNs = new List<BookISBN>()
                         {
                            _bi3
                         }
                    };
                    db.ISBNs.Add(_i3);
                    ISBN _i4 = new ISBN()
                    {
                        ISBNId = 4,
                        Value = "978-1439876688",
                        BookISBNs = new List<BookISBN>()
                         {
                            _bi4
                         }
                    };
                    db.ISBNs.Add(_i4);
                    ISBN _i5 = new ISBN()
                    {
                        ISBNId = 5,
                        Value = "1466587016",
                        BookISBNs = new List<BookISBN>()
                         {
                            _bi5
                         }
                    };
                    db.ISBNs.Add(_i5);
                    ISBN _i6 = new ISBN()
                    {
                        ISBNId = 6,
                        Value = "978-1466587014",
                        BookISBNs = new List<BookISBN>()
                         {
                            _bi6
                         }
                    };
                    db.ISBNs.Add(_i6);
                    ISBN _i7 = new ISBN()
                    {
                        ISBNId = 7,
                        Value = "1472833309",
                        BookISBNs = new List<BookISBN>()
                         {
                            _bi7
                         }
                    };
                    db.ISBNs.Add(_i7);
                    ISBN _i8 = new ISBN()
                    {
                        ISBNId = 8,
                        Value = "978-1472833303",
                        BookISBNs = new List<BookISBN>()
                         {
                            _bi8
                         }
                    };
                    db.ISBNs.Add(_i8);
                    ISBN _i9 = new ISBN()
                    {
                        ISBNId = 9,
                        Value = "B00AVZSPYM",
                        BookISBNs = new List<BookISBN>()
                         {
                            _bi9
                         }
                    };
                    db.ISBNs.Add(_i9);


                    Publisher _p1 = new Publisher()
                    {
                        PublisherId = 1,
                        Name = "CRC Press",
                        BookPublishier = new List<BookPublishier>()
                         {
                            _bp2
                         }
                    };
                    db.Publishers.Add(_p1);
                    Publisher _p2 = new Publisher()
                    {
                        PublisherId = 2,
                        Name = "Osprey Publishing",
                        BookPublishier = new List<BookPublishier>()
                         {
                            _bp4
                         }
                    };
                    db.Publishers.Add(_p2);
                    Publisher _p3 = new Publisher()
                    {
                        PublisherId = 3,
                        Name = "Pearson",
                        BookPublishier = new List<BookPublishier>()
                         {
                            _bp1
                         }
                    };
                    db.Publishers.Add(_p3);
                    Publisher _p4 = new Publisher()
                    {
                        PublisherId = 4,
                        Name = "Chapman and Hall/CRC",
                        BookPublishier = new List<BookPublishier>()
                         {
                            _bp3
                         }
                    };
                    db.Publishers.Add(_p4);
                    Publisher _p5 = new Publisher()
                    {
                        PublisherId = 5,
                        Name = "Stackpole Books",
                        BookPublishier = new List<BookPublishier>()
                         {
                            _bp5
                         }
                    };
                    db.Publishers.Add(_p5);







                    Book _b1 = new Book()
                    {
                        BookId = 1,
                        Name = "Applied Linear Algebra",
                        Title = "Applied Linear Algebra",
                        PublishingYear = 2005,
                        Cover = Utils.ConvertBitmapSourceToByteArray(LoadImage("9780131473829.jpg")),
                        Url = "https://www.amazon.com/Applied-Linear-Algebra-Peter-Olver/dp/0131473824",
                        Pages = 736,
                        Annonce = @"This book describes basic methods and algorithms used in modern, real problems likely to be encountered by engineers and scientists - and fosters an understanding of why mathematical techniques work and how they can be derived from first principles. Assumes no previous exposure to linear algebra. Presents applications hand in hand with theory, leading readers through the reasoning that leads to the important results. Provides theorems and proofs where needed. Features abundant exercises after almost every subsection, in a wide range of difficulty. A thorough reference for engineers and scientists.",
                        BookGenries = new List<BookGenre>()
                         {
                            _bg1
                         },
                        BookAuthors = new List<BookAuthor>()
                         {
                            _ba1,
                            _ba2
                         },
                        BookPublisheirs = new List<BookPublishier>()
                         {
                           _bp1
                         },
                        BookISBNs = new List<BookISBN>()
                         {
                            _bi1,
                            _bi2
                         }
                    };
                    db.Books.Add(_b1);

                    Book _b2 = new Book()
                    {
                        BookId = 2,
                        Name = "Complete Guide Growing Plants Hydroponically",
                        Title = "Complete Guide Growing Plants Hydroponically",
                        PublishingYear = 2014,
                        Cover = Utils.ConvertBitmapSourceToByteArray(LoadImage("9781439876688.jpg")),
                        Url = "https://www.amazon.com/Complete-Guide-Growing-Plants-Hydroponically/dp/1439876681",
                        Pages = 223,
                        Annonce = @"With the continued implementation of new equipment and new concepts and methods, such as hydroponics and soilless practices, crop growth has improved and become more efficient. Focusing on the basic principles and practical growth requirements, the Complete Guide for Growing Plants Hydroponically offers valuable information for the commercial grower, the researcher, the hobbyist, and the student interested in hydroponics. It provides details on methods of growing that are applicable to a range of environmental growing systems.",
                        BookGenries = new List<BookGenre>()
                         {
                            _bg2
                         },
                        BookAuthors = new List<BookAuthor>()
                         {
                            _ba3
                         },
                        BookPublisheirs = new List<BookPublishier>()
                         {
                           _bp2
                         },
                        BookISBNs = new List<BookISBN>()
                         {
                            _bi3,
                            _bi4
                         }
                    };
                    db.Books.Add(_b2);



                    Book _b3 = new Book()
                    {
                        BookId = 3,
                        Name = "Parallel Computing Data Science Examples",
                        Title = "Parallel Computing Data Science Examples",
                        PublishingYear = 2015,
                        Cover = Utils.ConvertBitmapSourceToByteArray(LoadImage("9781466587014.jpg")),
                        Url = "https://www.amazon.com/Parallel-Computing-Data-Science-Examples/dp/1466587016",
                        Pages = 328,
                        Annonce = @"Parallel Computing for Data Science: With Examples in R, C++ and CUDA is one of the first parallel computing books to concentrate exclusively on parallel data structures, algorithms, software tools, and applications in data science. It includes examples not only from the classic n observations, p variables matrix format but also from time series, network graph models, and numerous other structures common in data science. The examples illustrate the range of issues encountered in parallel programming.",
                        BookGenries = new List<BookGenre>()
                         {
                            _bg3
                         },
                        BookAuthors = new List<BookAuthor>()
                         {
                            _ba3
                        },
                        BookPublisheirs = new List<BookPublishier>()
                         {
                           _bp3
                         },
                        BookISBNs = new List<BookISBN>()
                         {
                            _bi5,
                            _bi6
                         }

                    };
                    db.Books.Add(_b3);



                    Book _b4 = new Book()
                    {
                        BookId = 4,
                        Name = "Soviet T-54 Main Battle Tank",
                        Title = "Soviet T-54 Main Battle Tank",
                        PublishingYear = 2018,
                        Cover = Utils.ConvertBitmapSourceToByteArray(LoadImage("9781472833303.jpg")),
                        Url = "https://www.amazon.com/Soviet-T-54-Main-Battle-Tank/dp/1472833309",
                        Pages = 192,
                        Annonce = @"The menacing silhouette of the T-54 tank prowling down streets of Eastern European capitals or roaring across fields in massive exercises remains one of the most enduring images of Soviet power in the early years of the Cold War. Its sleek and unmistakable shape was a warning to any nation that wanted to stand against the USSR.",
                        BookGenries = new List<BookGenre>()
                         {
                            _bg4
                         },
                        BookAuthors = new List<BookAuthor>()
                         {
                            _ba5,
                            _ba6,
                            _ba7
                        },
                        BookPublisheirs = new List<BookPublishier>()
                         {
                           _bp4
                         },
                        BookISBNs = new List<BookISBN>()
                         {
                            _bi7,
                            _bi8
                         }


                    };
                    db.Books.Add(_b4);



                    Book _b5 = new Book()
                    {
                        BookId = 5,
                        Name = "Basic Leathercrafting Skills Started Basics",
                        Title = "Basic Leathercrafting Skills Started Basics",
                        Cover = Utils.ConvertBitmapSourceToByteArray(LoadImage("B00AVZSPYM.jpg")),
                         Url = "https://www.amazon.com/Basic-Leathercrafting-Skills-Started-Basics-ebook/dp/B00AVZSPYM",
                        Pages = 195,
                        Annonce = "Step-by-step instructions and photos illustrate basic leathercrafting techniques: choosing leather, stamping and decorating, stitching and lacing, and finishing.",
                        BookGenries = new List<BookGenre>()
                         {
                            _bg5
                         },
                        BookAuthors = new List<BookAuthor>()
                         {
                            _ba8,
                            _ba9,
                            _ba10
                        },
                        BookPublisheirs = new List<BookPublishier>()
                         {
                           _bp5
                         },
                        BookISBNs = new List<BookISBN>()
                         {
                            _bi9
                         }
                    };
                    db.Books.Add(_b5);
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                    transaction.Rollback();
                }

            }
        }
    }

}
