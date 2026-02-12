using Dapper;
using Project_Recruitment.Entity;
using Project_Recruitment.Interface;
using System.Data;

namespace Project_Recruitment.Business
{
    public class EducationLevelBusiness : IEducationLevelRepository
    {
        private readonly IDbConnection _db;

        public EducationLevelBusiness(IDbConnection db)
        {
            _db = db;
        }

     
        public int Insert(EducationLevelEntity entity)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@LevelName", entity.LevelName);

                
                int result = _db.QueryFirstOrDefault<int>(
                    "SP_EducationLevel_Insert",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result; 
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting education level: {ex.Message}");
            }
        }

     
        public EducationLevelEntity GetById(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EducationLevelId", id);

                var result = _db.QueryFirstOrDefault<EducationLevelEntity>(
                    "SP_EducationLevel_Select",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching education level: {ex.Message}");
            }
        }

   
        public int Update(EducationLevelEntity entity)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EducationLevelId", entity.EducationLevelId);
                parameters.Add("@LevelName", entity.LevelName);

                int rowsAffected = _db.Execute(
                    "SP_EducationLevel_Update",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating education level: {ex.Message}");
            }
        }

     
        public int Delete(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EducationLevelId", id);

                int rowsAffected = _db.Execute(
                    "SP_EducationLevel_Delete",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting education level: {ex.Message}");
            }
        }
    }
}

