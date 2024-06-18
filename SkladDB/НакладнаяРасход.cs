using System;
using System.Collections.Generic;

namespace SkladDB;

public partial class НакладнаяРасход
{
    public int Id { get; set; }

    public string Номер { get; set; } = null!;

    public DateTime Дата { get; set; }

    public int КлиентId { get; set; }

    public decimal СуммаПонаклодной { get; set; }

    public int МеткаId { get; set; }

    public virtual Клиент Клиент { get; set; } = null!;

    public virtual КлиентМеткаРасчет Метка { get; set; } = null!;

    public virtual ICollection<СкладРасход> СкладРасходs { get; set; } = new List<СкладРасход>();
}
