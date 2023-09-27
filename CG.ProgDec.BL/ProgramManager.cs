using CG.ProgDec.BL.Models;
using CG.ProgDec.PL;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;

namespace CG.ProgDec.BL
{
    public static class ProgramManager
    {
        public static int Insert(string description, int degreeTypeId, ref int id, bool rollback = false) // Id by reference
        {
            try
            {
                Program program = new Program()
                {
                    Description = description,
                    DegreeTypeId = degreeTypeId
                };
                int result = Insert(program, rollback);

                // IMPORTANT - BACKFILL THE REFERENCE ID
                id = program.Id;

                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static int Insert(Program program, bool rollback = false) // Id by reference
        {
            try
            {
                int results = 0;
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblProgram entity = new tblProgram();
                    entity.Id = dc.tblPrograms.Any() ? dc.tblPrograms.Max(s => s.Id) + 1 : 1;
                    entity.Description = program.Description;
                    entity.DegreeTypeId = program.DegreeTypeId;                 

                    // IMPORTANT - BACK FILL THE ID 
                    program.Id = entity.Id;



                    dc.tblPrograms.Add(entity);
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


        public static int Update(Program program, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblProgram entity = dc.tblPrograms.FirstOrDefault(s => s.Id == program.Id);
                    if (entity != null)
                    {
                        entity.Description = program.Description;
                        entity.DegreeTypeId = program.DegreeTypeId;

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
                    tblProgram entity = dc.tblPrograms.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        dc.tblPrograms.Remove(entity);

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

        public static Program LoadById(int id)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblProgram entity = dc.tblPrograms.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        return new Program
                        {
                            Id = entity.Id,
                            Description = entity.Description,
                            DegreeTypeId = entity.DegreeTypeId
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

        public static List<Program> Load()
        {
            try
            {
                List<Program> list = new List<Program>();
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    (from s in dc.tblPrograms
                     select new
                     {
                         s.Id,
                         s.Description,
                         s.DegreeTypeId,
                     })
                    .ToList()
                    .ForEach(program => list.Add(new Program
                    {
                        Id = program.Id,
                        Description = program.Description,
                        DegreeTypeId = program.DegreeTypeId
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
