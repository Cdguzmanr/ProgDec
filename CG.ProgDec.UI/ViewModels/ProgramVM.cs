namespace CG.ProgDec.UI.ViewModels
{
    public class ProgramVM
    {
        // A View Model is just a class with properties. It is an abstraction ovf models. Is used to show multiple odels in a same sccreen.

        public BL.Models.Program Program { get; set; }
        public List<DegreeType> DegreeTypes { get; set; } = new List<DegreeType>();

        public IFormFile File { get; set; }
    }
}
