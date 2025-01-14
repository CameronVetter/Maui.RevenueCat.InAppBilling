﻿namespace Maui.RevenueCat.InAppBilling.Platforms.Android.Extensions;

internal static class LogLevelExtensions
{
    internal static Com.Revenuecat.Purchases.LogLevel ToRCLogLevel(this LogLevel logLevel)
    {
        return logLevel switch
        {
            LogLevel.Verbose => Com.Revenuecat.Purchases.LogLevel.Verbose,
            LogLevel.Debug => Com.Revenuecat.Purchases.LogLevel.Debug,
            LogLevel.Information => Com.Revenuecat.Purchases.LogLevel.Info,
            LogLevel.Warning => Com.Revenuecat.Purchases.LogLevel.Warn,
            LogLevel.Error => Com.Revenuecat.Purchases.LogLevel.Error,
            _ => throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null)
        };
    }
}
