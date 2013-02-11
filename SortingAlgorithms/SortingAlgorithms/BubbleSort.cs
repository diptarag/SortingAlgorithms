using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingAlgorithms
{
    public class BubbleSort : Problem
    {
        #region [Constructor]
        public BubbleSort()
            : base(Global.Problems.Bubble)
        {
            ReadInputFile();
        }
        #endregion

        #region [Overridden Methods]
        public override void Sort()
        {
            if (InputArray.Length == 0)
                throw new SortingException("input.txt should not be empty");

            switch (GetVariantID())
            {
                case 1: StopWatch.Start();
                    GeneralBubbleSort();
                    StopWatch.Stop();
                    break;
            }
            StoreResult();
            CUI.ShowTimeElapsed(StopWatch.Elapsed);
        }
        #endregion

        #region [Implementations]
        /// <summary>
        /// Performs bubble sort
        /// </summary>
        private void GeneralBubbleSort()
        {
            for (int i = 0; i < InputArray.Length; i++)
                for (int j = InputArray.Length - 1; j > i; j--)
                    if (InputArray[j] < InputArray[j - 1])
                        Swap(j, j - 1);
        }
        #endregion
    }
}
