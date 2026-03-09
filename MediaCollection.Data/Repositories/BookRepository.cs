namespace MediaCollection.Data.Repositories;

[ExcludeFromCodeCoverage]
public class BookRepository : EFRepository<Book>, IBookRepository
{
    public BookRepository(MediaDbContext mediaDbContext) : base(mediaDbContext)
    {
    }

    public override async Task CreateRecord(Book entity, CancellationToken cancellationToken = default)
    {
        await base.CreateRecord(entity, cancellationToken);
    }

    public override async Task DeleteRecord(Book entity)
    {
        await base.DeleteRecord(entity);
    }

    public override async Task<IQueryable<Book>> Get()
    {
        return await base.Get();
    }

    public override async Task<Book> Get(Guid id, CancellationToken cancellationToken = default)
    {
        return await base.Get(id, cancellationToken) ?? throw new RecordNotFoundException($"No book with id {id} was found."); ;
    }

    public override async Task SaveChanges(CancellationToken cancellationToken = default)
    {
        await base.SaveChanges(cancellationToken);
    }
}
