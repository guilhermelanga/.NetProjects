using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PesquisarCodigoPostal.Models;

namespace PesquisarCodigoPostal.Data
{
    public class PesquisarCodigoPostalContext : DbContext
    {
        public PesquisarCodigoPostalContext (DbContextOptions<PesquisarCodigoPostalContext> options)
            : base(options)
        {
        }

        public DbSet<CodigoPostal> CodigoPostal { get; set; }
    }
}
