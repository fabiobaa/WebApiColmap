//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiColmap.Data_Access.Entity_Framework
{
    using System;
    using System.Collections.Generic;
    
    public partial class map_tblFeatures
    {
        public int fo_idFeature_pk { get; set; }
        public int fo_idProperties_fk { get; set; }
        public int fo_idGeometry_fk { get; set; }
        public string fo_type { get; set; }
    
        public virtual map_tblGeometry map_tblGeometry { get; set; }
        public virtual map_tblProperties map_tblProperties { get; set; }
    }
}