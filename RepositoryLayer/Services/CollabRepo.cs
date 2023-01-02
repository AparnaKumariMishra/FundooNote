using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Services
{
    public class CollabRepo : ICollabRepo
    {
        FundoContext fundoContext;
        private readonly IConfiguration config;
        public CollabRepo(FundoContext fundoContext, IConfiguration config)
        {
            this.fundoContext = fundoContext;
            this.config = config;
        }
        public CollaboratorEntity AddCollab(long noteId, long userId, string email)
        {
            try
            {
                CollaboratorEntity collaboratorEntity = new CollaboratorEntity();
                collaboratorEntity.CollaboratorEmail = email;
                collaboratorEntity.UserId = userId;
                collaboratorEntity.NoteId = noteId;
                collaboratorEntity.Modifiedat = DateTime.Now;
                fundoContext.Collaborator.Add(collaboratorEntity);
                int result = fundoContext.SaveChanges();
                if (result != null)
                {
                    return collaboratorEntity;
                }
                return null;
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

                var result = this.fundoContext.Collaborator.Where(x => x.CollaboratorEmail == email).ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteCollaborator(string email)
        {
            try
            {
                var result = this.fundoContext.Collaborator.FirstOrDefault(e => e.CollaboratorEmail == email);
                if (result != null)
                {
                    fundoContext.Collaborator.Remove(result);
                    fundoContext.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
