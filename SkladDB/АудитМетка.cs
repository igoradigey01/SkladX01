using System;
using System.Collections.Generic;

namespace SkladDB;

public partial class АудитМетка
{
    public string НомерГруппы { get; set; } = null!;

    public DateTime ДатаНазначенияНомера { get; set; }

    public virtual ICollection<ПеремещениеПоСкладам> ПеремещениеПоСкладамs { get; set; } = new List<ПеремещениеПоСкладам>();

    public virtual ICollection<РезультатАудита> РезультатАудитаs { get; set; } = new List<РезультатАудита>();

    public virtual ICollection<СкладПриход> СкладПриходs { get; set; } = new List<СкладПриход>();

    public virtual ICollection<СкладРасход> СкладРасходs { get; set; } = new List<СкладРасход>();
}
