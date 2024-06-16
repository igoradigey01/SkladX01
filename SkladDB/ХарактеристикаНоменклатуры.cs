using System;
using System.Collections.Generic;

namespace SkladDB;

public partial class ХарактеристикаНоменклатуры
{
    public int Id { get; set; }

    public int? НоменклатураId { get; set; }

    public string? Атрибут { get; set; }

    public string? Значение { get; set; }

    public virtual АтрибутыМатерьяла? ЗначениеNavigation { get; set; }

    public virtual Номенклатура? Номенклатура { get; set; }
}
