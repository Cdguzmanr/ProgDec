namespace CG.ProgDec.PL.Test
{
    [TestClass]
    public class utProgram
    {
        [TestMethod]
        public void LoadTest()
        {
            ProgDecEntities dc= new ProgDecEntities();

            Assert.AreEqual(17, dc.tblPrograms.Count()); // Assert means "test"
            // Change count to 17 since InsterTest runs first and change lenght +1
        }


        [TestMethod]

        public void InsertTest()
        {
            var dc = new ProgDecEntities(); //there's not specific reason for the use of var here

            //Make an entity
            tblProgram entity = new tblProgram();
            entity.DegreeTypeId = 2;
            entity.Description = "Basket Weaving";
            entity.Id = -99;

            //add the entity to the database
            dc.tblPrograms.Add(entity);

            //Commit the changes
            int result = dc.SaveChanges();

            Assert.AreEqual(1, result);

        }
    }
}