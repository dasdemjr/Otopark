using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otopark.Classlar
{
    internal class Seri
    {
        public int ID { get; set; }
        public int MarkaID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(70)]
        public string seri { get; set; }
        public virtual Marka Marka { get; set; }
        public virtual ICollection<AracParkBilgileri> AracParkBilgileris { get; set; }
    }
}
