using ATM.Interfaces.Application.Utility;
using System;
using System.Diagnostics.CodeAnalysis;

namespace ATM.Application.Utility
{
    [ExcludeFromCodeCoverage]
    public class DateTimeFacade : IDateTimeFacade
    {
        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
