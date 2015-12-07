using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cheetah2.Models
{
    public class ListModel
    {
        public List<SelectListItem> section { get; private set; }

        public ListModel()
        {
            section = new List<SelectListItem>();
        }
    }

}