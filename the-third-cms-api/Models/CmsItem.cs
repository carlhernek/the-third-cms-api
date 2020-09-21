namespace the_third_cms_api.Models
{
    public class CmsItem : BaseModel
    {

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
