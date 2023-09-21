using CG.ProgDec.BL.Models;
using CG.ProgDec.PL;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;

namespace CG.ProgDec.BL
{
    public static class StudentManager 
    {
        public static int Insert(string firstName, string lastName, string studentId, ref int id, bool rollback = false) // Id by reference
        {
            try
            {
                Student student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    StudentId = studentId
                };
                int result = Insert(student, rollback);

                // IMPORTANT - BACKFILL THE REFERENCE ID
                id = student.Id;

                return result;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public static int Insert(Student student, bool rollback = false) // Id by reference
        {
            try
            {
                int results = 0;
                using(ProgDecEntities dc = new ProgDecEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblStudent entity = new tblStudent();
                    entity.Id = dc.tblStudents.Any() ? dc.tblStudents.Max(s => s.Id) + 1 : 1 ;
                    entity.FirstName = student.FirstName;
                    entity.LastName = student.LastName;
                    entity.StudentId = student.StudentId;

                    // IMPORTANT - BACK FILL THE ID 
                    student.Id = entity.Id;



                    dc.tblStudents.Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();
                }


                return results;
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
