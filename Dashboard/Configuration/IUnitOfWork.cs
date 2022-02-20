using Dashboard.Repository.Interfaces;

namespace Dashboard.Configuration
{
    public interface IUnitOfWork
    {
        IDepartmentRepository Department { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
