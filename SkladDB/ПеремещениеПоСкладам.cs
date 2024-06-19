using System;
using System.Collections.Generic;

namespace SkladDB;

public partial class ПеремещениеПоСкладам
{
    public int Id { get; set; }

    public int СкладНачальный { get; set; }

    public int СкладКонечный { get; set; }

    public DateTime Дата { get; set; }

    public string КтоОсуществлял { get; set; } = null!;

    public int Номенклатура { get; set; }

    public double КолОснЕдИзм { get; set; }

    public string АудитНомерГруппы { get; set; } = null!;

    public string ОснЕдИзм { get; set; } = null!;

    public virtual АудитМетка АудитНомерГруппыNavigation { get; set; } = null!;

    public virtual ОсновнаяЕдИзмерения ОснЕдИзмNavigation { get; set; } = null!;

    public virtual Скдад СкладКонечныйNavigation { get; set; } = null!;

    public virtual Скдад СкладНачальныйNavigation { get; set; } = null!;
}
