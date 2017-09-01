﻿using BookShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.Service
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}