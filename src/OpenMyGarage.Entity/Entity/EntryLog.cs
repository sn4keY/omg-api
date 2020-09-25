﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OpenMyGarage.Entity.Entity
{
    public class EntryLog
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Plate { get; set; }

        [Required]
        [Column(TypeName = "bigint")]
        public long EntryTime { get; set; }

        [Required]
        public string PictureURL { get; set; }
    }
}