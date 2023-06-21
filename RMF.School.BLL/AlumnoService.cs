using RMF.School.DAL.Models;
using RMF.School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMF.School.BLL
{
    public class AlumnoService
    {
        SchoolDbContext dbContext;

        public AlumnoService()
        {
            dbContext= new SchoolDbContext();
        }

        public IEnumerable<Alumno> GetAll()
        {
            return dbContext.Alumnos.ToList();
        }

        public Alumno Get(long noControl) {
            return dbContext.Alumnos.SingleOrDefault(a=>a.NumeroControl== noControl);
        }

        public int Add(Alumno alumno)
        {
           dbContext.Alumnos.Add(alumno);
           int result = dbContext.SaveChanges();
            return result;
        }

        public Alumno Update(Alumno alumno)
        {
            Alumno alumnoExist = dbContext.Alumnos.SingleOrDefault(a=>a.NumeroControl == alumno.NumeroControl);
            if(alumnoExist!=null)
            {
                alumnoExist.Nombre = alumno.Nombre ?? alumnoExist.Nombre;
                alumnoExist.ApellidoPaterno = alumno.ApellidoPaterno ?? alumnoExist.ApellidoPaterno;
                alumnoExist.ApellidoMaterno = alumno.ApellidoMaterno ?? alumnoExist.ApellidoMaterno;

                DateTime fecha = alumno.FechaNacimiento == null ? alumnoExist.FechaNacimiento : alumno.FechaNacimiento;

                alumnoExist.FechaNacimiento = fecha;

                dbContext.Update(alumnoExist);
                dbContext.SaveChanges();
                return alumnoExist;
            }
            else
            {
                return null;
            }
        }

        public int Delete(long noControl)
        {
            Alumno alumnoExist = dbContext.Alumnos.SingleOrDefault(a => a.NumeroControl == noControl);
            if(alumnoExist!=null)
            {
                dbContext.Alumnos.Remove(alumnoExist);
                dbContext.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
            
        }
    }
}
