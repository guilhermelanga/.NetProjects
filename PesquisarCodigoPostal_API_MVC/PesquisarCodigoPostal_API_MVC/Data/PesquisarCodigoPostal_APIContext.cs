using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClassLibraryModel;

namespace PesquisarCodigoPostal_API.Data
{
    public class PesquisarCodigoPostal_APIContext : DbContext
    {
        public PesquisarCodigoPostal_APIContext (DbContextOptions<PesquisarCodigoPostal_APIContext> options)
            : base(options)
        {
        }

        public DbSet<ClassLibraryModel.CodigoPostal> CodigoPostal { get; set; }
    }
}
