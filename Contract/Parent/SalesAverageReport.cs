using System;
using System.Collections.Generic;
using System.Text;
using Contract.SalesInfo;
using Contract.SalesUserInput;

namespace Contract.Parent
{
    //Created a parent Model/Contract because MVC can traditionally only bind one model to one view
    public class SalesAverageReport
    {
        public UserInput UserInputs { get; set; }
        public List<SalesAverageData> SalesAverageData { get; set; }

        public SalesAverageReport()
        {
            UserInputs = new UserInput();
            SalesAverageData = new List<SalesAverageData>();
        }
    }
}
