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
using System.Data.Entity.Infrastructure;

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

        [TestFixture]
        public class PersistAll_Method
        {
            [Test]
            public void CallsSaveChanges_OnTheContext()
            {
                //mock and setup
                var contextMock = new Mock<IContext>();
                contextMock.Setup(c => c.SaveChanges()).Verifiable();
                var mapperMock = new Mock<IMapper<BlogPost, IBlogPost>>();
                var target = new BlogPostRepository(contextMock.Object, mapperMock.Object);

                //act
                target.PersistAll();

                //assert
                contextMock.Verify(c => c.SaveChanges());
            }
        }

        [TestFixture]
        public class InsertOrUpdate_Method
        {
            [Test]
            public void CallsInsert_WhenModelHasId_EqualToZero()
            {
                //mock and setup
                var contextMock = new Mock<IContext>();
                var blogBostsDbSetMock = new Mock<IDbSet<BlogPost>>();
                blogBostsDbSetMock.Setup(b => b.Add(It.IsAny<BlogPost>())).Verifiable();
                blogBostsDbSetMock.Setup(b => b.Attach(It.IsAny<BlogPost>())).Verifiable();

                contextMock.Setup(m => m.BlogPosts).Returns(blogBostsDbSetMock.Object);

                var mapperMock = new Mock<IMapper<BlogPost, IBlogPost>>();
                mapperMock.Setup(m => m.ModelToData(It.IsAny<IBlogPost>())).Returns(new BlogPost());

                var target = new BlogPostRepository(contextMock.Object, mapperMock.Object);
                var modelMock = new Mock<IBlogPost>();
                modelMock.Setup(mm => mm.Id).Returns(0);

                //act
                target.InsertOrUpdate(modelMock.Object);

                //assert
                blogBostsDbSetMock.Verify(b => b.Add(It.IsAny<BlogPost>()));
                blogBostsDbSetMock.Verify(b => b.Attach(It.IsAny<BlogPost>()), Times.Never);
            }

            [Test]
            public void CallsUpdate_WhenModelHasId_NotEqualToZero()
            {
                //mock and setup
                var contextMock = new Mock<IContext>();
                var blogBostsDbSetMock = new Mock<IDbSet<BlogPost>>();
                blogBostsDbSetMock.Setup(b => b.Add(It.IsAny<BlogPost>())).Verifiable();
                blogBostsDbSetMock.Setup(b => b.Attach(It.IsAny<BlogPost>())).Verifiable();

                contextMock.Setup(m => m.BlogPosts).Returns(blogBostsDbSetMock.Object);
                contextMock.Setup(m => m.SetModified(It.IsAny<object>())).Verifiable();

                var mapperMock = new Mock<IMapper<BlogPost, IBlogPost>>();
                mapperMock.Setup(m => m.ModelToData(It.IsAny<IBlogPost>())).Returns(new BlogPost());

                var target = new BlogPostRepository(contextMock.Object, mapperMock.Object);
                var modelMock = new Mock<IBlogPost>();
                modelMock.Setup(mm => mm.Id).Returns(1);

                //act
                target.InsertOrUpdate(modelMock.Object);

                //assert
                blogBostsDbSetMock.Verify(b => b.Add(It.IsAny<BlogPost>()), Times.Never);
                blogBostsDbSetMock.Verify(b => b.Attach(It.IsAny<BlogPost>()), Times.Once);
                contextMock.Verify(m => m.SetModified(It.IsAny<object>()), Times.Once);
            }
        }
    }
}
