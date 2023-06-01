using Microsoft.EntityFrameworkCore;
using PetProject_4.Domain.Models;
using PetProject_4.Domain.Repository;
using PetProject_4.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PetProject_4.Infrastructure.Data.Repositories
{
    public class UserProjectRepository : IUserProjectRepository
    {
        private readonly UsersContext db;

        public UserProjectRepository(UsersContext _db)
        {
            this.db = _db;
        }

        public void CreateUserProject(UserProject project)
        {
            try
            {
                db.UserProjects.Add(project);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public void DeleteUserProject(UserProject project)
        {
            try
            {
                db.UserProjects.Remove(project);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public List<UserProject> GetAllProject(string userName)
        {
            try
            {
                List<UserProject> projects = db.UserProjects.Where(x => x.User.UserName == userName).ToList();
                return projects;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public UserProject GetUserProject(int id)
        {
            try
            {
                UserProject? project = db.UserProjects.FirstOrDefault(x => x.ProjectId == id);
                if (project == null)
                {
                    throw new Exception("Project with id " + id + " doesnt exist");
                }

                return project;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public void UpdateUserProject(UserProject project)
        {
            try
            {
                db.UserProjects.Update(project);
            }catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public void SaveChanges()
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public bool UserProjectExists(int id)
        {
            try
            {
                bool result = (db.UserProjects?.Any(e => e.ProjectId == id)).GetValueOrDefault();
                return result;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}
