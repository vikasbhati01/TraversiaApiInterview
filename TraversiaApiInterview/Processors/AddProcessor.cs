namespace TraversiaApiInterview.Processors
{
    public class AddProcessor
    {
       
            internal static string AddAirport(string name, string code, string iata, IConfiguration configuration)
            {

                return name = DBConfgurationAndOperations.AddAirport(name, code, iata, configuration);
            }

        }
    }

