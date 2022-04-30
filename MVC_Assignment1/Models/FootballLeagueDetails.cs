using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace MVC_Assignment1.Models
{
    public class FootballLeagueDetails
    {

    // Method to store Data to Database 
      public void addMatchDetails(FootBallLeague football)
        {
            string connectStr = ConfigurationManager.ConnectionStrings["FootBallLeague"].ConnectionString;

            // Created SQL Connection
            using (SqlConnection conn = new SqlConnection(connectStr))
            {
                // Created SQL Command using Stored Procedure
                SqlCommand cmd = new SqlCommand("insert_footballleague",conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Store Match ID data
                SqlParameter paraMatchId = new SqlParameter();
                paraMatchId.ParameterName = "@MatchId";
                paraMatchId.Value = football.MatchId;
                cmd.Parameters.Add(paraMatchId);

                // Store Team Name1 data
                SqlParameter paraTeamName1 = new SqlParameter();
                paraTeamName1.ParameterName = "@TeamName1";
                paraTeamName1.Value = football.TeamName1;
                cmd.Parameters.Add(paraTeamName1);

                // Store Team Name2 data
                SqlParameter paraTeamName2 = new SqlParameter();
                paraTeamName2.ParameterName = "@TeamName2";
                paraTeamName2.Value = football.TeamName2;
                cmd.Parameters.Add(paraTeamName2);

                // Store Match Status data 
                SqlParameter paraMatchStatus = new SqlParameter();
                paraMatchStatus.ParameterName = "@MatchStatus";
                paraMatchStatus.Value = football.MatchStatus;
                cmd.Parameters.Add(paraMatchStatus);

                // Store Winning Team data
                SqlParameter paraWinningTeam = new SqlParameter();
                paraWinningTeam.ParameterName = "@WinningTeam";
                paraWinningTeam.Value = football.WinningTeam;

                // If Match Status is win then store Winning Team Name else store NULL value
                if (football.MatchStatus.Contains("Win"))
                {
                    cmd.Parameters.Add(paraWinningTeam);
                }
                else
                    cmd.Parameters.AddWithValue("@WinningTeam", DBNull.Value);

                // Store Points data 
                SqlParameter paraPoints = new SqlParameter();
                paraPoints.ParameterName = "@Points";
                paraPoints.Value = football.Points;
                cmd.Parameters.Add(paraPoints);

                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }

    }
}