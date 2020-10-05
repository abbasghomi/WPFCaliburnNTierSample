using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCaliburnNTierSample.PresentationLayer.Models
{
    /// <summary>
    /// Used for list of US states in edit view
    /// </summary>
    public class USState
    {
        public USState(string stateAbbreviation, string stateFullName)
        {
            this.StateAbbreviation = stateAbbreviation;
            this.StateFullName = stateFullName;
        }

        public string StateAbbreviation { get; set; }
        public string StateFullName { get; set; }
    }
}
