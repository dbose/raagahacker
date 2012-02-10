using System;
using System.Collections.Generic;
using System.Text;
using mshtml;

namespace RaagaHacker.Filters
{
    class JScriptFilter : IHTMLFilter   
    {
        string scriptNameByUrl = "http://www.indiaglitz.com";
        

        public void Filter(ref IHTMLDocument2 inputHtmlDoc)
        {
            try
            {
                //Modify input HTML document iff formName is valid
                if ((scriptNameByUrl != null) && (scriptNameByUrl.Trim().Length != 0))
                {
                    string JScript = "var scriptElement = null;                                         " +
                                     "var allScripts = document.scripts;                                " +
                                     "for(var index = 0; index < allScripts.length; index++)            " +
                                     "{                                                                 " +
                                     "    scriptElement = allScripts[index];                            " +
                                     "    if (scriptElement.src.toString().indexOf('" + scriptNameByUrl + "') >=0)   " +
                                     "    {                                                             " +
                                     "        alert(scriptElement.parentNode);      " +
                                     "    }                                                             " +
                                     "}                                                                 ";                       
                                     
                     

                    
                    //Hide the form
                    inputHtmlDoc.parentWindow.execScript(JScript, "JavaScript");
                    
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
