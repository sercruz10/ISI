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
    
    public partial class RelacaoHabitacaRestricao
    {
        public int IdRelacaoHabitacaRestricao { get; set; }
        public int Habitacao_IdHabitacao { get; set; }
        public int Restricaoo_IdRestricaoo { get; set; }
    
        public virtual Habitacao Habitacao { get; set; }
        public virtual Restricaoo Restricaoo { get; set; }
    }
}
