using System;
using System.Collections.Generic;
using System.Text;
using mshtml;

namespace RaagaHacker.Filters
{
    /// <summary>
    /// This class creates different filters dynamically.
    /// </summary>
    class FilterFactory
    {
        /// <summary>
        /// Spwans filters depending on the type specified. This is what I call "pseudo-factory" pattern
        /// </summary>
        /// <param name="filterType">Type of the filter to be created</param>
        /// <returns></returns>
        public static IHTMLFilter CreateFilter(FilterType filterType)
        {
            IHTMLFilter filter = null;

            switch (filterType)
            {
                case FilterType.FormFilter:
                    filter = new FormFilter();
                    break;
                case FilterType.ScriptSyndication:
                    filter = new JScriptFilter();
                    break;
            }

            return filter;
        }

        /// <summary>
        /// Aggregates the filter applying process
        /// </summary>
        /// <param name="doc"></param>
        public static void ApplyFilter(ref IHTMLDocument2 doc)
        {
            //Create the specific content-filters
            IHTMLFilter[] filters = new IHTMLFilter[]{ 
                FilterFactory.CreateFilter(FilterType.FormFilter),
                FilterFactory.CreateFilter(FilterType.ScriptSyndication) };

            foreach (IHTMLFilter filter in filters)
            {
                filter.Filter(ref doc);
            }
        }
    }
}
