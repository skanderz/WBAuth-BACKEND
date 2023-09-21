namespace WBAuth.BO
{
    public class Fonction
    {
        public int IdFonction { get; set; }
        public string? Nom { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public Permission? Permission { get; set; }
        public int IdApplication { get; set; }
        public Application? Application { get; set; }

    }
}
