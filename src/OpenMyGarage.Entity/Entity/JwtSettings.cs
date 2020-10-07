namespace OpenMyGarage.Entity.Entity
{
    public class JwtSettings
    {
        public string Site { get; set; }
        public string SigningKey { get; set; }
        public int ExpiryInDays { get; set; }
    }
}
