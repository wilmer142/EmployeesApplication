﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLogic.Interfaces
{
    public interface IEmployee
    {
        double Salary { set; get; }

        double CalculateAnnualSalary();
    }
}