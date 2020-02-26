using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TareaSistemaInscripciones.Data;
using TareaSistemaInscripciones.Models;

namespace TareaSistemaAsignaturas.Controllers
{
    public class AsignaturasController
    {
        public static string Guardando(Asignaturas inscripcion)
        {
            string estado = String.Empty;
            try
            {
                if (inscripcion.AsignaturaId == 0)
                {
                    Guardar(inscripcion);
                    estado = "Guardo!!";

                }
                else
                {
                    Modificar(inscripcion);
                    estado = "Modifico!!";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return estado;

        }
        public static bool Guardar(Asignaturas inscripcion)
        {
            bool paso = true;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Asignaturas.Add(inscripcion);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            contexto.Dispose();
            return paso;
        }

        public static bool Modificar(Asignaturas inscripcion)
        {
            Contexto c = new Contexto();
            bool paso = false;
            try
            {
                if (c.Entry(inscripcion).State == EntityState.Modified)
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

        public static Asignaturas Buscar(int id)
        {
            Asignaturas ins;
            Contexto c = new Contexto();
            try
            {

                ins = c.Asignaturas.Find(id);
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
                Asignaturas ins = c.Asignaturas.Find(id);
                c.Asignaturas.Remove(ins);

                c.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            c.Dispose();
            return paso;
        }

        public static List<Asignaturas> GetList(Expression<Func<Asignaturas, bool>> expression)
        {
            Contexto c = new Contexto();
            List<Asignaturas> Lista;
            try
            {
                Lista = c.Asignaturas.Where(p => true).ToList();

            }
            catch (Exception)
            {

                throw;
            }
            return Lista;
        }
    }
}
