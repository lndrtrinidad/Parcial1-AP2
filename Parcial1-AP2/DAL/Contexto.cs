using Microsoft.EntityFrameworkCore;
using Parcial1_AP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial1_AP2.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Productos> Productos { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
    }
}
