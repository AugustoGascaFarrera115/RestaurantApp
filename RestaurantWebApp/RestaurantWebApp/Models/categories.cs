//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestaurantWebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class categories
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public categories()
        {
            this.restaurants = new HashSet<restaurants>();
        }
    
        public int id { get; set; }
        public int idProduct { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool active { get; set; }
    
        public virtual products products { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<restaurants> restaurants { get; set; }
    }
}
