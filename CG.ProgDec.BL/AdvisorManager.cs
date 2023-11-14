using CG.ProgDec.BL.Models;
using CG.ProgDec.PL;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;

namespace CG.ProgDec.BL
{
    public static class AdvisorManager
    {
        public static int Insert(string name, ref int id, bool rollback = false) // Id by reference
        {
            try
            {
                Advisor advisor = new Advisor()
                {
                    Name = name
                };
                int result = Insert(advisor, rollback);

                // IMPORTANT - BACKFILL THE REFERENCE ID
                id = advisor.Id;

                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static int Insert(Advisor advisor, bool rollback = false) // Id by reference
        {
            try
            {
                int results = 0;
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblAdvisor entity = new tblAdvisor();
                    entity.Id = dc.tblAdvisors.Any() ? dc.tblAdvisors.Max(s => s.Id) + 1 : 1;
                    entity.Name = advisor.Name;

                    

                    // IMPORTANT - BACK FILL THE ID 
                    advisor.Id = entity.Id;


                    dc.tblAdvisors.Add(entity);
                    results += dc.SaveChanges(); // Make sure to add the += and not only = 

                    if (rollback) transaction.Rollback();
                }


                return results;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public static int Update(Advisor advisor, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ProgDecEntities dc = new())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblAdvisor entity = dc.tblAdvisors.FirstOrDefault(s => s.Id == advisor.Id);
                    if (entity != null)
                    {                        
                        entity.Name = advisor.Name;                        

                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }

                    if (rollback) transaction.Rollback();
                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Delete(int id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ProgDecEntities dc = new())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblAdvisor entity = dc.tblAdvisors.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        dc.tblAdvisors.Remove(entity);

                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }

                    if (rollback) transaction.Rollback();
                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Advisor LoadById(int id)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblAdvisor entity = dc.tblAdvisors.FirstOrDefault(s => s.Id == id);

                    if (entity != null)
                    {
                        return new Advisor
                        {
                            Id = entity.Id,
                            Name= entity.Name,
                        };
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public static List<Advisor> Load(int  studentId )
        {
            try
            {
                List<Advisor> list = new List<Advisor>();

                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    (from a in dc.tblAdvisors
                     join sa in dc.tblStudentAdvisors on a.Id equals sa.Id
                     where sa.StudentId == studentId
                     select new
                     {
                         a.Id,
                         a.Name,
                     })
                     .ToList()
                     .ForEach(advisor => list.Add(new Advisor
                     {
                         Id = advisor.Id,
                         Name = advisor.Name,
                        
                     }));
                }

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Advisor> Load()
        {
            try
            {
                List<Advisor> list = new List<Advisor>();

                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    (from s in dc.tblAdvisors
                     select new
                     {
                         s.Id,
                         s.Name,
                     })
                     .ToList()
                     .ForEach(advisor => list.Add(new Advisor
                     {
                         Id = advisor.Id,
                         Name = advisor.Name,

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
