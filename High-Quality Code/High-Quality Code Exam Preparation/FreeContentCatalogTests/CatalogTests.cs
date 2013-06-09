namespace FreeContentCatalogTests
{
    using System;
    using System.Linq;
    using FreeContentCatalog;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        [TestCategory("Add")]
        public void AddSingleItem()
        {
            Catalog catalog = new Catalog();
            Content book = new Content(ContentType.Book, "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info");
            
            catalog.Add(book);
            
            Assert.IsNotNull(catalog);
            Assert.AreEqual(1, catalog.ElementsCount);
        }

        [TestMethod]
        [TestCategory("Add")]
        public void AddDuplicateItem()
        {
            Catalog catalog = new Catalog();
            Content book = new Content(ContentType.Book, "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info");
            
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(book);
            
            Assert.IsNotNull(catalog);
            Assert.AreEqual(4, catalog.ElementsCount);
        }

        [TestMethod]
        [TestCategory("Add")]
        public void AddManyItemsNoDuplicates()
        {
            Catalog catalog = new Catalog();
            Content book = new Content(ContentType.Book, "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info");
            Content movie = new Content(ContentType.Movie, "The Secret; Drew Heriot", "Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d");
            Content song = new Content(ContentType.Song, "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs");
            Content application = new Content(ContentType.Application, "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org");

            catalog.Add(book);
            catalog.Add(movie);
            catalog.Add(song);
            catalog.Add(application);

            Assert.IsNotNull(catalog);
            Assert.AreEqual(4, catalog.ElementsCount);
        }

        [TestMethod]
        [TestCategory("Add")]
        public void AddManyItemsAllDuplicates()
        {
            Catalog catalog = new Catalog();
            Content book = new Content(ContentType.Book, "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info");
            Content movie = new Content(ContentType.Movie, "The Secret; Drew Heriot", "Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d");
            Content song = new Content(ContentType.Song, "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs");
            Content application = new Content(ContentType.Application, "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org");

            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(movie);
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(song);
            catalog.Add(application);
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);

            Assert.IsNotNull(catalog);
            Assert.AreEqual(12, catalog.ElementsCount);
        }

        [TestMethod]
        [TestCategory("Add")]
        public void AddManyItemsSomeDuplicates()
        {
            Catalog catalog = new Catalog();
            Content book = new Content(ContentType.Book, "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info");
            Content movie = new Content(ContentType.Movie, "The Secret; Drew Heriot", "Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d");
            Content song = new Content(ContentType.Song, "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs");
            Content application = new Content(ContentType.Application, "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org");
            
            catalog.Add(book);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(movie);
            catalog.Add(movie);
            catalog.Add(book);
            catalog.Add(song);

            Assert.IsNotNull(catalog);
            Assert.AreEqual(12, catalog.ElementsCount);
        }

        [TestMethod]
        [TestCategory("GetCatalogContent")]
        public void GetContentSingleMatchingElement()
        {
            Catalog catalog = new Catalog();
            Content book = new Content(ContentType.Book, "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info");
            Content movie = new Content(ContentType.Movie, "The Secret; Drew Heriot", "Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d");
            Content song = new Content(ContentType.Song, "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs");
            Content application = new Content(ContentType.Application, "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org");

            catalog.Add(book);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(movie);
            catalog.Add(movie);
            catalog.Add(application);
            catalog.Add(song);

            int matchesCount = catalog.GetCatalogContent("Intro C#", 10000).Count();

            Assert.AreEqual(1, matchesCount);
        }

        [TestMethod]
        [TestCategory("GetCatalogContent")]
        public void ManyMatchingLessThanRequested()
        {
            Catalog catalog = new Catalog();
            Content book = new Content(ContentType.Book, "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info");
            Content movie = new Content(ContentType.Movie, "The Secret; Drew Heriot", "Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d");
            Content song = new Content(ContentType.Song, "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs");
            Content application = new Content(ContentType.Application, "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org");

            catalog.Add(book);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(movie);
            catalog.Add(movie);
            catalog.Add(application);
            catalog.Add(song);

            int matchesCount = catalog.GetCatalogContent("Firefox v.11.0", 10000).Count();

            Assert.AreEqual(4, matchesCount);
        }

        [TestMethod]
        [TestCategory("GetCatalogContent")]
        public void ManyMatchingMoreThanRequested()
        {
            Catalog catalog = new Catalog();
            Content book = new Content(ContentType.Book, "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info");
            Content movie = new Content(ContentType.Movie, "The Secret; Drew Heriot", "Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d");
            Content song = new Content(ContentType.Song, "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs");
            Content application = new Content(ContentType.Application, "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org");

            catalog.Add(book);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(movie);
            catalog.Add(movie);
            catalog.Add(application);
            catalog.Add(song);
            catalog.Add(application);

            int matchesCount = catalog.GetCatalogContent("Firefox v.11.0", 3).Count();

            Assert.AreEqual(3, matchesCount);
        }

        [TestMethod]
        [TestCategory("GetCatalogContent")]
        public void AsManyMatchingAsRequested()
        {
            Catalog catalog = new Catalog();
            Content book = new Content(ContentType.Book, "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info");
            Content movie = new Content(ContentType.Movie, "The Secret; Drew Heriot", "Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d");
            Content song = new Content(ContentType.Song, "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs");
            Content application = new Content(ContentType.Application, "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org");

            catalog.Add(book);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(movie);
            catalog.Add(movie);
            catalog.Add(application);
            catalog.Add(song);
            catalog.Add(application);

            int matchesCount = catalog.GetCatalogContent("Firefox v.11.0", 6).Count();

            Assert.AreEqual(6, matchesCount);
        }

        [TestMethod]
        [TestCategory("GetCatalogContent")]
        public void NoMatchingElements()
        {
            Catalog catalog = new Catalog();
            Content book = new Content(ContentType.Book, "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info");
            Content movie = new Content(ContentType.Movie, "The Secret; Drew Heriot", "Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d");
            Content song = new Content(ContentType.Song, "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs");
            Content application = new Content(ContentType.Application, "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org");

            catalog.Add(book);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(movie);
            catalog.Add(movie);
            catalog.Add(application);
            catalog.Add(song);
            catalog.Add(application);

            int matchesCount = catalog.GetCatalogContent("VisualStudio 2012", 6).Count();

            Assert.AreNotEqual(0, catalog.ElementsCount);
            Assert.AreEqual(0, matchesCount);
        }

        [TestMethod]
        [TestCategory("GetCatalogContent")]
        public void SomeMatchingSortingOrder()
        {
            Catalog catalog = new Catalog();
            Content book = new Content(ContentType.Book, "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info");
            Content movie = new Content(ContentType.Movie, "The Secret; Drew Heriot", "Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d");
            Content song = new Content(ContentType.Song, "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs");
            Content application = new Content(ContentType.Application, "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org");
            Content application2 = new Content(ContentType.Application, "Firefox v.11.0", "Mozilla", "1", "http://www.mozilla.org");
            Content application3 = new Content(ContentType.Application, "Firefox v.11.0", "Mozilla", "1234", "http://www.mozilla.org");

            catalog.Add(book);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(application);
            catalog.Add(application2);
            catalog.Add(application3);
            catalog.Add(application);
            catalog.Add(movie);
            catalog.Add(movie);
            catalog.Add(application3);
            catalog.Add(song);
            catalog.Add(application);

            var matches = catalog.GetCatalogContent("Firefox v.11.0", 30);
            int matchesCount = matches.Count();

            // Check sorting
            Assert.AreEqual(matches.First().Size, application2.Size);
            Assert.AreEqual(matches.Skip(1).First().Size, application3.Size);
            Assert.AreEqual(matches.Skip(3).First().Size, application.Size);

            Assert.AreEqual(6, matchesCount);
        }

        [TestMethod]
        [TestCategory("UpdateContent")]
        public void UpdateSingleMatchingElement()
        {
            Catalog catalog = new Catalog();
            Content book = new Content(ContentType.Book, "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info");
            Content movie = new Content(ContentType.Movie, "The Secret; Drew Heriot", "Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d");
            Content song = new Content(ContentType.Song, "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs");
            Content application = new Content(ContentType.Application, "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org");

            catalog.Add(book);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(movie);
            catalog.Add(movie);
            catalog.Add(song);
            catalog.Add(application);

            int updatedCount = catalog.UpdateContent("http://www.introprogramming.info", "http://www.introprogramming.info/en/");

            Assert.AreEqual(1, updatedCount);
        }

        [TestMethod]
        [TestCategory("UpdateContent")]
        public void UpdateManyMatchingElements()
        {
            Catalog catalog = new Catalog();
            Content book = new Content(ContentType.Book, "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info");
            Content movie = new Content(ContentType.Movie, "The Secret; Drew Heriot", "Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d");
            Content song = new Content(ContentType.Song, "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs");
            Content application = new Content(ContentType.Application, "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org");

            catalog.Add(book);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(book);
            catalog.Add(song);
            catalog.Add(book);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(movie);
            catalog.Add(movie);
            catalog.Add(book);
            catalog.Add(song);
            catalog.Add(book);
            catalog.Add(application);
            catalog.Add(book);
            catalog.Add(book);

            int updatedCount = catalog.UpdateContent("http://www.introprogramming.info", "http://www.introprogramming.info/en/");

            Assert.AreEqual(7, updatedCount);
        }

        [TestMethod]
        [TestCategory("UpdateContent")]
        public void UpdateNoMatchingElements()
        {
            Catalog catalog = new Catalog();
            Content book = new Content(ContentType.Book, "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info");
            Content movie = new Content(ContentType.Movie, "The Secret; Drew Heriot", "Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d");
            Content song = new Content(ContentType.Song, "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs");
            Content application = new Content(ContentType.Application, "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org");

            catalog.Add(book);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(book);
            catalog.Add(song);
            catalog.Add(book);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(movie);
            catalog.Add(movie);
            catalog.Add(book);
            catalog.Add(song);
            catalog.Add(book);
            catalog.Add(application);
            catalog.Add(book);
            catalog.Add(book);

            int updatedCount = catalog.UpdateContent("http://www.oldurl", "http://www.newurl/");

            Assert.AreEqual(0, updatedCount);
        }

        [TestMethod]
        [TestCategory("UpdateContent")]
        public void DoubleUpdateManyMatchingElements()
        {
            Catalog catalog = new Catalog();
            Content book = new Content(ContentType.Book, "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info");
            Content movie = new Content(ContentType.Movie, "The Secret; Drew Heriot", "Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d");
            Content song = new Content(ContentType.Song, "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs");
            Content application = new Content(ContentType.Application, "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org");

            catalog.Add(book);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(song);
            catalog.Add(book);
            catalog.Add(song);
            catalog.Add(book);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(movie);
            catalog.Add(movie);
            catalog.Add(book);
            catalog.Add(song);
            catalog.Add(book);
            catalog.Add(application);
            catalog.Add(book);
            catalog.Add(book);

            int updatedCount = catalog.UpdateContent("http://www.introprogramming.info", "http://www.introprogramming.info/en");
            Assert.AreEqual(7, updatedCount);

            int updatedSecondCount = catalog.UpdateContent("http://www.introprogramming.info/en", "http://www.introprogramming.info/");
            Assert.AreEqual(7, updatedSecondCount);
        }
    }
}
