using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            Dictionary<Global.Problems, string> problems = new Dictionary<Global.Problems, string>();
            try
            {
                problems = ProblemMetaData.GetProblems();
            }
            catch (SortingException ex)
            {
                CUI.ShowGeneralInformation(ex.Message + "\nPlease revert any changes you have made to the xml file and try again.\n\nSystem will now exit. Press any key to exit...");
                Console.ReadKey();
                System.Environment.Exit(0);
            }

            while (true)
            {
                try
                {
                    switch (CUI.StartScreen())
                    {
                        case "1":
                            while (true)
                            {
                                if (problems.Count >= 0 && int.TryParse(CUI.ShowProblemListings(problems), out choice) && problems.Keys.Any(e => (int)e == choice))
                                {
                                    Problem problem = ProblemFactory((Global.Problems)choice);
                                    if (problem != null)
                                    {
                                        problem.Sort();                                        
                                        break;
                                    }
                                    throw new SortingException("A logical exception occurred.");
                                }
                                CUI.ErrorMessage();
                            }
                            break;
                        case "2": CUI.About();
                            break;
                        case "3": System.Environment.Exit(0);
                            break;
                        default: CUI.ErrorMessage();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    if (ex.HandleFatalError())
                        System.Environment.Exit(1);
                    else
                        ex.Handle();
                }
            }
        }

        /// <summary>
        /// Get the particular Problem object based on the option chosen by user
        /// </summary>
        /// <param name="problem">Problem ID</param>
        /// <returns>Respective problem object</returns>
        static Problem ProblemFactory(Global.Problems problem)
        {
            switch (problem)
            {
                case Global.Problems.Bubble: return new BubbleSort();
                case Global.Problems.Selection: return new SelectionSort();
                case Global.Problems.Insertion: return new InsertionSort();
                case Global.Problems.Quick: return new QuickSort();
                case Global.Problems.Merge: return new MergeSort();
                case Global.Problems.BSTSort: return new BSTSort();
                case Global.Problems.HeapSort: return new HeapSort();
                default: return null;
            }
        }
    }
}
