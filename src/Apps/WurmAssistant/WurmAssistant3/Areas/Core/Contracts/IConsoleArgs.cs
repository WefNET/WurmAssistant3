﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AldursLab.WurmAssistant3.Areas.Core.Contracts
{
    public interface IConsoleArgs
    {
        bool WurmUnlimitedMode { get; }
        bool UseRelativeDataDir { get; }
    }
}
