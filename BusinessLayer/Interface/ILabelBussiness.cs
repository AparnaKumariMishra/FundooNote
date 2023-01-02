using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Entity;

namespace BusinessLayer.Interface
{
    public interface ILabelBussiness
    {
        public bool AddLabel(string labelName, long userId, long noteId);
        public List<LabelEntity> GetAllLabel(long labelId);
        public bool DeleteLabel(long labelId, long userId);
        public bool UpdateLabel(string newLabelName, long labelId);
    }
}
