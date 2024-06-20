namespace SkladDB;

public partial class Скдад
{
    public int Id { get; set; }

    public string Название { get; set; } = null!;

    public string Alias { get; set; } = null!;

    public virtual ICollection<ПеремещениеПоСкладам> ПеремещениеПоСкладамСкладКонечныйNavigations { get; set; } = new List<ПеремещениеПоСкладам>();

    public virtual ICollection<ПеремещениеПоСкладам> ПеремещениеПоСкладамСкладНачальныйNavigations { get; set; } = new List<ПеремещениеПоСкладам>();

    public virtual ICollection<СкладПриход> СкладПриходs { get; set; } = new List<СкладПриход>();

    public virtual ICollection<СкладРасход> СкладРасходs { get; set; } = new List<СкладРасход>();
}
