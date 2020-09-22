namespace the_third_cms_api.Models
{

    public class CmsItemVm
    {

        /// <summary>
        /// Item Id
        /// </summary>
        /// This together with url should be unique.

        public int ItemId { get; set; } //= 0; //Or whichever is the highest+1 in db.



        //[DataType(DataType.Text)]
        public string ItemData { get; set; } = string.Empty;


        //[DataType(DataType.Upload)]
        public byte[]? Image { get; set; } = null;


        public ItemType ItemType { get; set; } = ItemType.Empty;


        //[DataType(DataType.Url, ErrorMessage = "Invalid Url")]
        public string Url { get; set; } = string.Empty;
    }
}
