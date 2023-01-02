using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;

namespace BusinessLayer.Service
{
    public class LabelBussiness
    {
        private readonly ILabelRepository labelRepository;

        public LabelBussiness(ILabelRepository labelRepository)
        {
            this.labelRepository = labelRepository;
        }

        public bool AddLabel(string labelName, long userId, long noteId)
        {
            try
            {
                return labelRepository.AddLabel(labelName, userId, noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<LabelEntity> GetAllLabel(long labelId)
        { 
            try
            {
                return labelRepository.GetAllLabel(labelId);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool DeleteLabel(long labelId, long userId)
        {
            try
            {
                return labelRepository.DeleteLabel(labelId,userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateLabel(string newLabelName, long labelId)
        {
            try
            {
                return labelRepository.UpdateLabel(newLabelName, labelId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
