using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Migrations;
using static BusinessLayer.Service.NoteBussiness;

namespace BusinessLayer.Service
{
    public class NoteBussiness
    {

        private readonly INoteRepo noteRepo;

        public NoteBussiness(INoteRepo noteRepo)
        {
            this.noteRepo = noteRepo;
        }

        public NoteEntity AddNote(NoteModel noteModel, long userId)
        {
            try
            {
                return noteRepo.AddNote(noteModel, userId);
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
                return this.UpdateNote(noteId, userId, node);


            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteNote(long userId, long noteId)
        {
            try
            {
                return noteRepo.DeleteNote(userId, noteId);
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

                return GetAllNote(userId);
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
                return IsPinNote(noteId);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool IsArchive(long noteId)
        {
            try
            {
                return IsArchive(noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Istrash(long noteId)
        {
            try
            {
                return Istrash(noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public NoteEntity Updatecolor(long noteId, string color)
        {
            try
            {

                return Updatecolor(noteId, color);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RemoveTrashForever(long noteId)
        {
            try
            {

                return RemoveTrashForever(noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<NoteEntity> DisplayNotes(long userId)
        {
            try
            {
                return DisplayNotes(userId);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public IEnumerable<NoteEntity> DisplayIsTrash(long userId)
        {
            try
            {
                return DisplayIsTrash(userId);
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
                return Reminder(noteId,reminder);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
