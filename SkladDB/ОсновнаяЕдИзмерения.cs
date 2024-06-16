using System;
using System.Collections.Generic;

namespace SkladDB;

/// <summary>
/// вес , шт
/// </summary>
public partial class ОсновнаяЕдИзмерения
{
    public string Название { get; set; } = null!;

    public virtual ICollection<Номенклатура> Номенклатураs { get; set; } = new List<Номенклатура>();

    public virtual ICollection<ПеремещениеПоСкладам> ПеремещениеПоСкладамs { get; set; } = new List<ПеремещениеПоСкладам>();

    public virtual ICollection<РезультатАудита> РезультатАудитаs { get; set; } = new List<РезультатАудита>();

    public virtual ICollection<СвязиAlisEдИзмНоменклатура> СвязиAlisEдИзмНоменклатураs { get; set; } = new List<СвязиAlisEдИзмНоменклатура>();

    public virtual ICollection<СкладПриход> СкладПриходs { get; set; } = new List<СкладПриход>();

    public virtual ICollection<СкладРасход> СкладРасходs { get; set; } = new List<СкладРасход>();
}
