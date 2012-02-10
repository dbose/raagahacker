using System;
using System.Collections.Generic;
using System.Text;
using mshtml;


namespace RaagaHacker.Filters
{
    /// <summary>
    /// This interface is for the HTML page filters' abstraction. These filters dynamically modify
    /// a pages content filtering out specified element.
    /// </summary>
    interface IHTMLFilter
    {
        void Filter(ref IHTMLDocument2 inputHtmlDoc);
    }
}
