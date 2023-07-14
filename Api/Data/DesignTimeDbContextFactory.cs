using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Runtime.Intrinsics.X86;

namespace Api.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FunctionDbContext>
    {
        public FunctionDbContext CreateDbContext(string[] args)
        {
           

            var optionsBuilder = new DbContextOptionsBuilder<FunctionDbContext>();
            optionsBuilder.UseMySQL("Server=droliviabobbmysql.mysql.database.azure.com;User ID=alpixapps_dev_admin;Password=Yp8Br12c1109#oli;Database=droliviabobbdb");

            return new FunctionDbContext(optionsBuilder.Options);
        }
    }

}
