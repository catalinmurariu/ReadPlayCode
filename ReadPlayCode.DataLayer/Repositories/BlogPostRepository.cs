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
            return _context.BlogPosts.Local.Select(_mapper.DataToModel).ToList();
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
            _context.BlogPosts.Remove(_mapper.ModelToData(item));
        }

        public IBlogPost GetById(int id)
        {
            return _mapper.DataToModel(_context.BlogPosts.Where(b => b.Id == id).FirstOrDefault());
        }

        public void PersistAll()
        {
            _context.SaveChanges();
        }
    }
}
