using Project_Recruitment.Entity;
using Project_Recruitment.DTOs;

namespace Project_Recruitment.Interface
{
    public interface IResult
    {
        string Insert(ResultDTO model);
        string Update(ResultDTO model);
        List<Result> GetByCandidate(int candidateId);
        string Delete(int id);
    }
}
