//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Salon.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Services
    {
        public Services()
        {
            this.SaleServices = new HashSet<SaleServices>();
            this.Appointment = new HashSet<Appointment>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public System.TimeSpan Duration { get; set; }
    
        public virtual ICollection<SaleServices> SaleServices { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
