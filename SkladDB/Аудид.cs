using System;
using System.Collections.Generic;

namespace SkladDB;

public partial class Аудид
{
    public int Номенкл { get; set; }

    public double Количест { get; set; }

    public string ЕдИзм { get; set; } = null!;

    public string Имя { get; set; } = null!;
}
