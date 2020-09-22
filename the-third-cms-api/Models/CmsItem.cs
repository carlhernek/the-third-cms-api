using System.ComponentModel.DataAnnotations.Schema;

namespace the_third_cms_api.Models
{
    public class CmsItem : BaseModel
    {
        //public Guid Id { get; set; }
        //public Guid CreatedBy { get; set; }
        //public Guid ModifiedBy { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime ModifiedAt { get; set; }


        //public CmsItem()
        //{

        //}
        //public CmsItem(string url, string itemData, ItemType itemType = ItemType.Text, int id = 0, byte[]? img = null)
        //{


        //    //Set id to 0 if it is not supplied.
        //    this.ItemId = id;
        //    this.ItemData = itemData;
        //    this.ItemType = itemType;
        //    this.Url = url;
        //    this.Image = img;
        //}



        public int ItemId { get; set; } = 0; //This should be handle be DB

        public string ItemData { get; set; } = string.Empty; //Should be link if there is image.

        public ItemType ItemType { get; set; } = ItemType.Empty;

        public string Url { get; set; } = string.Empty;

        [NotMapped]
        public byte[]? Image { get; set; } //= null; //If set, ItemData should link here.


    }
    public enum ItemType
    {
        Empty = 0,
        Image,
        Text,
    }
}
