﻿using ReadPlayCode.Models;
using System.Data.Entity;

namespace ReadPlayCode.DataLayer.Context
{
    public class DefaultContext : DbContext, IContext
    {
        public DefaultContext() : base("DefaultConnection") {}

        public IDbSet<User> Users { get; set; }
        public IDbSet<BlogPost> BlogPosts { get; set; }
    }
}