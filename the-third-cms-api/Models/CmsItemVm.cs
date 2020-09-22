using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace the_third_cms_api.Models
{
    public class CmsItemVm
    {

        public int ItemId { get; set; }

        public string ItemData { get; set; }

        public ItemType ItemType { get; set; }

        public string Url { get; set; }
    }
}
