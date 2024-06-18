using System;
using System.Collections.Generic;

namespace SkladDB;

public partial class РезультатАудита
{
    public string НомерГруппы { get; set; } = null!;

    public int Номенклатура { get; set; }

    public string ОснЕдИзм { get; set; } = null!;

    public int Id { get; set; }

    public double Кол { get; set; }

    public double Недостача { get; set; }

    public virtual АудитМетка НомерГруппыNavigation { get; set; } = null!;

    public virtual ОсновнаяЕдИзмерения ОснЕдИзмNavigation { get; set; } = null!;
}
