using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingAlgorithms
{
    public class Global
    {
        /// <summary>
        /// List of problems
        /// </summary>
        public enum Problems
        {
            None,
            Bubble,
            Selection,
            Insertion,
            Quick,
            Merge,
            BSTSort, 
            HeapSort
        }

        /// <summary>
        /// Possible IO Mode for File Operations
        /// </summary>
        public enum IOMode
        {
            Input,
            Output
        }
    }
}
