namespace ContactApp.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Number { get; set; }
        public string PhotoUrl { get; set; }
        public int UserId { get; set; }
    }
}
