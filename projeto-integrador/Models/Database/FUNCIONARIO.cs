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
    
    public partial class FUNCIONARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FUNCIONARIO()
        {
            this.ALUNO = new HashSet<ALUNO>();
            this.MEDICAO = new HashSet<MEDICAO>();
        }
    
        public long CPF_PESSOA { get; set; }
        public byte COD_FUNCAO { get; set; }
        public string CTP_PESSOA { get; set; }
        public long PIS_FUNCIONARIO { get; set; }
        public long RES_FUNCIONARIO { get; set; }
        public long CRE_FUNCIONARIO { get; set; }
        public bool STA_FUNCIONARIO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALUNO> ALUNO { get; set; }
        public virtual FUNCAO FUNCAO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEDICAO> MEDICAO { get; set; }
        public virtual PESSOA PESSOA { get; set; }
    }
}
