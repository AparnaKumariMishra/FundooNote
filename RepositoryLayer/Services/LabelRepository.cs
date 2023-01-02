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
    public class LabelRepository: ILabelRepository
    {
        FundoContext  fundoContext;
        private readonly IConfiguration config;
        public LabelRepository(FundoContext fundoContext)
        {
            this.fundoContext = fundoContext;
        }
        public bool AddLabel(string labelName, long userId, long noteId)
        {
            try
            {
                var result = this.fundoContext.NoteTable.FirstOrDefault(e => e.NoteID == noteId);
                    if(result != null)
                   {
                    LabelEntity labelEntity = new LabelEntity();
                    labelEntity.LabelName = labelName;
                    labelEntity.UserId = userId;
                    labelEntity.NoteId = noteId;
                    this.fundoContext.LabelTable.Add(labelEntity);
                    this.fundoContext.SaveChanges();
                    return true;
                  }
                    else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<LabelEntity> GetAllLabel(long labelId)
        {
            try
            {

                var result = this.fundoContext.LabelTable.Where(x => x.LabelId == labelId).ToList();
                return result;
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
                var result = this.fundoContext.LabelTable.FirstOrDefault(e => e.LabelId == labelId );
                if (result != null)
                {
                    fundoContext.LabelTable.Remove(result);
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

        public bool UpdateLabel(string newLabelName, long labelId)
        {
            try
            {
                var result = this.fundoContext.LabelTable.FirstOrDefault(e => e.LabelId == labelId);
                if(result != null)
                {
                    result.LabelName = newLabelName;
                    this.fundoContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }

}
