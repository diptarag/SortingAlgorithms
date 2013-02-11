using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingAlgorithms
{
    class MergeSort : Problem
    {
        #region [Constructor]
        public MergeSort()
            : base(Global.Problems.Merge)
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
                    GeneralMergeSort(0, InputArray.Length - 1);
                    StopWatch.Stop();
                    break;
            }
            StoreResult();
            CUI.ShowTimeElapsed(StopWatch.Elapsed);
        }
        #endregion

        #region [Implementations]
        /// <summary>
        /// Perform merge operation on a sequence, splitting the section by two within same array
        /// </summary>
        /// <param name="startIndex">Start index of the sequence</param>
        /// <param name="midIndex">Middle index of the sequence</param>
        /// <param name="endIndex">End index of the sequence</param>
        private void Merge(int startIndex, int midIndex, int endIndex)
        {        
            int i,j,k;
            double[] leftArray = new double[midIndex - startIndex + 2];
            double[] rightArray = new double[endIndex - midIndex + 1];

            Array.Copy(InputArray, startIndex, leftArray, 0, leftArray.Length-1);
            Array.Copy(InputArray, midIndex + 1, rightArray, 0, rightArray.Length-1);

            leftArray[leftArray.Length - 1] = Double.PositiveInfinity;
            rightArray[rightArray.Length - 1] = Double.PositiveInfinity;
            
            for (k = startIndex, i = 0, j = 0; k <= endIndex; k++)
            {
                if (leftArray[i] <= rightArray[j])
                    InputArray[k] = leftArray[i++];
                else
                    InputArray[k] = rightArray[j++];
            }                         
        }

        /// <summary>
        /// General Merge Sort Algorithm Implementation
        /// </summary>
        /// <param name="startIndex">Start Index of the Sequence</param>
        /// <param name="endIndex">End Index of the Sequence</param>
        private void GeneralMergeSort(int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int midIndex = (int)Math.Floor((double)((startIndex + endIndex) / 2));
                GeneralMergeSort(startIndex, midIndex);
                GeneralMergeSort(midIndex + 1, endIndex);
                Merge(startIndex, midIndex, endIndex);
            }
        }
        #endregion
    }
}
