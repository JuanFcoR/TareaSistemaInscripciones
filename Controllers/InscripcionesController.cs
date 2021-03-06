﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TareaSistemaInscripciones.Data;
using TareaSistemaInscripciones.Models;

namespace TareaSistemaInscripciones.Controllers
{
    public class InscripcionesController
    {
        public static string Guardando(Inscripciones inscripcion)
        {
            string estado = String.Empty;
            try
            {
                if (inscripcion.InscripcionId == 0)
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
        public static bool Guardar(Inscripciones inscripcion)
        {
            bool paso = true;
            Contexto contexto = new Contexto();
           // EstudiantesController controller = new EstudiantesController();

            try
            {
                Estudiantes est = EstudiantesController.Buscar(inscripcion.EstudianteId);
                est.Balance += inscripcion.Balance;
                EstudiantesController.Modificar(est);
                contexto.Inscripciones.Add(inscripcion);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            contexto.Dispose();
            return paso;
        }

        public static bool Modificar(Inscripciones inscripcion)
        {
            Contexto c = new Contexto();
            bool paso = false;
            try
            {
                var anterior = Buscar(inscripcion.InscripcionId);
                foreach(var asignatura in inscripcion.Detalle)
                {
                    if(asignatura.InscripcionId==0)
                    {
                        c.Entry(asignatura).State = EntityState.Added;
                    }
                }
                foreach (var item in anterior.Detalle)
                {
                    if(!inscripcion.Detalle.Any(P=>P.AsignaturaId== item.AsignaturaId))
                    {
                        c.Entry(item).State = EntityState.Deleted;
                    }
                }
                Estudiantes est = EstudiantesController.Buscar(inscripcion.EstudianteId);
                Inscripciones inscripciones = InscripcionesController.Buscar(inscripcion.InscripcionId);

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

        public static Inscripciones Buscar(int id)
        {
            Inscripciones ins;
            Contexto c = new Contexto();
            try
            {

                ins = c.Inscripciones.Find(id);
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
                Inscripciones ins = c.Inscripciones.Find(id);
                c.Inscripciones.Remove(ins);

                c.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            c.Dispose();
            return paso;
        }

        public static List<Inscripciones> GetList(Expression<Func<Inscripciones, bool>> expression)
        {
            Contexto c = new Contexto();
            List<Inscripciones> Lista;
            try
            {
                Lista = c.Inscripciones.Where(p => true).ToList();

            }
            catch (Exception)
            {

                throw;
            }
            return Lista;
        }
    }
}
