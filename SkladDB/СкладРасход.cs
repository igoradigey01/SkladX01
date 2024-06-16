using System;
using System.Collections.Generic;

namespace SkladDB;

public partial class СкладРасход
{
    public int Id { get; set; }

    public int Номенклатура { get; set; }

    public int НакладнаяId { get; set; }

    public string AliasЕдИзм { get; set; } = null!;

    public double? КолAliasЕдИзм { get; set; }

    public double КолОснЕдИзм { get; set; }

    public decimal ЦенаОснЕдИзм { get; set; }

    public decimal ЦенаAliasЕдИзм { get; set; }

    public int СкладId { get; set; }

    public string ОснЕдИзм { get; set; } = null!;

    public string АудитНомерГруппы { get; set; } = null!;

    public string? ТараРасхода { get; set; }

    public virtual AliasЕдИзмТовар AliasЕдИзмNavigation { get; set; } = null!;

    public virtual АудитМетка АудитНомерГруппыNavigation { get; set; } = null!;

    public virtual НакладнаяРасход Накладная { get; set; } = null!;

    public virtual Номенклатура НоменклатураNavigation { get; set; } = null!;

    public virtual ОсновнаяЕдИзмерения ОснЕдИзмNavigation { get; set; } = null!;

    public virtual Скдад Склад { get; set; } = null!;

    public virtual AliasЕдИзмТовар? ТараРасходаNavigation { get; set; }
}
