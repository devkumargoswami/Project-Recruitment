using Dapper;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;
using System.Data;

namespace Project_Recruitment.Business
{
    public class EducationLevelBusiness : IEducationLevelRepository
    {
        private readonly IDbConnection educationLevelConnection;

        public EducationLevelBusiness(IDbConnection educationLevelsConnection)
        {
            educationLevelConnection = educationLevelsConnection;
        }

        public int Insert(EducationLevelEntity entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@LevelName", entity.LevelName);

            return educationLevelConnection.QueryFirstOrDefault<int>(
                "SP_EducationLevel_Insert",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public EducationLevelEntity GetById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@EducationLevelId", id);

            return educationLevelConnection.QueryFirstOrDefault<EducationLevelEntity>(
                "SP_EducationLevel_Select",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public int Update(EducationLevelEntity entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@EducationLevelId", entity.EducationLevelId);
            parameters.Add("@LevelName", entity.LevelName);

            return educationLevelConnection.Execute(
                "SP_EducationLevel_Update",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public int Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@EducationLevelId", id);

            return educationLevelConnection.Execute(
                "SP_EducationLevel_Delete",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
