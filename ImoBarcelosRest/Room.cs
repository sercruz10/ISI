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
    
    public partial class Room
    {
        public int IdRoom { get; set; }
        public string Descricao { get; set; }
        public string NCamas { get; set; }
        public string Area { get; set; }
        public string NJanelas { get; set; }
        public string Sacada { get; set; }
        public int Habitacao_IdHabitacao { get; set; }
        public double ValorEuros { get; set; }
        public byte[] Foto { get; set; }
        public string Estado { get; set; }
    
        public virtual Habitacao Habitacao { get; set; }
    }
}
