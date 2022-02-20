using Dashboard.Data;
using Dashboard.Repository;
using Dashboard.Repository.Interfaces;

namespace Dashboard.Configuration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DashboardContext _context;
        private readonly ILogger _logger;

        public IDepartmentRepository Department { get; private set; }

        public UnitOfWork(DashboardContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            Department = new DepartmentRepository(context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
