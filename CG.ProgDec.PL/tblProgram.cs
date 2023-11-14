using System;
using System.Collections.Generic;

namespace CG.ProgDec.PL;

public partial class tblProgram
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int DegreeTypeId { get; set; }

    public string ImagePath { get; set; } = null!;
}
