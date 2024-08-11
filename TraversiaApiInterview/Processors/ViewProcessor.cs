namespace TraversiaApiInterview.Processors
{
    public class ViewProcessor
    {
        internal static List<AirportInfo> ViewAllSectors(IConfiguration configuration)
        {
           List<AirportInfo> airportInfos = new List<AirportInfo>();

            airportInfos=DBConfgurationAndOperations.GetAirports(configuration);

            return airportInfos;
        }

        


       
    }
}
