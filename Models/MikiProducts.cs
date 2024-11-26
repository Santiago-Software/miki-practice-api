namespace miki_practice_api.Models
{
    public class MikiProducts // Represents a single record from the database.
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;//This ensures Name always has a value (string.Empty is a placeholder). Instead of using string?
        public int Price { get; set; }
        public int Stock { get; set; }

    }
}
