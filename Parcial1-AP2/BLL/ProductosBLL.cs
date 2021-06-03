using Microsoft.EntityFrameworkCore;
using Parcial1_AP2.DAL;
using Parcial1_AP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Parcial1_AP2.BLL
{
    public class ProductosBLL
    {
        private Contexto contexto;

        public ProductosBLL(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<bool> Existe(int id)
        {
            bool pass = false;

            try
            {
                pass = await contexto.Productos.AnyAsync(a => a.ProductoId == id);
            }
            catch
            {
                throw;
            }
            return pass;
        }

        private async Task<bool> Insetar(Productos productos)
        {
            bool pass = false;

            try
            {
                await contexto.Productos.AddAsync(productos);
                pass = await contexto.SaveChangesAsync() > 0;
            }
            catch
            {
                throw;
            }
            return pass;
        }

        public async Task<bool> Modificar(Productos productos)
        {
            bool pass = false;
            try
            {
                contexto.Entry(productos).State = EntityState.Modified;
                pass = await contexto.SaveChangesAsync() > 0;
            }
            catch
            {
                throw;
            }
            return pass;
        }

         public async Task<bool> Guardar(Productos productos)
        {
            if (!await Existe(productos.ProductoId))
                return await Insetar(productos);
            else
                return await Modificar(productos);
        }

        public async Task<Productos> Buscar (int id)
        {
            Productos productos;

            try
            {
                productos = await contexto.Productos.FindAsync(id);
            }
            catch
            {
                throw;
            }
            return productos;
        }

        public async Task<bool> Elimiar(int id)
        {
            bool eliminado = false;

            try
            {
                var encotrado = await contexto.Productos.FindAsync(id);

                if(encotrado != null)
                {
                    contexto.Productos.Remove(encotrado);
                    eliminado = await contexto.SaveChangesAsync() > 0;
                }
            }
            catch
            {
                throw;
            }
            return eliminado;
        }

        public async Task<List<Productos>> GetProductos()
        {
            List<Productos> lista = new List<Productos>();

            try
            {
                lista = await contexto.Productos.ToListAsync();
            }
            catch
            {
                throw;
            }
            return lista;
        }

        public async Task<List<Productos>> GetProductos(Expression<Func<Productos, bool>> criterio)
        {
            List<Productos> lista = new List<Productos>();

            try
            {
                lista = await contexto.Productos.Where(criterio).ToListAsync();
            }
            catch
            {
                throw;
            }
            return lista;
        }
    }

}
