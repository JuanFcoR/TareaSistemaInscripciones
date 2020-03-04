using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TareaSistemaInscripciones.Data;
using TareaSistemaInscripciones.Models;

namespace TareaSistemaInscripciones.Controllers
{
    public class PagosController
    {
        public static string Guardando(Pagos Pago)
        {
            string estado = String.Empty;
            try
            {
                if (Pago.PagoId == 0)
                {
                    Guardar(Pago);
                    estado = "Guardo!!";

                }
                else
                {
                    Modificar(Pago);
                    estado = "Modifico!!";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return estado;

        }
        public static bool Guardar(Pagos Pago)
        {
            bool paso = true;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Pagos.Add(Pago);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            contexto.Dispose();
            return paso;
        }

        public static bool Modificar(Pagos Pago)
        {
            Contexto c = new Contexto();
            bool paso = false;
            try
            {
                if (c.Entry(Pago).State == EntityState.Modified)
                {
                    paso = c.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            c.Dispose();
            return paso;
        }

        public static Pagos Buscar(int id)
        {
            Pagos ins;
            Contexto c = new Contexto();
            try
            {

                ins = c.Pagos.Find(id);
                c.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            c.Dispose();
            return ins;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto c = new Contexto();
            try
            {
                Pagos ins = c.Pagos.Find(id);
                c.Pagos.Remove(ins);

                c.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            c.Dispose();
            return paso;
        }

        public static List<Pagos> GetList(Expression<Func<Pagos, bool>> expression)
        {
            Contexto c = new Contexto();
            List<Pagos> Lista;
            try
            {
                Lista = c.Pagos.Where(p => true).ToList();

            }
            catch (Exception)
            {

                throw;
            }
            return Lista;
        }
    }
}
