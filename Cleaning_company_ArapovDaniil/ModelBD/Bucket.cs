//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cleaning_company_ArapovDaniil.ModelBD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bucket
    {
        public int ID { get; set; }
        public int PackageID { get; set; }
        public Nullable<int> TakeID { get; set; }
    
        public virtual Package Package { get; set; }
    }
}
