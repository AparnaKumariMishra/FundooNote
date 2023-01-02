using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;

namespace BusinessLayer.Service
{
    public class CollabBussiness
    {
        private readonly ICollabRepo collabRepo;

        public CollabBussiness(ICollabRepo CollabRepo)
        {
            this.collabRepo = collabRepo;
        }
        public  CollaboratorEntity AddCollab(long noteId, long userId, string email)
        {
            try
            {
                return collabRepo.AddCollab(userId, noteId, email);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<CollaboratorEntity> GetAllCollab(string email)
        {
            try
            {
                return collabRepo.GetAllCollab(email);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteCollab(string email)
        {
            try
            {
                return collabRepo.DeleteCollaborator(email);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
