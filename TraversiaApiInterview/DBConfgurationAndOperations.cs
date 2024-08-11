using Microsoft.Data.SqlClient;
using System.Data;

namespace TraversiaApiInterview
{

    internal class DBConfgurationAndOperations
    {
        internal  static  List<AirportInfo> GetAirports(IConfiguration configuration)
        {
            var airportInfos = new List<AirportInfo>();
            string conn = configuration["DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SelectAllAirports", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters if needed
                       /* command.Parameters.AddWithValue("@ParameterName", "ParameterValue");*/

                        // Execute the stored procedure
                        SqlDataReader reader = command.ExecuteReader();
                        
                        while (reader.Read())
                        {
                            string AirPortName = reader.GetString(reader.GetOrdinal("AirPortName"));
                            string AirPortCode = reader.GetString(reader.GetOrdinal("AirPortCode"));
                            string IATA = reader.GetString(reader.GetOrdinal("IATA"));

                            AirportInfo airportInfo = new AirportInfo();
                            airportInfo.Name = AirPortName;
                            airportInfo.Code= AirPortCode;
                            airportInfo.IATA=IATA;
                            airportInfos.Add(airportInfo);
                                // Replace ColumnName with actual column name from your SP
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return airportInfos;
        }


        internal static string AddAirport(string name ,string code ,string IATA,IConfiguration configuration)
        {
            bool isAirportAdded =false;

            using (SqlConnection connection = new SqlConnection(configuration["DefaultConnection"]))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("AddAirPort", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters if needed
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@code", code);
                        command.Parameters.AddWithValue("@IATA", IATA);

                        // Execute the stored procedure
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Console.WriteLine(reader["ColumnName"]); // Replace ColumnName with actual column name from your SP
                        }

                        reader.Close();
                        isAirportAdded = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }


            if (isAirportAdded== true)
            {
                return name + " is Added";
            }
            else
            {
                return null;
            }
        }


        internal static bool DeleteAirPort(string name,IConfiguration configuration)
        {
            bool isAirportAdded = false;
            using (SqlConnection connection = new SqlConnection(configuration["DefaultConnection"]))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DeleteAirPort", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters if needed
                        command.Parameters.AddWithValue("@name", name);

                        // Execute the stored procedure
                        int rowsAffected = command.ExecuteNonQuery();

                    }
                        return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
