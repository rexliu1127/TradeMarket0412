//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryTradeMarket
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        public int id { get; set; }
        public int department_id { get; set; }
        public string public_id { get; set; }
        public string product_customize_id { get; set; }
        public string product_name { get; set; }
        public string short_product_name { get; set; }
        public string english_name { get; set; }
        public int product_type_id { get; set; }
        public string specification1 { get; set; }
        public string specification2 { get; set; }
        public string specification3 { get; set; }
        public decimal length { get; set; }
        public decimal width { get; set; }
        public decimal height { get; set; }
        public string barcode1 { get; set; }
        public decimal reference_price1 { get; set; }
        public decimal reference_price2 { get; set; }
        public decimal reference_price3 { get; set; }
        public int unit_id { get; set; }
        public string display_unit { get; set; }
        public string image_url { get; set; }
        public int tax_type { get; set; }
        public int sales_type { get; set; }
        public System.DateTime update_date { get; set; }
        public int update_member_id { get; set; }
        public string brand { get; set; }
        public string expiration_date { get; set; }
        public string memo { get; set; }
        public int expiration_days { get; set; }
        public decimal expiration_alert_percent { get; set; }
    }
}
