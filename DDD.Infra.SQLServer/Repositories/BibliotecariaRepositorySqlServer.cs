using DDD.Domain.BibliotecaContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class BibliotecariaRepositorySqlServer : IBibliotecariaRepository
    {
        private readonly SqlContext _context;

        public BibliotecariaRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }
        public void DeleteBibliotecaria(Bibliotecaria bibliotecaria)
        {
            try
            {
                _context.Set<Bibliotecaria>().Remove(bibliotecaria);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Bibliotecaria> GetBibliotecarias()
        {
            return _context.Bibliotecarias.ToList();
        }

        public Bibliotecaria GetBibliotecariaById(int id)
        {
            return _context.Bibliotecarias.Find(id);
        }

        public void InsertBibliotecaria(Bibliotecaria bibliotecaria)
        {
            try
            {
                _context.Bibliotecarias.Add(bibliotecaria);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void UpdateBibliotecaria(Bibliotecaria bibliotecaria)
        {
            try
            {
                _context.Entry(bibliotecaria).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
