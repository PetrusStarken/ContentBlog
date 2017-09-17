namespace DataModel
{
    using System;

    public class Token
    {
        public Token() { }

        public long Id { get; set; }
        public int UsuarioId { get; set; }
        public string AuthToken { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime ExpiraEm { get; set; }
    }
}
