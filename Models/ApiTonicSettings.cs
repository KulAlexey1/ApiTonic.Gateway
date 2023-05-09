namespace ApiTonic.Gateway.Models
{
    public class ApiTonicSettings
    {
        public string GatewayName { get; set; }
        public string RedisAddress { get; set; }
        public IEnumerable<ApiTonicProjectSettings> Projects { get; set; }
    }
}
