using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logokuma24062025.logokurestosepetclass;

namespace Logokuma24062025
{
    internal class logrestosepet_getir
    {

        public class getirlog
        {
            public string id { get; set; }
            public string confirmationId { get; set; }
            public int status { get; set; }
            public client client { get; set; }
            public courier courier { get; set; }
            public List<product> products { get; set; } //Bu property bir product türünden nesnelerden oluşan liste tutar Property’nin adı. JSON’dan gelen “products” alanına karşılık gelir

        }
        public class product
        {
            public name name { get; set; }

            public List<optionCategories> optionCategories { get; set; }

        }
        public class optionCategories
        {
            public List<options> options { get; set; }
        }
 
        public class options
        {
            public string name { get; set; }
            public double price { get; set; }
        }



        public class client
        {
            public string id { get; set; }
            public string name { get; set; }
            public List<location> location { get; set; }
            public deliveryAddress deliveryAddress { get; set; }
        }

        public class location
        {
            public string clientPhoneNumber { get; set; }
        }
        public class deliveryAddress
        {
            
            public string address { get; set; }
            public string aptNo { get; set; }
            public string floor { get; set; }
            public string doorNo { get; set; }
            public string district { get; set; }
            public string city { get; set; }
          
        }
        public class courier
        {           
            public string name { get; set; }
           
        }

       

       
   

        public class name
        {
            public string productName { get; set; }
            public int quantity { get; set; }
            public double price { get; set; }
        }




    }
}
