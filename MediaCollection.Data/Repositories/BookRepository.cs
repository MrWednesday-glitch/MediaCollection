using System.Diagnostics.CodeAnalysis;

namespace MediaCollection.Data.Repositories;

[ExcludeFromCodeCoverage]
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

    public override async Task<Book> Get(Guid id)
    {
        return await base.Get(id) ?? throw new KeyNotFoundException($"No book with id {id} was found."); ;
    }

    public override async Task SaveChanges()
    {
        await base.SaveChanges();
    }
}
