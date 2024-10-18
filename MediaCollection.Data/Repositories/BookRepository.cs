using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCollection.Data.Repositories;

public class BookRepository : EFRepository<Book>, IBookRepository
{
    public BookRepository(MediaDbContext mediaDbContext) : base(mediaDbContext)
    {
    }

    public override async Task CreateRecord(Book entity)
    {
        await base.CreateRecord(entity);
    }

    public override async Task DeleteRecord(Book entity)
    {
        await base.DeleteRecord(entity);
    }

    public override async Task<IQueryable<Book>> Get()
    {
        return await base.Get();
    }

    public override async Task<Book> Get(int id)
    {
        return await base.Get(id) ?? throw new KeyNotFoundException($"No book with id {id} was found."); ;
    }

    public override async Task SaveChanges()
    {
        await base.SaveChanges();
    }
}
