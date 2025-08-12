using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    internal class Note
    {
        public string Title { get; set; }      // Titel der Notiz
        public string Content { get; set; }    // Inhalt
        public DateTime CreatedAt { get; set; } // Erstelldatum
        //public string Cover { get; set; }       // Optionales "Cover"-Bild oder Symbol

    }
}
