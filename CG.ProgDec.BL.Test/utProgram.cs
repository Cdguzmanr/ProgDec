using CG.ProgDec.BL.Models;

namespace CG.ProgDec.BL.Test
{
    [TestClass]
    public class utProgram
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(16, ProgramManager.Load().Count);
        }
        [TestMethod]
        public void InsertTest1()
        {
            int id = 0;
            int results = ProgramManager.Insert("Test", 3, "justinbieber.jpg", ref id, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void InsertTest2()
        {
            int id = 0;
            Program program = new Program
            {
                DegreeTypeId = 1,
                Description = "Test",
                ImagePath = "test.png"
            };

            int results = ProgramManager.Insert(program, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Program program = ProgramManager.LoadById(3);
            program.Description = "Test";
            int results = ProgramManager.Update(program, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = ProgramManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
    }
}