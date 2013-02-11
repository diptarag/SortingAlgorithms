using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    public abstract class Problem
    {
        #region [Member Variable]
        /// <summary>
        /// Metadata about the problem
        /// </summary>
        ProblemMetaData metaData;

        /// <summary>
        /// Problem Name
        /// </summary>
        protected string Name { get; private set; }

        /// <summary>
        /// Description of the Problem
        /// </summary>
        protected string Description { get; private set; }

        /// <summary>
        /// A key value pair for the available implementations of the problem
        /// </summary>
        protected Dictionary<int, string> Variants { get; private set; }

        /// <summary>
        /// Instruction given to user, generally input specification
        /// </summary>
        protected string Instruction { get; private set; }

        /// <summary>
        /// If no implementation is chosen by the user, this is the default implementation to execute
        /// </summary>
        protected int DefaultVariant { get; private set; }

        /// <summary>
        /// ID of the Problem
        /// </summary>
        protected Global.Problems ProblemID { get; private set; }

        /// <summary>
        /// Timer to compute efficiency of program
        /// </summary>
        protected Stopwatch StopWatch { get; private set; }

        /// <summary>
        /// The input array to be sorted
        /// </summary>
        protected double[] InputArray { get; set; }
        #endregion

        #region [Constructor]
        /// <summary>
        /// Constructor for the Problem class, initializes all data regarding one Particular problem
        /// </summary>
        /// <param name="problemID">ID of the Problem</param>
        protected Problem(Global.Problems problemID)
        {
            ProblemID = problemID;
            metaData = new ProblemMetaData(problemID);
            Name = metaData.GetName();
            Description = metaData.GetDescription();
            Variants = metaData.GetVariants();
            Instruction = metaData.GetInstruction();
            DefaultVariant = metaData.GetDefaultVariant();
            StopWatch = new Stopwatch();
        }
        #endregion

        #region [Virtual Methods]
        /// <summary>
        /// Get The Variant ID of the available implementations from user
        /// </summary>
        /// <returns>Index of the Variant chosen by user</returns>
        public virtual int GetVariantID()
        {
            string returnVal;
            int retVal;
            while (true)
            {
                returnVal = CUI.ShowImplementations(Name, Variants);
                if (string.IsNullOrEmpty(returnVal))
                    return DefaultVariant;
                else
                {
                    if (int.TryParse(returnVal, out retVal))
                    {
                        if (retVal <= Variants.Count)
                            return retVal;
                    }
                    else
                        CUI.ErrorMessage();
                }
            }
        }

        /// <summary>
        /// Store the result of the execution
        /// </summary>
        /// <param name="output">Result to be stored</param>
        public virtual void StoreResult(params object[] output)
        {
            using (FileHandler outputFile = new FileHandler(Global.IOMode.Output))
            {
                foreach (object obj in output)
                    outputFile.WriteContent(obj);
            }
            CUI.ShowGeneralInformation("\n\nPlease open output.txt to view the result.");
        }

        /// <summary>
        /// Store the result of execution
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="output">Collection to be stored</param>
        public virtual void StoreResult<T>(List<T> output)
        {
            using (FileHandler outputFile = new FileHandler(Global.IOMode.Output))
            {
                foreach (object obj in output)
                    outputFile.WriteContent(obj);
            }
            CUI.ShowGeneralInformation("\n\nPlease open output.txt to view the result.");
        }

        /// <summary>
        /// Stores the sorted array in output.txt
        /// </summary>
        public virtual void StoreResult()
        {
            using (FileHandler outputFile = new FileHandler(Global.IOMode.Output))
            {
                foreach (int obj in InputArray)
                    outputFile.Write(obj, true);
            }
            CUI.ShowGeneralInformation("\n\nPlease open output.txt to view the result.");
        }

        /// <summary>
        /// Read and parse input file
        /// </summary>
        public virtual void ReadInputFile()
        {
            using (FileHandler inputFile = new FileHandler(Global.IOMode.Input, true))
            {
                try
                {
                    InputArray = inputFile.FetchLine(1).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x.Trim())).ToArray();
                }
                catch
                {
                    throw new SortingException("input.txt should contain a series of numbers separated by ','");
                }
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Swap two positions in input array
        /// </summary>
        /// <param name="position1">Zero based index of Postion 1</param>
        /// <param name="position2">Zero based index of Postion 2</param>
        public void Swap(int position1, int position2)
        {
            double temp = InputArray[position1];
            InputArray[position1] = InputArray[position2];
            InputArray[position2] = temp;
        }
        #endregion

        #region [Abstract signature]
        /// <summary>
        /// Solve the problem
        /// </summary>
        public abstract void Sort();
        #endregion

        
    }
}
