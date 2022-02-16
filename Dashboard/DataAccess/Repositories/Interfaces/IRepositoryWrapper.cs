using Dashboard.DataAccess.Interfaces;

namespace Dashboard.DataAccess.Repositories.Interfaces 
{
    public interface IRepositoryWrapper
    {
        IDepartmentRepository Department { get; }
        IGenderRepository Gender { get; }
        IRoleRepository Role { get; }
        ISiteRepository Site { get; }
        IUserRepository User { get; }
        void Save();
    }
}
