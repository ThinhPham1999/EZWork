using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace EZWork.Core.DBContext
{
    public class EZWorkInitializer : CreateDatabaseIfNotExists<EZWorkDbContext>
    {
        protected override void Seed(EZWorkDbContext context)
        {
            base.Seed(context);
        }
    }
}
