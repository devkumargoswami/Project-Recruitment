using Project_Recruitment.Entity;
using Project_Recruitment.DTOs;

namespace Project_Recruitment.Interface
{
    public interface IResultRepositry
    {
        public string Insert(ResultDTO model);
        public string Update(ResultDTO model);
        public List<Result> GetByCandidate(int candidateId);
        public string Delete(int id);
    }
}
