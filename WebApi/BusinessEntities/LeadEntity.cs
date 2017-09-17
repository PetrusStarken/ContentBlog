namespace BusinessEntities
{
    public class LeadEntity
    {
        public LeadEntity() { }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string EnderecoIpv4 { get; set; }
        public string DataRegistro { get; set; }
    }
}
