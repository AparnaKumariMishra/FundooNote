using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Migrations;

namespace RepositoryLayer.Services
{
    public class NoteRepo : INoteRepo
    {
        FundoContext fundoContext;
        private readonly IConfiguration config;
        public NoteRepo(FundoContext fundoContext, IConfiguration config)
        {
            this.fundoContext = fundoContext;
            this.config = config;
        }
        public NoteEntity AddNote(NoteModel node, long UserId)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();
                {
                    noteEntity.Title = node.Title;
                    noteEntity.Note = node.Note;
                    noteEntity.Reminder = node.Reminder;
                    noteEntity.color = node.color;
                    noteEntity.IsArchive = node.IsArchive;
                    noteEntity.IsPin = node.IsPin;
                    noteEntity.Istrash = node.Istrash;
                    noteEntity.UserId = UserId;
                };
                fundoContext.NoteTable.Add(noteEntity);
                int result = fundoContext.SaveChanges();
                if (result > 0)
                {
                    return noteEntity;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<NoteEntity> GetAllNote(long userId)
        {
            try
            {

                var result = fundoContext.NoteTable.Where(x => x.UserId == userId).ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateNote(long noteId, long userId, NoteModel node)
        {
            try
            {
                var result = fundoContext.NoteTable.FirstOrDefault(e => e.NoteID == noteId && e.UserId == userId);
                if (result != null)
                {
                    if (node.Title != null)
                    {
                        result.Title = node.Title;
                    }
                    if (node.Title != null)
                    {
                        result.Note = node.Title;
                    }
                    result.Modifiedat = DateTime.Now;
                    fundoContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteNote(long noteId, long userId)
        {
            try
            {
                var result = fundoContext.NoteTable.FirstOrDefault(e => e.NoteID == noteId && e.UserId == userId);
                if (result != null)
                {
                    fundoContext.NoteTable.Remove(result);
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


        public bool IsPinNote(long noteId)
        {
            try
            {
                NoteEntity result = fundoContext.NoteTable.Where(e => e.NoteID == noteId).FirstOrDefault();

                if (result.IsPin == true)
                {
                    result.IsPin = false;
                    fundoContext.SaveChanges();
                    return false;
                }
                else
                {
                    result.IsPin = true;
                    fundoContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsArchive(long noteId)
        {
            try
            {
                NoteEntity result = fundoContext.NoteTable.Where(e => e.NoteID == noteId).FirstOrDefault();

                if (result.IsArchive == true)
                {
                    result.IsArchive = false;
                    fundoContext.SaveChanges();
                    return false;
                }
                else
                {
                    result.IsArchive = true;
                    fundoContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Istrash(long noteId)
        {
            try
            {
                NoteEntity result = fundoContext.NoteTable.Where(e => e.NoteID == noteId).FirstOrDefault();

                if (result.Istrash == true)
                {
                    result.Istrash = false;
                    fundoContext.SaveChanges();
                    return false;
                }
                else
                {
                    result.Istrash = true;
                    fundoContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public NoteEntity Updatecolor(long noteId, string color)
        {
            try
            {
                NoteEntity result = fundoContext.NoteTable.Where(e => e.NoteID == noteId).FirstOrDefault();
                if(result != null)
                {
                    result.color = color;
                    fundoContext.SaveChanges();
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool RemoveTrashForever(long noteId)
        {
            try
            {
                var result = fundoContext.NoteTable.Where(e => e.NoteID == noteId).FirstOrDefault();

                if (result.Istrash == true)
                {
                    this.fundoContext.NoteTable.Remove(result);
                   this. fundoContext.SaveChanges();
                    return false;
                }
                else
                {
                    result.Istrash = true;
                  this.fundoContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<NoteEntity> DisplayNotes(long userId)
        {
            try
            {
                var result = fundoContext.NoteTable.Where(e => e.UserId == userId && e.IsArchive == true);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<NoteEntity> DisplayIsTrash(long userId)
        {
            try
            {
                var result = fundoContext.NoteTable.Where(e => e.NoteID == userId && e.Istrash == true);

                if (result != null)
                {
                   
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public NoteEntity Reminder(long noteId, DateTime reminder)
        {
            try
            {
                var result = this. fundoContext.NoteTable.FirstOrDefault(e => e.NoteID == noteId);
                if (result.Reminder != null)
                {
                    result.Reminder = reminder;
                    this.fundoContext.SaveChanges();
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
