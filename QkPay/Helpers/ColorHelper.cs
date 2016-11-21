using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QkPay.Helpers
{
  public static  class ColorHelper
    {
        public static String HexConverter(Color c)
        {
            String rtn = String.Empty;
            try
            {
                rtn = "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
            }
            catch (Exception )
            {
                //doing nothing
            }

            return rtn;
        }
    }
}
