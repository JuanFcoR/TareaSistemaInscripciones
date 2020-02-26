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
    public class EstudiantesController
    {
        public static string Guardando(Estudiantes inscripcion)
        {
            string estado = String.Empty;
            try
            {
                if (inscripcion.EstudianteId == 0)
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
        public static bool Guardar(Estudiantes inscripcion)
        {
            bool paso = true;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Estudiantes.Add(inscripcion);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            contexto.Dispose();
            return paso;
        }

        public static bool Modificar(Estudiantes inscripcion)
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

        public static Estudiantes Buscar(int id)
        {
            Estudiantes ins;
            Contexto c = new Contexto();
            try
            {

                ins = c.Estudiantes.Find(id);
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
                Estudiantes ins = c.Estudiantes.Find(id);
                c.Estudiantes.Remove(ins);

                c.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            c.Dispose();
            return paso;
        }

        public static List<Estudiantes> GetList(Expression<Func<Estudiantes, bool>> expression)
        {
            Contexto c = new Contexto();
            List<Estudiantes> Lista;
            try
            {
                Lista = c.Estudiantes.Where(p => true).ToList();

            }
            catch (Exception)
            {

                throw;
            }
            return Lista;
        }
    }
}
