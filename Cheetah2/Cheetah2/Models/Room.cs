//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cheetah2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Room
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public bool HasLab { get; set; }
        public bool HasProjector { get; set; }
        public bool HasWhiteboard { get; set; }
    }
}