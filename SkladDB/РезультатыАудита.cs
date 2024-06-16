using System;
using System.Collections.Generic;

namespace SkladDB;

public partial class РезультатыАудита
{
    public string НомерГруппы { get; set; } = null!;

    public int Номенклатура { get; set; }

    public string ОснЕдИзм { get; set; } = null!;

    public double Кол { get; set; }

    public string Название { get; set; } = null!;
}
