using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetProject_4.Domain.Models;
using PetProject_4.Domain.Repository;

namespace PetProject_4.Application.Services
{
    public class UserProjectService
    {

        private readonly IUserProjectRepository projectRepository;

        public UserProjectService(IUserProjectRepository _projectRepository)
        {
            this.projectRepository = _projectRepository;
        }

        public List<UserProject> GetAllBy(string userName)
        {
            List<UserProject> list = projectRepository.GetAllProject(userName);
            return list;
        }

        public UserProject GetById(int id)
        {
            if (id < 0)
            {
                throw new Exception("Id cannot be less than 0");
            }
            UserProject project = projectRepository.GetUserProject(id);
            return project;
        }

        public void Delete(int id)
        {
            if (id < 0)
            {
                throw new Exception("Id cannot be less than 0");
            }

            try
            {
                UserProject userProject = projectRepository.GetUserProject(id);

                if(userProject == null)
                {
                    throw new Exception("No user project was found.");
                }

                projectRepository.DeleteUserProject(userProject);
                projectRepository.SaveChanges();
            }
            catch ( Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public void Update(string id, UserProject project)
        {

            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Id is required");
            }

            if(project == null)
            {
                throw new Exception("Project is required to edit");
            }

            projectRepository.UpdateUserProject(project);
            projectRepository.SaveChanges();
        }

        public void Create(UserProject project)
        {
            if (project == null)
            {
                throw new Exception("Project is required to create");
            }
            projectRepository.CreateUserProject(project);
            projectRepository.SaveChanges();
        }
    }
}
