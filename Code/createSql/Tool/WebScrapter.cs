using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace createSql.Tool
{
    class WebScrapter
    {
        WebBrowser broser  ;
        public WebScrapter(WebBrowser broser) {
            this.broser = broser;
        }

        internal void Scrapt(string url)
        {



            Uri ur = new Uri(url);
            broser.Navigate(ur);
            //throw new NotImplementedException();
        }
    }
}
