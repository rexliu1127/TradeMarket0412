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
    
    public partial class cart_order
    {
        public int id { get; set; }
        public int department_id { get; set; }
        public string serial { get; set; }
        public string temp_order_id { get; set; }
        public int seller_id { get; set; }
        public string seller_name { get; set; }
        public int buyer_id { get; set; }
        public string buyer_name { get; set; }
        public decimal total { get; set; }
        public decimal tax_rate { get; set; }
        public int tax_add { get; set; }
        public decimal tax_total { get; set; }
        public string memo { get; set; }
        public System.DateTime update_date { get; set; }
        public int order_state_id { get; set; }
        public System.DateTime delivery_date { get; set; }
        public string shipment_type { get; set; }
        public string recipient { get; set; }
        public string shipment_address { get; set; }
        public string shipment_mobile { get; set; }
        public string shipment_tel { get; set; }
        public string shipment_time { get; set; }
        public string shipment_memo { get; set; }
        public string payment_type1 { get; set; }
        public decimal payment_amount1 { get; set; }
        public string payment_type2 { get; set; }
        public decimal payment_amount2 { get; set; }
        public string payment_type3 { get; set; }
        public decimal payment_amount3 { get; set; }
        public string payment_type4 { get; set; }
        public decimal payment_amount4 { get; set; }
        public string invoice_type { get; set; }
        public string invoice_title { get; set; }
        public string invoice_no { get; set; }
    }
}