namespace SkladApi.Model
{
    public class CustomerDto
    {

        public int Id { get; set; }

        public string Псевдоним { get; set; } = null!;

        public string Фио { get; set; } = null!;

        public string Телефон { get; set; } = null!;

        public string Город { get; set; } = null!;

        public decimal ПределКредита { get; set; }
        //   public bool Hidden { get; set; }

    }
}