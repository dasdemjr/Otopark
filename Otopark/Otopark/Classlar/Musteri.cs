using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otopark.Classlar
{
    internal class Musteri
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar")]

        public string AdiSoyadi { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]

        public string Telefon { get; set; }
        [Column(TypeName = "varchar")]

        public string Adres { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(70)]

        public string EMail { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(100)]

        public string Resim { get; set; }

        public DateTime Tarih { get; set; }
    }
}
