﻿namespace ATM.Interfaces.Configuration
{
    public interface IConfiguration
    {
        int[] AvailablePaperNoteFaceValues { get; }

        decimal WithdrawalFeePercentage { get; }
    }
}
