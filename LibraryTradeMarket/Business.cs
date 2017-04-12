using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;



namespace LibraryTradeMarket
{
    public class Business
    {

        public const string DATETIME_FORMAT_SHORT = "yyyy/MM/dd";
        public const string DATETIME_FORMAT_24H = "yyyy/MM/dd HH:mm:ss";
        public const string DATETIME_FORMAT_24H_MILLISECOND = "yyyy/MM/dd HH:mm:ss.FFFFFFF";
        public const string DATETIME_FORMAT_START_DATE = "yyyy/MM/dd 00:00:00";
        public const string DATETIME_FORMAT_END_DATE = "yyyy/MM/dd 23:59:59";
        public const string DATETIME_FORMAT_24H_NOSYMBOL = "yyyyMMddHHmmss";

        public void addErrorLog(string controller, string action, string contents)
        {
            TradeMarketEntities db = new TradeMarketEntities();
            error_log newErrorLog = new error_log();
            newErrorLog.action = action;            
            newErrorLog.update_date = DateTime.Now;
            newErrorLog.controller = controller;
            newErrorLog.contents = contents;
            db.Entry(newErrorLog).State = EntityState.Added;
            db.SaveChanges();
        }

        public MemberViewModel isLogin(string account, string password)
        {
            MemberViewModel memberViewModel = new MemberViewModel();
            try
            {
                using (var db = new TradeMarketEntities())
                {
                    var members = from m in db.member
                                  where m.account == account && m.password == password
                                  select m;

                    if (members != null)
                    {
                        var member = members
                        .FirstOrDefault();

                        if (member != null)
                        {
                            if (member.account == account && member.password == password)
                            {
                                //ModelState.AddModelError("", "登入成功");
                                //return admin;
                                memberViewModel.Account = member.account;
                                memberViewModel.Name = member.member_name;
                                memberViewModel.Role = member.role;
                            }
                            
                        }
                        
                    }
                    



                }

            }
            catch (Exception ex)
            {
                addErrorLog("", "isLogin", ex.Message);

                //TradeMarketEntities db = new TradeMarketEntities();
                //error_log newErrorLog = new error_log();
                //newErrorLog.action = "isLogin";
                //newErrorLog.contents = "";
                //newErrorLog.update_date = DateTime.Now;
                //newErrorLog.controller = "";
                //newErrorLog.contents = ex.Message;
                //db.Entry(newErrorLog).State = EntityState.Added;
                //db.SaveChanges();                

            }

            return memberViewModel;

        }

        public IntMessage addCart(string tempOrderID,
            string productCustomizeID,string productName,string quantity,string price,
            string unitName
            )
        {
            IntMessage bm = new IntMessage();
            try
            {
                using (var db = new TradeMarketEntities())
                {
                   


                    temp_cart newTempCart = new temp_cart();

                    newTempCart.temp_order_id = tempOrderID;
                    newTempCart.product_customize_id = productCustomizeID;
                    newTempCart.product_name = productName;
                    newTempCart.quantity = Utility.getIntOrDefault(quantity,1);
                    newTempCart.price = Utility.getIntOrDefault(price, 0);
                    newTempCart.unit_name = unitName;
                    newTempCart.update_date = DateTime.Now;
                    //memo備用欄位先設為空

                    newTempCart.memo = "";

                    db.Entry(newTempCart).State = EntityState.Added;

                    db.SaveChanges();


                    var carts = from c in db.temp_cart
                                  where c.temp_order_id == tempOrderID 
                                  select c.temp_order_id;

                    bm.Result = carts.Count();

                }

            }
            catch (Exception ex)
            {
                addErrorLog("", "AddCart", ex.Message);
                bm.Message = ex.Message;
                //TradeMarketEntities db = new TradeMarketEntities();
                //error_log newErrorLog = new error_log();
                //newErrorLog.action = "isLogin";
                //newErrorLog.contents = "";
                //newErrorLog.update_date = DateTime.Now;
                //newErrorLog.controller = "";
                //newErrorLog.contents = ex.Message;
                //db.Entry(newErrorLog).State = EntityState.Added;
                //db.SaveChanges();                

            }

            return bm;

        }

        public List<ProductTypeViewModel> getProductType()
        {
            List<ProductTypeViewModel> list = new List<ProductTypeViewModel>();
            try
            {
                using (var db = new TradeMarketEntities())
                {
                    var product_types = from t in db.product_type
                                        select new ProductTypeViewModel { ProductTypeName = t.product_type_name };



                    if (product_types != null)
                    {
                        list = product_types.ToList();
                        //return product_types.ToList();
                    }
                    //else
                    //{
                    //    return null;
                    //}

                }
            }
            catch (Exception ex)
            {

                addErrorLog("", "isLogin", ex.Message);
            }

            return list;
        }

        public List<ProductViewModel> getProductByType(string productType)
        {
            List<ProductViewModel> list = new List<ProductViewModel>();
            try
            {
                using (var db = new TradeMarketEntities())
                {
                    //from c in Categories
                    //join o in Products on c.CategoryID equals o.CategoryID

                    var products = from p in db.product
                                   join t in db.product_type on p.product_type_id equals t.id
                                   where t.product_type_name == productType
                                   select new ProductViewModel {
                                       ProductCustomizeID =p.product_customize_id,
                                       ProductName = p.product_name,
                                       ProductUnitName = p.display_unit,
                                       ProductTypeName = t.product_type_name
                                   };



                    if (products != null)
                    {
                        list = products.ToList();
                    }
                    else
                    {
                        list = null;
                    }

                }
            }
            catch (Exception ex)
            {

                addErrorLog("", "getProductByType", ex.Message);
            }

            return list;

        }

        public List<ProductViewModel> getProductByKeyword(string keyword)
        {
            List<ProductViewModel> list = new List<ProductViewModel>();
            try
            {
                using (var db = new TradeMarketEntities())
                {
                    //from c in Categories
                    //join o in Products on c.CategoryID equals o.CategoryID

                    var products = from p in db.product
                                   join t in db.product_type on p.product_type_id equals t.id
                                   where t.product_type_name.Contains(keyword) || p.product_name.Contains(keyword) || p.short_product_name.Contains(keyword)
                                   select new ProductViewModel
                                   {
                                       ProductCustomizeID = p.product_customize_id,
                                       ProductName = p.product_name,
                                       ProductUnitName = p.display_unit,
                                       ProductTypeName = t.product_type_name
                                   };



                    if (products != null)
                    {
                        list = products.ToList();
                    }
                    else
                    {
                        list = null;
                    }

                }
            }
            catch (Exception ex)
            {
                addErrorLog("", "getProductByKeyword", ex.Message);

            }

            return list;

        }

        public int getProductCountByType(string productType)
        {
            int count = 0;
            List<ProductViewModel> list = new List<ProductViewModel>();
            try
            {
                using (var db = new TradeMarketEntities())
                {
                    //from c in Categories
                    //join o in Products on c.CategoryID equals o.CategoryID

                    var products = from p in db.product
                                   join t in db.product_type on p.product_type_id equals t.id
                                   where t.product_type_name == productType
                                   select p.product_customize_id;
                                   



                    if (products != null)
                    {
                        count = products.Count();
                    }
                    //else
                    //{
                    //    list = null;
                    //}

                }
            }
            catch (Exception ex)
            {

                addErrorLog("", "getProductByType", ex.Message);
            }

            return count;

        }

        public int getProductCountByKeyword(string keyword)
        {
            int count = 0;
            List<ProductViewModel> list = new List<ProductViewModel>();
            try
            {
                using (var db = new TradeMarketEntities())
                {
                    //from c in Categories
                    //join o in Products on c.CategoryID equals o.CategoryID

                    var products = from p in db.product
                                   join t in db.product_type on p.product_type_id equals t.id
                                   where t.product_type_name.Contains(keyword) || p.product_name.Contains(keyword) || p.short_product_name.Contains(keyword)
                                   select p.product_customize_id
                                   ;





                    if (products != null)
                    {
                        count = products.Count();
                    }

                }
            }
            catch (Exception ex)
            {
                addErrorLog("", "getProductByKeyword", ex.Message);

            }

            return count;

        }

        public List<temp_cart> getTempCart(string tempID)
        {
            List<temp_cart> list = new List<temp_cart>();
            try
            {
                using (var db = new TradeMarketEntities())
                {
                    //from c in Categories
                    //join o in Products on c.CategoryID equals o.CategoryID

                    var carts = from c in db.temp_cart
                                where c.temp_order_id == tempID
                                select c;


                    if (carts != null)
                    {
                        list = carts.ToList();
                    }
                    else
                    {
                        list = null;
                    }

                }
            }
            catch (Exception ex)
            {
                addErrorLog("", "getTempCart", ex.Message);

            }
            return list;
        }

        //get product type

        //get product by type

        //get product by keyword

        //isUpdateOnSales

        //getBuyerOrder

        //getSellerOrder

        //getSellerOrderGroupByDate

        //getSellerOrderByBuyer

        //getSellerOrderGroupByBuyer

        //isCheckOut

        //getOrder

    }
}
