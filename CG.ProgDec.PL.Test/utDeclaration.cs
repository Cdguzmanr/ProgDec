using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.ProgDec.PL.Test
{
    [TestClass]
    public class utDeclaration
    {
        protected ProgDecEntities dc;
        protected IDbContextTransaction transaction;

        [TestInitialize]
        public void Initialize()
        {
            dc = new ProgDecEntities();
            transaction = dc.Database.BeginTransaction();
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Rollback();
            transaction.Dispose();
            dc = null;


        }


        [TestMethod]
        public void LoadTest()
        {
            ProgDecEntities dc = new ProgDecEntities();

            Assert.AreEqual(4, dc.tblDeclarations.Count()); // Assert means "test"
            // Check Lenght
        }

        [TestMethod]
        public void LoadAllTest2() 
        {
            var declarations = (from d in dc.tblDeclarations
                                join s in dc.tblStudents
                                    on d.StudentId equals s.Id
                                join p in dc.tblPrograms
                                    on d.ProgramId equals p.Id
                                join dt in dc.tblDegreeTypes
                                    on p.DegreeTypeId equals dt.Id
                                select new
                               {
                                   d.Id,
                                    StudentName = s.FirstName + " " + s.LastName,
                                    ProgramName = p.Description,
                                    DegreeTypeName = dt.Description
                                   
                               }).ToList();

            Assert.AreEqual(4, declarations.Count());
        }


        [TestMethod]
        public void InsertTest()
        {

            //Make an entity
            tblDeclaration entity = new tblDeclaration();
            entity.StudentId = 3;
            entity.StudentId = 4;
            entity.ChangeDate = DateTime.Now;
            entity.Id = -99;

            //add the entity to the database
            dc.tblDeclarations.Add(entity);

            //Commit the changes
            int result = dc.SaveChanges();

            Assert.AreEqual(1, result);

        }


        [TestMethod]
        public void UpdateTest()
        {
            // select * from tblDeclaration - use the first one 
            tblDeclaration entity = dc.tblDeclarations.FirstOrDefault();

            // Change property values
            entity.ProgramId = 3;
            entity.StudentId = 4;

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblDeclaration where id = 4
            tblDeclaration entity = dc.tblDeclarations.Where(e => e.Id == 2).FirstOrDefault();

            dc.tblDeclarations.Remove(entity);

            int result = dc.SaveChanges();
            Assert.AreNotEqual(result, 0);
        }

        [TestMethod]
        public void LoadById()
        {
            // Two line test
            tblDeclaration entity = dc.tblDeclarations.Where(e => e.Id == 2).FirstOrDefault();

            Assert.AreEqual(entity.Id, 2);
        }
    }
}
