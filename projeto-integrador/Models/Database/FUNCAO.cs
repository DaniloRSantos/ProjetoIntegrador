//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projeto_Integrador.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class FUNCAO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FUNCAO()
        {
            this.FUNCIONARIO = new HashSet<FUNCIONARIO>();
        }
    
        public byte COD_FUNCAO { get; set; }
        public string NOM_FUNCAO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNCIONARIO> FUNCIONARIO { get; set; }
    }
}
