using CG.ProgDec.BL.Models;

namespace CG.ProgDec.BL.Test
{
    [TestClass]
    public class utDegreeType
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, DegreeTypeManager.Load().Count());
        }

        [TestMethod]
        public void InsertTest1()
        {
            int id = 0;
            int results = DegreeTypeManager.Insert("Bale", ref id, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void InsertTest2()
        {
            int id = 0;

            DegreeType degreeType = new DegreeType()
            {
                Description = "Test"
            };

            int results = DegreeTypeManager.Insert(degreeType, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            DegreeType degreeType = DegreeTypeManager.LoadById(3);
            degreeType.Description = "UpdateTest";
            int results = DegreeTypeManager.Update(degreeType, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = DegreeTypeManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
    }
}