namespace the_third_cms_api.Models
{
    public class CmsItem : BaseModel
    {
        //public Guid Id { get; set; }
        //public Guid CreatedBy { get; set; }
        //public Guid ModifiedBy { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime ModifiedAt { get; set; }


        public int ItemId { get; set; }

        public string ItemData { get; set; }

        public ItemType ItemType { get; set; }

        public string Url { get; set; }


    }
    public enum ItemType
    {
        Text,
        Image
    }
}
