﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeliverySite.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nu ati introdus numele produsului ")]
        [DisplayName ("Produsul")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Nu ati introdus timpul de pregatire")]
        [DisplayName("Timpul pentru pregatire in minute")]
        public int TimeToReady { get; set; }

        [Required(ErrorMessage = "Nu ati introdus pretul")]
        [DisplayName("Pretul produsului in lei")]
        public int Price { get; set; }

        [DisplayName("Imaginea")]
        public string ImagePath { get; set; }

        [DisplayName("Producatorul")]
        public int ManufacturerId { get; set; }


        

        public Manufacturer Manufacturer { get; set; }

        public ICollection<Command> Command { get; set; }

    
    }
}