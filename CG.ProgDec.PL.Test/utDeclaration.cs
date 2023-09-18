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
        protected IDbContextTransaction transation;

        [TestInitialize]
        public void Initialize()
        {
            dc = new ProgDecEntities();
            transation = dc.Database.BeginTransaction();
        }

        [TestCleanup]
        public void Cleanup()
        {
            transation.Rollback();
            transation.Dispose();
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
    }
}
