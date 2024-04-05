using Application.Repositories.IRepository;

namespace Application.UnitOfWorks
{
    public interface IUnitOfWork: IDisposable   
    {
        IItemRepository Item { get;}

    }
}
