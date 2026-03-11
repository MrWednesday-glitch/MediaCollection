namespace MediaCollection.Data.Repositories;

[ExcludeFromCodeCoverage]
public class BookRepository : EFRepository<Book>, IBookRepository
{
    public BookRepository(MediaDbContext mediaDbContext) : base(mediaDbContext)
    {
    }

    public override async Task CreateRecordAsync(Book entity, CancellationToken cancellationToken = default)
    {
        await base.CreateRecordAsync(entity, cancellationToken);
    }

    public override async Task DeleteRecordAsync(Book entity)
    {
        await base.DeleteRecordAsync(entity);
    }

    public override async Task<IQueryable<Book>> GetAsync()
    {
        return await base.GetAsync();
    }

    public override async Task<Book> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await base.GetAsync(id, cancellationToken) ?? throw new RecordNotFoundException($"No book with id {id} was found."); ;
    }

    public override async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await base.SaveChangesAsync(cancellationToken);
    }
}
