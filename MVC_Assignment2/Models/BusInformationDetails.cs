using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_Assignment2.Models
{
    public class BusInformationDetails
    {
        // Created Method To Insert BusInformation to Database
        public void AddBusInformation(BusInformation busInformation)
        {
            string connectStr = ConfigurationManager.ConnectionStrings["BusInformationContext"].ConnectionString;

            // Created Connection
            using(SqlConnection conn = new SqlConnection(connectStr))
            {
                // Created Command using Stored Procedure
                SqlCommand cmd = new SqlCommand("Insert_BusInformation", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paraBoardingPoint = new SqlParameter();
                paraBoardingPoint.ParameterName = "@BoardingPoint";
                paraBoardingPoint.Value = busInformation.BoardingPoint;
                cmd.Parameters.Add(paraBoardingPoint);

                SqlParameter paraTravelDate = new SqlParameter();
                paraTravelDate.ParameterName = "@TravelDate";
                paraTravelDate.Value = busInformation.TravelDate;
                cmd.Parameters.Add(paraTravelDate);

                SqlParameter paraAmount = new SqlParameter();
                paraAmount.ParameterName = "@Amount";
                paraAmount.Value = busInformation.Amount;
                cmd.Parameters.Add(paraAmount);

                SqlParameter paraRating = new SqlParameter();
                paraRating.ParameterName = "@Rating";
                paraRating.Value = busInformation.Rating;
                cmd.Parameters.Add(paraRating);

                SqlParameter paraDroppingPoint = new SqlParameter();
                paraDroppingPoint.ParameterName = "@DroppingPoint";
                paraDroppingPoint.Value= busInformation.DroppingPoint;
                cmd.Parameters.Add(paraDroppingPoint);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}