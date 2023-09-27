using CG.ProgDec.BL.Models;

namespace CG.ProgDec.BL.Test
{
    [TestClass]
    public class utStudent
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(5, StudentManager.Load().Count());
        }

        [TestMethod]
        public void InsertTest1() 
        {
            int id = 0;
            int results = StudentManager.Insert("Bale", "Organa", "555555555", ref id, true);
            Assert.AreEqual(6, id);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void InsertTest2()
        {
            int id = 0;

            Student student = new Student()
            {
                FirstName = "Test",
                LastName = "Test",
                StudentId = "Test"
            };

            int results = StudentManager.Insert("Bale", "Organa", "555555555", ref id, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            int id = 0;
            Student student = StudentManager.LoadById(3);
            student.FirstName = "UpdateTest";
            int results = StudentManager.Update(student, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = StudentManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
    }
}