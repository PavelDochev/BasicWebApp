//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime PublishedOn { get; set; }
        public string Author { get; set; }
        public int BookTypeID { get; set; }
    
        public virtual BookType BookType { get; set; }
    }
}