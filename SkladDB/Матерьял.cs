using System;
using System.Collections.Generic;

namespace SkladDB;

public partial class Матерьял
{
    public string Название { get; set; } = null!;

    public virtual ICollection<Номенклатура> Номенклатураs { get; set; } = new List<Номенклатура>();
}
