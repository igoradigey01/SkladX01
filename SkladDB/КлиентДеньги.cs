namespace SkladDB;

public partial class КлиентДеньги
{
    public int Id { get; set; }

    public int КлиентId { get; set; }

    public DateTime Дата { get; set; }

    public decimal CуммаПринятыхДенег { get; set; }

    public int МеткаId { get; set; }

    public virtual Клиент Клиент { get; set; } = null!;

    public virtual КлиентМеткаРасчет Метка { get; set; } = null!;
}
