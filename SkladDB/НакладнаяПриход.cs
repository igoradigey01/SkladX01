using System;
using System.Collections.Generic;

namespace SkladDB;

public partial class НакладнаяПриход
{
    public int Id { get; set; }

    public int Поставщик { get; set; }

    public DateTime Дата { get; set; }

    public string НомерНакладной { get; set; } = null!;

    public decimal СуммаПонаклодной { get; set; }

    public virtual Поставщик ПоставщикNavigation { get; set; } = null!;

    public virtual ICollection<СкладПриход> СкладПриходs { get; set; } = new List<СкладПриход>();
}
