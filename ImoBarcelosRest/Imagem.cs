//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImoBarcelosRest
{
    using System;
    using System.Collections.Generic;
    
    public partial class Imagem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Imagem()
        {
            this.RHabitacaoImagem = new HashSet<RHabitacaoImagem>();
        }
    
        public int IdImagem { get; set; }
        public string Filename { get; set; }
        public byte[] Imagem1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RHabitacaoImagem> RHabitacaoImagem { get; set; }
    }
}