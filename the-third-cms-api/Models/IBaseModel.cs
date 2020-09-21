using System;

namespace the_third_cms_api.Models
{
    interface IBaseModel
    {
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
