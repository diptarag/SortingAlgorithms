using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingAlgorithms
{
    public class HeapSort : Problem
    {
        #region [Private Variables]
        /// <summary>
        /// Used to define available heap size for the sorting, protects already sorted region
        /// </summary>
        int heapSize = default(int);
        #endregion

        #region [Constructor]
        public HeapSort()
            : base(Global.Problems.HeapSort)
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
                    GeneralHeapSort();
                    StopWatch.Stop();
                    break;
            }
            StoreResult();
            CUI.ShowTimeElapsed(StopWatch.Elapsed);
        }
        #endregion

        #region [Implementations]
        /// <summary>
        /// Performs Heap Sort Operation
        /// </summary>
        private void GeneralHeapSort()
        {
            BuildMaxHeap();
            for (int i = InputArray.Length - 1; i > 0; i--)
            {
                Swap(0, i);
                heapSize--;
                MaxHeapify(0);
            }
        }

        /// <summary>
        /// Build Max Heap for the first time
        /// </summary>
        private void BuildMaxHeap()
        {
            heapSize = InputArray.Length - 1;
            for (int i = (InputArray.Length >> 1) - 1; i >= 0; i--)
                MaxHeapify(i);
        }

        /// <summary>
        /// Procedure to build Max-Heap
        /// </summary>
        /// <param name="rootNode">initial node based on which heap will be built</param>
        private void MaxHeapify(int rootNode)
        {
            int leftNodePos = Left(rootNode + 1) - 1;
            int rightNodePos = Right(rootNode + 1) - 1;
            int largest;

            if (leftNodePos <= heapSize && InputArray[leftNodePos] > InputArray[rootNode])
                largest = leftNodePos;
            else
                largest = rootNode;

            if (rightNodePos <= heapSize && InputArray[rightNodePos] > InputArray[largest])
                largest = rightNodePos;

            if (largest != rootNode)
            {
                Swap(rootNode, largest);
                MaxHeapify(largest);
            }
        }

        /*
         * This method is nothing but calculating the floor of (node/2)
         */
        /// <summary>
        /// Calculate the parent node position of a given node
        /// </summary>
        /// <param name="node">1 based index of the node</param>
        /// <returns>1 based index of the Parent node</returns>
        private int Parent(int node)
        {
            return node >> 1;
        }

        /*
         * This method is nothing but calculating 2 * node
         */
        /// <summary>
        /// Calculate the left node position of a given node
        /// </summary>
        /// <param name="node">1 based index of the node</param>
        /// <returns>1 based index of the Left node</returns>
        private int Left(int node)
        {
            return node << 1;
        }

        /*
         * This method is nothing but calculating 2 * node + 1
         */
        /// <summary>
        /// Calculate the right node position of a given node
        /// </summary>
        /// <param name="node">1 based index of the node</param>
        /// <returns>1 based index of the Right node</returns>
        private int Right(int node)
        {
            return (node << 1) + 1;
        }
        #endregion
    }
}
