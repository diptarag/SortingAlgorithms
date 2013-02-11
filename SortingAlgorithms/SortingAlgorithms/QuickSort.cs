using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingAlgorithms
{
    public class QuickSort : Problem
    {        
        #region [Constructor]
        public QuickSort()
            : base(Global.Problems.Quick)
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
                    GeneralQuickSort(0, InputArray.Length - 1);
                    StopWatch.Stop();
                    break;
                case 2: StopWatch.Start();
                    HoareQuickSort(0, InputArray.Length - 1);
                    StopWatch.Stop();
                    break;
            }            
            StoreResult();
            CUI.ShowTimeElapsed(StopWatch.Elapsed);
        }
        #endregion

        #region [Implementations]
        /// <summary>
        /// General Quick Sort Algorithm which uses basic partioning scheme
        /// </summary>
        /// <param name="startIndex">start index of array</param>
        /// <param name="endIndex">last index of array</param>
        private void GeneralQuickSort(int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int q = GeneralPartition(startIndex, endIndex);
                GeneralQuickSort(startIndex, q - 1);
                GeneralQuickSort(q + 1, endIndex);
            }
        }

        /// <summary>
        /// Quick Sort Algorithm using Hoare's partioning scheme
        /// </summary>
        /// <param name="startIndex">start index of array</param>
        /// <param name="endIndex">last index of array</param>
        private void HoareQuickSort(int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int q = HoarePartition(startIndex, endIndex);
                HoareQuickSort(startIndex, q - 1);
                HoareQuickSort(q + 1, endIndex);
            }
        }

        /// <summary>
        /// General Partioning Scheme
        /// </summary>
        /// <param name="startIndex">start index of array to be partioned</param>
        /// <param name="endIndex">last index of array to be partioned</param>
        /// <returns>partition index</returns>
        private int GeneralPartition(int startIndex, int endIndex)
        {
            double pivot = InputArray[endIndex];
            int i = startIndex - 1;            
            for (int j = startIndex; j < endIndex; j++)
            {
                if (InputArray[j] <= pivot)
                {
                    Swap(++i, j);
                }
            }
            Swap(i + 1, endIndex);
            return i + 1;
        }

        /// <summary>
        /// Hoare's Partition Scheme
        /// </summary>
        /// <param name="startIndex">start index of array to be partioned</param>
        /// <param name="endIndex">last index of array to be partioned</param>
        /// <returns>partition index</returns>
        private int HoarePartition(int startIndex, int endIndex)
        {
            double temp = InputArray[startIndex];
            int i = startIndex;
            int j = endIndex;
            while (true)
            {
                while (InputArray[j] > temp)
                {
                    j--;
                }

                while (InputArray[i] < temp)
                {
                    i++;
                }
                
                if (i < j)
                    Swap(i, j);
                else
                    return j;
            }
        }
        #endregion
    }
}
