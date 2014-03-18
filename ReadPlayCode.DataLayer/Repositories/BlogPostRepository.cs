using ReadPlayCode.DataLayer.Context;
using ReadPlayCode.Mappers;
using ReadPlayCode.Models;
using ReadPlayCode.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadPlayCode.DataLayer.Repositories
{
    public class BlogPostRepository : IRepository<IBlogPost>
    {
        private readonly IContext _context;
        private readonly IMapper<BlogPost, IBlogPost> _mapper;

        public BlogPostRepository(IContext context, IMapper<BlogPost, IBlogPost> mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<IBlogPost> All()
        {
            return _context.BlogPosts.Local.Select(b => _mapper.DataToModel(b)).ToList();
        }

        public void InsertOrUpdate(IBlogPost item)
        {
            if (item.Id == 0) //insert
            {
                _context.BlogPosts.Add(_mapper.ModelToData(item));
            }
            else //update
            {
                var entity = _mapper.ModelToData(item);
                _context.BlogPosts.Attach(entity);
                _context.SetModified(entity);
            }
        }

        public void Delete(IBlogPost item)
        {
            throw new System.NotImplementedException();
        }

        public IBlogPost GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void PersistAll()
        {
            _context.SaveChanges();
        }
    }
}
