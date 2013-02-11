using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingAlgorithms
{
    public class InsertionSort : Problem
    {
        #region [Constructor]
        public InsertionSort()
            : base(Global.Problems.Insertion)
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
                    GeneralInsertionSort();
                    StopWatch.Stop();
                    break;
            }
            StoreResult();
            CUI.ShowTimeElapsed(StopWatch.Elapsed);
        }
        #endregion

        #region [Implementations]
        /// <summary>
        /// Performs Insertion Sort
        /// </summary>
        private void GeneralInsertionSort()
        {
            double key;
            int i;
            for (int j = 1; j < InputArray.Length; j++)
            {
                key = InputArray[j];
                i = j - 1;
                while (i >= 0 && InputArray[i] > key)
                {
                    InputArray[i + 1] = InputArray[i];
                    i--;
                }
                InputArray[i + 1] = key;
            }
        }
        #endregion
    }
}
