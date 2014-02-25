using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;



namespace MyFinance.Helpers
{
    public static class DatePickerHelper
    {
        public static string DatePicker(this HtmlHelper htmlHelper, string name, string value)
        {

            return "<script type=\"text/javascript\">" +
                     "$(function() {" +
                     "$(\"#" + name + "\").datepicker();" +
                     "});" +
                     "</script>" +
                     "<input type=\"text\" size=\"10\" value=\"" + value + "\" id=\"" + name + "\" name=\"" + name + "\"/>";

        }

    }
    



    public static class ImageHelper
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string src, string altText, string height)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", altText);
            builder.MergeAttribute("height", height);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}
