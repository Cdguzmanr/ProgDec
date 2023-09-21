using CG.ProgDec.BL.Models;
using CG.ProgDec.PL;

namespace CG.ProgDec.BL
{
    public static class ProgramManager
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

        public static Program LoadById(int id)
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

        public static List<Program> Load()
        {
            try
            {
                List<Program> list = new List<Program>();
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    (from p in dc.tblPrograms
                     select new
                     {
                         p.Id,
                         p.Description,
                         p.DegreeTypeId
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
