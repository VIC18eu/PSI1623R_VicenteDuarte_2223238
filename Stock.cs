//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetoFinal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stock
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stock()
        {
            this.ReservaProduto = new HashSet<ReservaProduto>();
        }
    
        public int Id { get; set; }
        public int MedicamentoId { get; set; }
        public int FarmaciaId { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    
        public virtual Farmacia Farmacia { get; set; }
        public virtual Medicamento Medicamento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservaProduto> ReservaProduto { get; set; }
    }
}
