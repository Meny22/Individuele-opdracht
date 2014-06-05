using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace NBA_Application
{
    /// <summary>
    /// This class is used to make a connection with the Oracle Database and add objects to this database
    /// </summary>
    public class DatabaseConnection
    {
        public OracleConnection conn;
        String pcn = "SYSTEM";
        String pw = "Metekia22";
        int InsertID = 0;
        int IDGet = 0;
        string NameGet = "";

        public DatabaseConnection()
        {
            conn = new OracleConnection();

            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + " //localhost:1521/orcl" + ";";
           
        }

        /// <summary>
        /// Gets the Max id from a specified table + 1 and returns this so an insert query always has a valid identifier
        /// </summary>
        /// <param name="ID">ID thats gets checked for maximum</param>
        /// <param name="tabelname">Table where the ID is getting checked in</param>
        /// <returns></returns>
        public int GetInsertID(string ID, string tabelname)
        {
            string insertID = "Select NVL(Max(" + ID + "), 0)" + " + 1 as MaxID From " + tabelname;
            OracleCommand commandID = new OracleCommand(insertID, conn);
            commandID.Parameters.Add(new OracleParameter(":parID", ID));

            try
            {
                conn.Open();
                OracleDataReader readerMat = commandID.ExecuteReader();
                readerMat.Read();
                int id = readerMat.GetInt32(0);
                return id;

            }
            catch (OracleException)
            {

            }
            catch (InvalidCastException)
            {

            }
            finally
            {
                conn.Close();
            }
            return 0;
        }

        /// <summary>
        /// This method gets and returns an ID from a given name
        /// </summary>
        /// <param name="Name">Name to search on</param>
        /// <param name="tabelname">Table to search in</param>
        /// <param name="idcolumn">Column where the ID will be returned from</param>
        /// <param name="namecolumn">Column where the name will be returned from</param>
        /// <returns></returns>
        private int GetIDFromName(string Name, string tabelname, string idcolumn, string namecolumn)
        {
            string insertID = "SELECT " + idcolumn + " From " + tabelname + " WHERE " + namecolumn + " = :parName";
            OracleCommand commandID = new OracleCommand(insertID, conn);
            commandID.Parameters.Add(new OracleParameter(":parName", Name));

            try
            {
                if(conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                OracleDataReader readerMat = commandID.ExecuteReader();
                readerMat.Read();
                if (namecolumn == "EmpID")
                {
                    NameGet = readerMat["EmpName"].ToString();
                    return 0;
                }
                int IdGet = readerMat.GetInt32(0);
                return IdGet;

            }
            catch (OracleException)
            {

            }
            catch (InvalidCastException)
            {
                
            }
            return 0;
        }
            
        /// <summary>
        /// Adds a player to the database using the given information
        /// </summary>
        /// <param name="player">Object player that has all the information that will get added to the database</param>
        /// <returns></returns>
        public bool AddPlayer(Player player)
        {
            InsertID = GetInsertID("PlayerID", "Player");
            string sql = "INSERT INTO Player (PlayerID, Name, Length, Weight, School_Country, BirthDate, Pro_Year, Position, Team_Name) VALUES (" +
                ":parID, :parName, :parLength, :parWeight, :parSchool_Country, TO_DATE(:parBirthDate, 'DD-MM-YYYY'), :parPro_Year, :parPosition, :parTeam_Name)";
            OracleCommand PlayerCommand = new OracleCommand(sql, conn);
            PlayerCommand.Parameters.Add(new OracleParameter(":parID", InsertID));
            PlayerCommand.Parameters.Add(new OracleParameter(":parName", player.Name));
            PlayerCommand.Parameters.Add(new OracleParameter(":parLength", player.Length));
            PlayerCommand.Parameters.Add(new OracleParameter(":parWeight", player.Weight));
            PlayerCommand.Parameters.Add(new OracleParameter(":parSchool_Country", player.School_Country));
            PlayerCommand.Parameters.Add(new OracleParameter(":parBirthDate", player.BirthDate));
            PlayerCommand.Parameters.Add(new OracleParameter(":parPro_Year", player.Pro_Year));
            PlayerCommand.Parameters.Add(new OracleParameter(":parPosition", player.Position_Player.ToString()));
            PlayerCommand.Parameters.Add(new OracleParameter(":parTeam_Name", player.TeamName));
            try
            {
                conn.Open();
                PlayerCommand.ExecuteNonQuery();
                return true;
            }
            catch (OracleException)
            {
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Adds a team to the database using the given information
        /// </summary>
        /// <param name="team">Object team that has all the information that gets added to the database</param>
        /// <returns></returns>
        public bool AddTeam(Team team)
        {
            string sql = "INSERT INTO Team (TeamName, City, Founded, Championships, Conference, Division, CompetitionID_, StadiumName) VALUES (" +
                ":parName, :parCity, :parFounded, :parChampionships, :parConference, :parDivision, :parCompetitionID, :Stadium)";
            
            OracleCommand PlayerCommand = new OracleCommand(sql, conn);
            PlayerCommand.Parameters.Add(new OracleParameter(":parName", team.Team_Name));
            PlayerCommand.Parameters.Add(new OracleParameter(":parCity", team.City));
            PlayerCommand.Parameters.Add(new OracleParameter(":parFounded", team.Founded));
            PlayerCommand.Parameters.Add(new OracleParameter(":parChampionships", team.Championships));
            PlayerCommand.Parameters.Add(new OracleParameter(":parConference", team.Conference));
            PlayerCommand.Parameters.Add(new OracleParameter(":parDivision", team.Division));
            PlayerCommand.Parameters.Add(new OracleParameter(":parCompetitionID", 1));
            PlayerCommand.Parameters.Add(new OracleParameter(":parStadium", team.Stadium));

            try
            {
                conn.Open();
                PlayerCommand.ExecuteNonQuery();
                return true;
            }
            catch (OracleException)
            {
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Adds a match to the database using the given information
        /// </summary>
        /// <param name="match">Object Match that has all the information to add the Match to the database</param>
        /// <returns></returns>
        public bool AddMatch(Match match)
        {
            InsertID = GetInsertID("MatchID", "Match");
            string sql = "INSERT INTO Match (MatchID, DateTime, Team_Home, Team_Away, StadiumName, Status) VALUES (" +
                ":parMatchID, :parDate, :parHome, :parAway, :parStadium, :parStatus)";

            OracleCommand PlayerCommand = new OracleCommand(sql, conn);
            PlayerCommand.Parameters.Add(new OracleParameter(":parMatchID", InsertID));
            PlayerCommand.Parameters.Add(new OracleParameter(":parDate", match.DateTime));
            PlayerCommand.Parameters.Add(new OracleParameter(":parHome", match.HomeTeam));
            PlayerCommand.Parameters.Add(new OracleParameter(":parAway", match.AwayTeam));
            PlayerCommand.Parameters.Add(new OracleParameter(":parStadium", match.StadiumName));
            PlayerCommand.Parameters.Add(new OracleParameter(":parStatus", "NOTPLAYED"));

            try
            {
                conn.Open();
                PlayerCommand.ExecuteNonQuery();
                return true;
            }
            catch (OracleException)
            {
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Adds a team_employee to the database using the given information
        /// </summary>
        /// <param name="team_employee">Object team_employee that has all the information to add to the database</param>
        /// <returns></returns>
        public bool AddTeam_Employee(Team_Employee team_employee)
        {
            InsertID = GetInsertID("EmpID", "Team_Employee");
            IDGet = GetIDFromName(team_employee.AssistentName, "Team_Employee", "EmpID", "EmpName");
            string sql = "INSERT INTO Team_Employee (EmpID, EmpName, College, Function, Assistent, TeamEmp) VALUES (" +
                ":parEmpID, :parEmpName, :parCollege, :parFunction, :parAssistent, :parTeamEmp)";

            OracleCommand PlayerCommand = new OracleCommand(sql, conn);
            PlayerCommand.Parameters.Add(new OracleParameter(":parEmpID", InsertID));
            PlayerCommand.Parameters.Add(new OracleParameter(":parEmpName", team_employee.EmployeeName));
            PlayerCommand.Parameters.Add(new OracleParameter(":parCollege", team_employee.College));
            PlayerCommand.Parameters.Add(new OracleParameter(":parFunction", team_employee.Function));
            PlayerCommand.Parameters.Add(new OracleParameter(":parAssistent", IDGet));
            PlayerCommand.Parameters.Add(new OracleParameter(":parTeamEmp", team_employee.TeamName));

            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                PlayerCommand.ExecuteNonQuery();
                return true;
            }
            catch (OracleException)
            {
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Adds a stadium to the database using the given information
        /// </summary>
        /// <param name="stadium">Object stadium that has all the information to add to the database</param>
        /// <returns></returns>
        public bool AddStadium(Stadium stadium)
        {
            string sql = "INSERT INTO Stadium (Stadium_Name, Location, Max_People) VALUES (" +
                ":parName, :parLocation, :parMax)";

            OracleCommand PlayerCommand = new OracleCommand(sql, conn);
            PlayerCommand.Parameters.Add(new OracleParameter(":parName", stadium.StadiumName));
            PlayerCommand.Parameters.Add(new OracleParameter(":parLocation", stadium.Location));
            PlayerCommand.Parameters.Add(new OracleParameter(":parMax", stadium.MaxPeople));

            try
            {
                conn.Open();
                PlayerCommand.ExecuteNonQuery();
                return true;
            }
            catch (OracleException)
            {
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Adds a single ticket to the database using the given information
        /// </summary>
        /// <param name="price">price of the given ticket</param>
        /// <param name="match">Object match that shows for which match the single is good for</param>
        /// <returns></returns>
        public bool AddSingle(int price, Match match)
        {
            InsertID = GetInsertID("TicketID", "Ticket");
            string sql = "BEGIN ADDSINGLE(:parID, :parPrice, :parMatchID); END;";

            OracleCommand NBACommand = new OracleCommand(sql, conn);
            NBACommand.Parameters.Add(new OracleParameter(":parID", InsertID));
            NBACommand.Parameters.Add(new OracleParameter(":parPrice", price));
            NBACommand.Parameters.Add(new OracleParameter(":parMatchID", match.MatchID));

            try
            {
                conn.Open();
                NBACommand.ExecuteNonQuery();
                return true;
            }
            catch (OracleException)
            {
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Adds a season-ticket to the database using the given information
        /// </summary>
        /// <param name="price">price of the given ticket</param>
        /// <param name="begindate">date when the ticket can be used</param>
        /// <param name="team">Object team for which the season-ticket is good for</param>
        /// <returns></returns>
        public bool AddSeasonTicket(int price, DateTime begindate, string team)
        {
            InsertID = GetInsertID("TicketID", "Ticket");
            string sql = "BEGIN ADDSEASONTICKET(:parID, :parPrice, :parBeginDate, :parTeamName); END;";

            OracleCommand NBACommand = new OracleCommand(sql, conn);
            NBACommand.Parameters.Add(new OracleParameter(":parID", InsertID));
            NBACommand.Parameters.Add(new OracleParameter(":parPrice", price));
            NBACommand.Parameters.Add(new OracleParameter(":parBeginDate", begindate));
            NBACommand.Parameters.Add(new OracleParameter(":parTeamName", team));

            try
            {
                conn.Open();
                NBACommand.ExecuteNonQuery();
                return true;
            }
            catch (OracleException)
            {
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Adds a event to the database using the given information
        /// </summary>
        /// <param name="newevent">Object event that has the information for the to be added event</param>
        /// <returns></returns>
        public bool AddEvent(Event newevent)
        {
            InsertID = GetInsertID("EventID","Event");
            string sql = "INSERT INTO EVENT VALUES (" +
                ":parEventID, :parName, :parBegin , :parCompetitionID)";

            OracleCommand NBACommand = new OracleCommand(sql, conn);
            NBACommand.Parameters.Add(new OracleParameter(":parEventID", InsertID));
            NBACommand.Parameters.Add(new OracleParameter(":parName", newevent.EventName));
            NBACommand.Parameters.Add(new OracleParameter(":parBegin", newevent.BeginDate));
            NBACommand.Parameters.Add(new OracleParameter(":parCompetitionID",1));
            

            try
            {
                conn.Open();
                NBACommand.ExecuteNonQuery();
                return true;
            }
            catch (OracleException)
            {
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Gets all matches on a specified date
        /// </summary>
        /// <param name="date">Given date to search on</param>
        /// <returns></returns>
        public List<Match> GetMatches(DateTime date)
        {
            string sql = "Select * From Match Where TRUNC(DATETIME) = TO_DATE(:parDateMatch, 'dd-MM-yy')";
            OracleCommand NBACommand = new OracleCommand(sql, conn);
            NBACommand.Parameters.Add(new OracleParameter(":parDateMatch", date.ToString("dd-MM-yy")));
            try
            {
                conn.Open();
                OracleDataReader NbaReader = NBACommand.ExecuteReader();
                List<Match> Matches = new List<Match>();
                while (NbaReader.Read())
                {
                    int MatchID = Convert.ToInt32(NbaReader["MatchID"]);
                    DateTime DateTime = Convert.ToDateTime(NbaReader["DateTime"]);
                    string TeamHome = NbaReader["Team_Home"].ToString();
                    string TeamAway = NbaReader["Team_Away"].ToString();
                    string Status = NbaReader["Status"].ToString();
                    string StadiumName = NbaReader["StadiumName"].ToString();
                    Match NewMatch = new Match(DateTime, TeamHome, TeamAway, StadiumName);
                    NewMatch.MatchID = MatchID;
                    NewMatch.Status = Status;
                    if (Status == "NOTPLAYED")
                    {

                    }
                    else if (Status == "PLAYED")
                    {
                        NewMatch.HomeScore = Convert.ToInt32(NbaReader["Score_Home"].ToString());
                        NewMatch.AwayScore = Convert.ToInt32(NbaReader["Score_Away"].ToString());
                        NewMatch.TopScorer = NbaReader["Topscorer"].ToString();
                    }
                    Matches.Add(NewMatch);
                }
                return Matches;
            }
            catch (OracleException)
            {
            }
            finally
            {
                conn.Close();
            }
            return null;
            
        }

        /// <summary>
        /// Searches for multiple objects using a searchterm and a filter
        /// </summary>
        /// <param name="searchterm">Text the database will search on</param>
        /// <param name="filter">Tabel in which the database will search in</param>
        /// <param name="searchon">Namecolumn to search on</param>
        /// <returns></returns>
        public List<ISearchable> SearchMultipleObjects(string searchterm, string filter, string searchon)
        {
            string sql = "SELECT * FROM " + filter + " Where " + searchon + " LIKE '%' || :parTerm || '%'";
            OracleCommand NBACommand = new OracleCommand(sql, conn);
            NBACommand.Parameters.Add(":parTerm", searchterm);
            List<ISearchable> SearchFound = new List<ISearchable>();
            try
            {
                conn.Open();
                OracleDataReader NBAReader = NBACommand.ExecuteReader();
                while (NBAReader.Read())
                {
                        if (filter == "Team")
                        {
                            string FoundName = NBAReader["TeamName"].ToString();
                            string City = NBAReader["City"].ToString();
                            int Founded = Convert.ToInt32(NBAReader["Founded"].ToString());
                            int Championships = Convert.ToInt32(NBAReader["Championships"].ToString());
                            string Conference = NBAReader["Conference"].ToString();
                            string Division = NBAReader["Division"].ToString();
                            string NewStadium = NBAReader["StadiumName"].ToString();
                            Team NewTeam = new Team(FoundName, City, Founded, Conference, Division, NewStadium);
                            SearchFound.Add(NewTeam);
                        }
                        else if (filter == "Player")
                        {
                            string FoundName = NBAReader["Name"].ToString();
                            int Length = Convert.ToInt32(NBAReader["Length"].ToString());
                            int Weight = Convert.ToInt32(NBAReader["Weight"].ToString());
                            string SchoolCountry = NBAReader["Weight"].ToString();
                            string BirthDate = Convert.ToDateTime(NBAReader["BirthDate"]).ToString("dd-MM-yyyy");
                            int Pro_Year = Convert.ToInt32(NBAReader["Pro_Year"].ToString());
                            Player.Position Position;
                            Enum.TryParse(NBAReader["Position"].ToString(), out Position);
                            string Team = NBAReader["Team_Name"].ToString();
                            Player NewPlayer = new Player(FoundName, Length, Weight, SchoolCountry, BirthDate, Pro_Year, Position, Team);
                            SearchFound.Add(NewPlayer);

                        }
                        else if (filter == "Team_Employee")
                        {
                            string FoundName = NBAReader["EmpName"].ToString();
                            string College = NBAReader["College"].ToString();
                            string Function = NBAReader["Function"].ToString();
                            string TeamName = NBAReader["TeamEmp"].ToString();
                            string AssistentID = NBAReader["Assistent"].ToString();
                            if (AssistentID != "")
                            {
                                GetIDFromName(AssistentID, "Team_Employee", "EmpName", "EmpID"); 
                            }
                            string Assistent = NameGet;
                            Team_Employee NewEmp = new Team_Employee(FoundName, College, Function, Assistent, TeamName);
                            SearchFound.Add(NewEmp);
                        }
                        else if (filter == "Event")
                        {
                            string EventName = NBAReader["EventName"].ToString();
                            string BeginDate = NBAReader["BeginDate"].ToString();
                            Event NewEvent = new Event(EventName, BeginDate);
                            SearchFound.Add(NewEvent);
                        }
                        else if (filter == "Stadium")
                        {
                            string Name = NBAReader["Stadium_Name"].ToString();
                            string Location = NBAReader["Location"].ToString();
                            int MaxPeople = Convert.ToInt32(NBAReader["Max_People"].ToString());
                            Stadium NewStadium = new Stadium(Name, Location, MaxPeople);
                            SearchFound.Add(NewStadium);
                        }
                    }
                
            
                return SearchFound;
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        /// <summary>
        /// Adds the details of a match to the database using the given information
        /// </summary>
        /// <param name="MatchID">MatchID from the match that gets updated</param>
        /// <param name="home_score">Home score that gets added to the database</param>
        /// <param name="away_score">Away score that gets added to the database</param>
        /// <param name="top_scorer">Player with the most points in this game</param>
        /// <returns></returns>
        public bool AddDetails(int MatchID, int home_score, int away_score, string top_scorer)
        {
            string sql = "UPDATE Match SET Score_Home = :parHome, Score_Away = :parAway, Topscorer = :parTop_Scorer, Status = 'PLAYED' Where MatchID = :parMatchID";
            OracleCommand NBACommand = new OracleCommand(sql, conn);
            NBACommand.Parameters.Add(new OracleParameter(":parHome", home_score));
            NBACommand.Parameters.Add(new OracleParameter(":parAway", away_score));
            NBACommand.Parameters.Add(new OracleParameter(":parTop_Scorer", top_scorer));
            NBACommand.Parameters.Add(new OracleParameter(":parMatchID", MatchID));
            try
            {
                conn.Open();
                NBACommand.ExecuteNonQuery();
                return true;
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        /// <summary>
        /// This method add a purchase for a ticket to the database and also the customer
        /// </summary>
        /// <param name="MatchID">MatchID of the ticket</param>
        /// <param name="name">Name of the customer</param>
        /// <param name="banknumber">Banknumber of the customer</param>
        /// <returns></returns>
        public bool BuyTicket(int MatchID, string name, string banknumber)
        {
            InsertID = GetInsertID("CustID", "Customer");
            string sql = "BEGIN ADDCUST(:parID, :parName, :parBank, :parMatchID); END;";
            OracleCommand NBACommand = new OracleCommand(sql, conn);
            NBACommand.Parameters.Add(":parID", InsertID);
            NBACommand.Parameters.Add(":parName", name);
            NBACommand.Parameters.Add(":parBank", banknumber);
            NBACommand.Parameters.Add(":parMatchID", MatchID);
            try
            {
                conn.Open();
                NBACommand.ExecuteNonQuery();
                return true;
            }
            catch
            {

            }
            return false;
        }
            
        
    }
}