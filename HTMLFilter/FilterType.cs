using System;
using System.Collections.Generic;
using System.Text;

namespace RaagaHacker.Filters
{
    /// <summary>
    /// Each of the type actually corresponds to a HTML filter class derived from 
    /// abstract class <see cref="RaagaHacker.Filters.HTMLFilter"/>. Each has some extra attributes which 
    /// are used to specify their functionalities.
    /// </summary>
    public enum FilterType
    {
        /// <summary>
        /// Filter out a specified <form></form> element from the HTML stream
        /// </summary>
        FormFilter = 1,

        /// <summary>
        /// Filter out a specified script block that may be used as a syndication
        /// </summary>
        ScriptSyndication = 2,

        /// <summary>
        /// Filter out definition and all reference of a specified javascript function
        /// </summary>
        ScriptFunction = 3
    }
}
