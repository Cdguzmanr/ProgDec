

namespace CG.ProgDec.PL.Test
{
    [TestClass]
    public class utStudent
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

            Assert.AreEqual(5, dc.tblStudents.Count()); // Assert means "test"
        }


        [TestMethod]
        public void InsertTest()
        {

            //Make an entity
            tblStudent entity = new tblStudent();
            entity.FirstName = "Hugo";
            entity.LastName = "Smith";
            entity.StudentId = "432654678";
            entity.Id = -99;

            //add the entity to the database
            dc.tblStudents.Add(entity);

            //Commit the changes
            int result = dc.SaveChanges();

            Assert.AreEqual(1, result);

        }


        [TestMethod]
        public void UpdateTest()
        {
            // select * from tblStudent - use the first one 
            tblStudent entity = dc.tblStudents.FirstOrDefault();

            // Change property values
            entity.FirstName = "Hugo";
            entity.LastName = "Smith";

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblStudent where id = 4
            tblStudent entity = dc.tblStudents.Where(e => e.Id == 4).FirstOrDefault();

            dc.tblStudents.Remove(entity);

            int result = dc.SaveChanges();
            Assert.AreNotEqual(result, 0);
        }
    }
}