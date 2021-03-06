﻿using System;
using System.IO;

namespace SortingAlgorithms
{
    public class FileHandler : IDisposable
    {
        /// <summary>
        /// Path of the input file from where user input will be collected
        /// </summary>
        readonly string inputFilePath = "input.txt";

        /// <summary>
        /// Path of the output file where program output will be stored
        /// </summary>
        readonly string outputFilePath = "output.txt";

        /// <summary>
        /// Indicates whether entire content of the file to be stored at the time of object creation, subsequent fetching will be done from the saved string resulting lesser IO operations
        /// but for larger file and when fetch line number is within first few lines, this method may lead to inefficiency
        /// </summary>
        bool saveEntireContent;

        /// <summary>
        /// To detect redundant call to dispose
        /// </summary>
        bool disposed;

        /// <summary>
        /// buffer to save entire content of the file if saveEntireContent scheme is enabled 
        /// </summary>
        string[] entireContent;

        /// <summary>
        /// File reader object
        /// </summary>
        StreamReader reader;

        /// <summary>
        /// File writer object
        /// </summary>
        StreamWriter writer;

        /// <summary>
        /// FileHandler Constructor
        /// </summary>
        /// <param name="ioMode">Specify the IO Mode of the operation</param>
        /// <param name="saveEntireContent">true to cache entire content of the file, dont mention anything for Output file mode</param>
        public FileHandler(Global.IOMode ioMode, bool saveEntireContent = false)
        {
            this.saveEntireContent = saveEntireContent;

            if (ioMode == Global.IOMode.Input)
            {
                if (saveEntireContent)
                    entireContent = File.ReadAllText(inputFilePath).Split('\n');
                else
                    reader = new StreamReader(inputFilePath);
            }
            else
                writer = new StreamWriter(outputFilePath);
        }

        /// <summary>
        /// Fetches a specific line from the input file
        /// </summary>
        /// <param name="lineNumber">Line Number to fetch, starts from 1</param>
        /// <returns>content of the specific line number</returns>
        public string FetchLine(int lineNumber)
        {
            if (saveEntireContent)
                return entireContent[lineNumber - 1];
            else
            {
                if (reader == null)
                    reader = new StreamReader(inputFilePath);
                for (int i = 1; i < lineNumber; i++)
                    reader.ReadLine();
                return reader.ReadLine();
            }
        }

        /// <summary>
        /// Fetches entire content of the input file
        /// </summary>
        /// <returns>Content of the input file</returns>
        public string FetchEntireContent()
        {
            return File.ReadAllText(inputFilePath);
        }

        /// <summary>
        /// Write into ouput file
        /// </summary>
        /// <param name="content">Content to write</param>
        public void WriteContent(object content)
        {
            writer.WriteLine(content);
        }

        public void Write(object content, bool isCommaAppend)
        {
            writer.Write(content);
            if (isCommaAppend)
                writer.Write(", ");
        }

        #region [Dispose methods]
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (reader != null)
                        reader.Dispose();
                    if (writer != null)
                        writer.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
