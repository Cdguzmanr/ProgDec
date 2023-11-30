namespace CG.ProgDec.UI.ViewModels
{
    public class StudentVM
    {
        public Student Student { get; set; }
        public List<Advisor> Advisors { get; set;} = new List<Advisor>(); // All of the Advisors
        public IEnumerable<int> AdvisorIds { get; set; }  // The new advisors for the student

        public StudentVM()
        {
            Advisors = AdvisorManager.Load();
        }

        public StudentVM(int id)
        {
            Advisors = AdvisorManager.Load();
            Student = StudentManager.LoadById(id);
            AdvisorIds = Student.Advisors.Select(x => x.Id);
        }
    }
}
