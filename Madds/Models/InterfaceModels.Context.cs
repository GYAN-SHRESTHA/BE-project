﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Madds.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Python_linkEntities : DbContext
    {
        public Python_linkEntities()
            : base("name=Python_linkEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Link> Links { get; set; }
    
        public virtual int Insert(Nullable<bool> id, string searchname)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(bool));
    
            var searchnameParameter = searchname != null ?
                new ObjectParameter("Searchname", searchname) :
                new ObjectParameter("Searchname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Insert", idParameter, searchnameParameter);
        }
    }
}
