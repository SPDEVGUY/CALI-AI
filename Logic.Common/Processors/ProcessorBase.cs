using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CALI.Database.Contracts.Data;
using CALI.Logic.Common.Interfaces;

namespace CALI.Logic.Common.Processors
{
    public abstract class ProcessorBase : ICaliQueryProcessor
    {
        /// <summary>
        /// The regex string used to create the tester.
        /// </summary>
        public string RegEx { get; protected set; }
        
        /// <summary>
        /// The Regex tester (Set by processor base on creation)
        /// </summary>
        public Regex Tester { get; protected set; }

        /// <summary>
        /// A list of sample queries used for testing and documentation
        /// </summary>
        public string[] Examples { get; protected set; }

        /// <summary>
        /// Reference to router used for accessing data context
        /// </summary>
        public QueryRouter Router { get; set; }

        /// <summary>
        /// The organization of the processor
        /// </summary>
        public SortOrderEnum SortOrder { get; protected set; }

        public abstract List<BinaryDataContract> Process(string query, MatchCollection matches);

        /// <summary>
        /// Create a processor
        /// </summary>
        /// <param name="regEx">The regex used to test queries</param>
        /// <param name="sortOrder">A sort order used to organize processors.</param>
        /// <param name="example">A list of sample sentences that verify your regex (and provide examples to the user)</param>
        protected ProcessorBase(string regEx, SortOrderEnum sortOrder, params string[] example)
        {
            RegEx = regEx;
            Tester = new Regex(RegEx);
            Examples = example;
            SortOrder = sortOrder;
        }

        
    }
}
