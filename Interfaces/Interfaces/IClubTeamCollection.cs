using Interfaces.DTO;

namespace Dal.Context
{
    public interface IClubTeamCollection
    {
        void AddTeam(ClubTeamDto clubTeam);
        void DeleteTeam(ClubTeamDto clubTeam);
        ClubTeamDto GetTeamByID(int id);
    }
}