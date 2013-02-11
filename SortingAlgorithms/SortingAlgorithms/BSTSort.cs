using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingAlgorithms
{
    public class BSTSort : Problem
    {
        BinarySearchTree BST;
        #region [Constructor]
        public BSTSort()
            : base(Global.Problems.BSTSort)
        {
            ReadInputFile();
            BST = new BinarySearchTree();
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
                    GeneralBSTSort();
                    StopWatch.Stop();
                    break;
            }
            StoreResult();
            CUI.ShowTimeElapsed(StopWatch.Elapsed);
        }
        #endregion

        #region [Implementations]
        /// <summary>
        /// Sorting by building a Binary Search Tree and then traversing the tree in Pre-Order fashion
        /// </summary>
        private void GeneralBSTSort()
        {
            foreach (double value in InputArray)
                BST.Insert(value);

            Array.Clear(InputArray, 0, InputArray.Length);
            List<double> outputList = BST.Traverse();
            Array.Copy(outputList.ToArray(), InputArray, outputList.Count);
        }
        #endregion
    }
}
