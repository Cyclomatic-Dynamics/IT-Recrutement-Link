using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT_Recrutement_Link.Web.Controllers
{
    public class bindingcountroes : System.Web.UI.Page
    {
        protected void page_Load(object sender, EventArgs e)
        {
            DropDownList list = new DropDownList();
            list.DataSource = Getcountryinfo();
            list.DataBind();
            list.Items.Insert(0, "--------Select--------");
        }

        public List<string> Getcountryinfo()
        {
         List<string> list = new List<string>();
        foreach (CultureInfo info in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
        {
            RegionInfo inforeg = new RegionInfo(info.LCID);
            if (!list.Contains(inforeg.EnglishName))
            {
                list.Add(inforeg.EnglishName);
                list.Sort();
            }
        }
        return list;
       }
    }
}