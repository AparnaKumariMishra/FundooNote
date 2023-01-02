using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Interface
{
    public interface INoteRepo
    {
        public NoteEntity AddNote(NoteModel noteModel,long UserId);
        public bool UpdateNote(long noteId, long userId, NoteModel node);
        public bool DeleteNote(long userId, long noteId);
        public List<NoteEntity> GetAllNote(long userId);
        public bool IsPinNote(long noteId);
        public bool IsArchive(long noteId);
        public bool Istrash(long noteId);
        public NoteEntity Updatecolor(long noteId, string color);
        public bool RemoveTrashForever(long noteId);
        public IEnumerable<NoteEntity> DisplayNotes(long userId);
        public IEnumerable<NoteEntity> DisplayIsTrash(long userId);
        public NoteEntity Reminder(long noteId, DateTime reminder);

    }
}
