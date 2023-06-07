using PROG6221_POE_Part_1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_Part_1
{
    internal class Program
    {
        /// <summary>
        /// Local Worker Class Object
        /// </summary>
        public static WorkerClass worker = new WorkerClass();

        static void Main(string[] args)
        {
            //Calling method to run worker method
            worker.RunWorker();            
        }
    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//