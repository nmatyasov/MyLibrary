﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksOrganizer.Model
{
    public class ISBN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ISBNId { get; set; }
        [StringLength(32)]
        public string Value { get; set; }

        public virtual ICollection<BookISBN> BookISBNs { get; set; }
    }
}
