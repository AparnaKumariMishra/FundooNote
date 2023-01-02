using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Interface
{
    public interface ICollabRepo
    {
        public  CollaboratorEntity AddCollab(long noteId, long userId, string email);
        public List<CollaboratorEntity> GetAllCollab(string email);
        public bool DeleteCollaborator(string email);
    }
}
