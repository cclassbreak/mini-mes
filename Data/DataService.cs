namespace mini_mes.Data
{
    using Microsoft.EntityFrameworkCore;
    using Model;
    public class DataService
    {
        private readonly MyDbContext _context;

        public DataService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<List<Product>> GetProductsWithParts()
        {
            return await _context.Products.Include(p => p.Part).ToListAsync();
        }

        public async Task<List<Part>> GetParts()
        {
            return await _context.Parts.ToListAsync();
        }

        public async Task<List<Station>> GetStations()
        {
            return await _context.Stations.ToListAsync();
        }

        public async Task<ProcessFlow> GetProcessFlow(string processFlowNumber)
        {
            return await _context.ProcessFlows.FirstOrDefaultAsync(pf => pf.ProcessFlowNumber == processFlowNumber);
        }

        public async Task<ProcessFlow> GetProcessFlow(int processFlowID)
        {
            return await _context.ProcessFlows.FirstOrDefaultAsync(pf => pf.ProcessFlowID == processFlowID);
        }
    }   
}
