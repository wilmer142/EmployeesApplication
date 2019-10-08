using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLogic.Interfaces
{
    public interface IEmployee
    {
        double CalculateAnnualSalary(double salary);
    }
}