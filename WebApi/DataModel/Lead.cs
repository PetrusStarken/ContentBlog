namespace DataModel
{
    using System;

    public class Lead
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string EndercoIpv4 { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
