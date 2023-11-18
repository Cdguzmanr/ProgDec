

using CG.ProgDec.BL.Models;

namespace CG.ProgDec.PL.Test
{
    [TestClass]
    public class utProgram
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
            ProgDecEntities dc= new ProgDecEntities();

            Assert.AreEqual(16, dc.tblPrograms.Count()); // Assert means "test"
            // Change count to 17 since InsterTest runs first and change lenght +1
            // Remember to delete data from Program Table safter running test
        }

         
        [TestMethod]
        public void InsertTest()
        {

            //Make an entity
            tblProgram entity = new tblProgram();
            entity.DegreeTypeId = 2;
            entity.Description = "Basket Weaving";
            entity.ImagePath = "Test";
            entity.Id = -99;

            //add the entity to the database
            dc.tblPrograms.Add(entity);

            //Commit the changes
            int result = dc.SaveChanges();

            Assert.AreEqual(1, result);
        }


        [TestMethod]
        public void UpdateTest() 
        {
            // select * from tblProgram - use the first one 
            tblProgram entity = dc.tblPrograms.FirstOrDefault();

            // Change property values
            entity.Description = "New Description";
            entity.DegreeTypeId = 3;

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblProgram where id = 4
            tblProgram entity = dc.tblPrograms.Where(e => e.Id == 4).FirstOrDefault();

            dc.tblPrograms.Remove(entity);

            int result = dc.SaveChanges();
            Assert.AreNotEqual(result, 0);
        }

        [TestMethod]
        public void LoadById() 
        {
             // Two line test
            tblProgram entity = dc.tblPrograms.Where(e => e.Id == 2).FirstOrDefault();

            Assert.AreEqual(entity.Id, 2);
            

            // One line
            //Assert.AreEqual(dc.tblPrograms.Where(e => e.Id == 2).FirstOrDefault(), 2);
        }

    }
}