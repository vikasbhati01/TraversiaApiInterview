namespace TraversiaApiInterview.Processors
{
    public class DeleteProcessor
    {

        internal static bool DeleteAirport(string name, IConfiguration configuration)
        {

            return DBConfgurationAndOperations.DeleteAirPort(name, configuration);
        }
    }
}
