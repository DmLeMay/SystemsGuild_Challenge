using System;
using System.Collections.Generic;
using System.Text;

namespace Contract.SalesUserInput
{
    public class UserInput
    {
        public string Zipcode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public UserInput()
        {
            //Seting the date range to be current date by default
            StartDate = DateTime.Now.Date;
            EndDate = DateTime.Now.Date;
        }



    }
}
