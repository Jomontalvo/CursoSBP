namespace CursoSBP.Web.Helpers
{
    public interface IConfigurationRoutes
    {
        string ApiUrl { get; }
        string Prefix { get; }
        string Students { get; }
        string Subjects { get; }
    }
}