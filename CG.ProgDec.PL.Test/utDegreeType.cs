using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.ProgDec.PL.Test
{
    [TestClass]
    public class utDegreeType
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

            Assert.AreEqual(3, dc.tblDegreeTypes.Count()); // Assert means "test"
            // Make sure to check the lenght we are asserting
        }


        [TestMethod]
        public void InsertTest()
        {

            //Make an entity
            tblDegreeType entity = new tblDegreeType();
            entity.Description = "Master Degree";
            entity.Id = -99;

            //add the entity to the database
            dc.tblDegreeTypes.Add(entity);

            //Commit the changes
            int result = dc.SaveChanges();

            Assert.AreEqual(1, result);

        }


        [TestMethod]
        public void UpdateTest()
        {
            // select * from tblProgram - use the first one 
            tblDegreeType entity = dc.tblDegreeTypes.FirstOrDefault();

            // Change property values
            entity.Description = "New Description";


            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblProgram where id = 4
            tblDegreeType entity = dc.tblDegreeTypes.Where(e => e.Id == 2).FirstOrDefault();

            dc.tblDegreeTypes.Remove(entity);

            int result = dc.SaveChanges();
            Assert.AreNotEqual(result, 0);
        }

    }
}
