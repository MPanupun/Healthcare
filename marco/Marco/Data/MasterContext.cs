using Microsoft.EntityFrameworkCore;

namespace Marco.Data
{
    public class MasterContext : MarcoContext<MasterContext>
    {
        public MasterContext(DbContextOptions<MasterContext> options) : base(options) { }
    }
}
