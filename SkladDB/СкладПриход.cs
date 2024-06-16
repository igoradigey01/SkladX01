using System;
using System.Collections.Generic;

namespace SkladDB;

public partial class СкладПриход
{
    public int Id { get; set; }

    /// <summary>
    /// id номенклатуры
    /// </summary>
    public int Номенклатура { get; set; }

    /// <summary>
    /// id накладной
    /// </summary>
    public int? НакладнаяId { get; set; }

    /// <summary>
    /// количесво товара в основной ед измерения
    /// </summary>
    public double КолОснЕдИзм { get; set; }

    /// <summary>
    /// при учете в алтернативных ед измерения принимает истина
    /// </summary>
    public string AliasЕдИзм { get; set; } = null!;

    /// <summary>
    /// количесто товара в алтернативных ед изм
    /// </summary>
    public double КолAliasЕдИзм { get; set; }

    /// <summary>
    /// цена товара в основных ед измерения
    /// </summary>
    public decimal ЦенаОснЕдИзм { get; set; }

    /// <summary>
    /// id склада на который поступил товар
    /// </summary>
    public int СкладId { get; set; }

    /// <summary>
    /// цена в альтернативных ед измерения
    /// </summary>
    public decimal ЦенаAliasЕдИзм { get; set; }

    public string ОснЕдИзм { get; set; } = null!;

    public string АудитНомерГруппы { get; set; } = null!;

    public string? ТараРасхода { get; set; }

    public virtual AliasЕдИзмТовар AliasЕдИзмNavigation { get; set; } = null!;

    public virtual АудитМетка АудитНомерГруппыNavigation { get; set; } = null!;

    public virtual НакладнаяПриход? Накладная { get; set; }

    public virtual Номенклатура НоменклатураNavigation { get; set; } = null!;

    public virtual ОсновнаяЕдИзмерения ОснЕдИзмNavigation { get; set; } = null!;

    public virtual Скдад Склад { get; set; } = null!;

    public virtual AliasЕдИзмТовар? ТараРасходаNavigation { get; set; }
}
