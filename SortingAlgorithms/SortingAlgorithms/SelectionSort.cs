using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingAlgorithms
{
    public class SelectionSort : Problem
    {
        #region [Constructor]
        public SelectionSort()
            : base(Global.Problems.Selection)
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
                    GeneralSelectionSort();
                    StopWatch.Stop();
                    break;
            }
            StoreResult();
            CUI.ShowTimeElapsed(StopWatch.Elapsed);
        }
        #endregion

        #region [Implementations]
        /// <summary>
        /// Performs Selection Sort
        /// </summary>
        private void GeneralSelectionSort()
        {
            for (int j = 0; j < InputArray.Length - 1; j++)
            {
                int min = j;
                for (int i = j + 1; i < InputArray.Length; i++)
                    if (InputArray[i] < InputArray[min])
                        min = i;

                if (min != j)
                    Swap(j, min);
            }
        }
        #endregion
    }
}
