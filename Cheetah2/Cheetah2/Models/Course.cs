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
    using System.ComponentModel.DataAnnotations;

    public partial class Course
    {
        [Range(100,650)]
        public int CourseNumber { get; set; }

        public string CourseName { get; set; }

        [Range(1,4)]
        public int Credits { get; set; }
    }
}
