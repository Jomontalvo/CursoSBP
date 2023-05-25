namespace CursoSBP.Web.Helpers
{
    public class ConfigurationRoutes : IConfigurationRoutes
    {
        private readonly IConfiguration _configuration;

        public ConfigurationRoutes(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Base Address
        public string ApiUrl => _configuration.GetValue<string>("ApiServices:UrlBase", "https://localhost/")!;
        public string Prefix => _configuration.GetValue<string>("ApiServices:Prefix", "api/")!;
        #endregion

        #region Controllers
        public string Students => _configuration.GetValue<string>("ApiServices:Controllers:Students", string.Empty)!;
        public string Subjects => _configuration.GetValue<string>("ApiServices:Controllers:Subjects", string.Empty)!;
        #endregion
    }
}
