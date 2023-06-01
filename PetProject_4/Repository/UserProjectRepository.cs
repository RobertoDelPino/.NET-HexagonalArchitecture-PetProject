using PetProject_4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject_4.Domain.Repository
{
    public interface IUserProjectRepository
    {
        List<UserProject> GetAllProject(string userName);
        UserProject GetUserProject(int id);
        void DeleteUserProject(UserProject project);
        void UpdateUserProject(UserProject project);
        void CreateUserProject(UserProject project);
        void SaveChanges();
        bool UserProjectExists(int id);
    }
}
