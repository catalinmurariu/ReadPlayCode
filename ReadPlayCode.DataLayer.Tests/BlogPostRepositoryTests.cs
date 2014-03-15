using Moq;
using NUnit.Framework;
using ReadPlayCode.DataLayer.Context;
using ReadPlayCode.DataLayer.Repositories;
using ReadPlayCode.Models;
using System;
using ReadPlayCode.Mappers;
using System.Data.Entity;
using System.Linq;
using System.Collections.ObjectModel;

namespace ReadPlayCode.DataLayer.Tests
{
    public class BlogPostRepositoryTests
    {
        [TestFixture]
        public class All_Method
        {
            private static IBlogPost CreateMockedObject(BlogPost b)
            {
                var mock = new Mock<IBlogPost>();
                mock.Setup(m => m.Id).Returns(1);
                return mock.Object;
            }

            [Test]
            public void ReturnsAllTheItems()
            {
                //mocks
                var contextMock = new Mock<IContext>();
                var blogBostsDbSetMock = new Mock<IDbSet<BlogPost>>();

                blogBostsDbSetMock.Setup(b=>b.Local).Returns(new ObservableCollection<BlogPost>(new[]{ new BlogPost{Id = 1}, new BlogPost { Id = 2} }));

                contextMock.Setup(m => m.BlogPosts).Returns(blogBostsDbSetMock.Object);

                var mapperMock = new Mock<IMapper<BlogPost, IBlogPost>>();
                mapperMock.Setup(m => m.DataToModel(It.IsAny<BlogPost>())).Returns(CreateMockedObject(It.IsAny<BlogPost>()));

                //target setup
                var target = new BlogPostRepository(contextMock.Object, mapperMock.Object);

                //act
                var result = target.All();

                //assert
                Assert.AreEqual(2, result.Count);
            }
        }
    }
}
