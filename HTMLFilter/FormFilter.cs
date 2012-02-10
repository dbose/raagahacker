using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using mshtml;

namespace RaagaHacker.Filters
{
    class FormFilter : IHTMLFilter
    {
        string formName = "searchForm";
        public string FormName
        {
            get { return formName; }
            set { formName = value; }
        }

        public void Filter(ref IHTMLDocument2 inputHtmlDoc)
        {
            try
            {
                //Modify input HTML document iff formName is valid
                if ((formName != null) && (formName.Trim().Length != 0))
                {
                    //Hide the form
                    inputHtmlDoc.parentWindow.execScript("document." + formName + ".style.visibility = 'hidden'", "JavaScript");
                    
                }
            }
            catch
            {

            }
            finally
            {

            }
        }
    }
}
