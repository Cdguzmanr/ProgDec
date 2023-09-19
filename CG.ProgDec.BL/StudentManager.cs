using CG.ProgDec.BL.Models;
using CG.ProgDec.PL;

namespace CG.ProgDec.BL
{
    public static class StudentManager 
    {
        public static int Insert()
        {
            try
            {
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public static int Update() 
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }

            return 0;
        }

        public static int Delete()
        {
            try
            {
                return 0; 
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Student LoadById(int id)
        {
            try
            {
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static List<Student> Load()
        {
            try
            {
                List<Student> list = new List<Student>();
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    (from s in dc.tblStudents
                     select new
                     {
                         s.Id,
                         s.FirstName,
                         s.LastName,
                         s.StudentId
                     })
                    .ToList()
                    .ForEach(student => list.Add(new Student
                    {
                        Id = student.Id,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        StudentId = student.StudentId
                    }));
                }

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
