﻿using System;
using System.Globalization;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Login.Config
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string GeneralSettings
        {
            get => AppSettings.GetValueOrDefault(nameof(GeneralSettings), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(GeneralSettings), value);
        }

        #region General settings

       
        
        
        #endregion

        #region Authentication
        public static int PinErrorCount
        {
            get => int.Parse(AppSettings.GetValueOrDefault(nameof(PinErrorCount), "0"));

            set => AppSettings.AddOrUpdateValue(nameof(PinErrorCount), value.ToString());
        }

        public static DateTime? PinWasEntered
        {
            get => DateTime.Parse(AppSettings.GetValueOrDefault(nameof(PinWasEntered), null));

            set => AppSettings.AddOrUpdateValue(nameof(PinWasEntered), value.ToString());
        }
        public static bool UseScreenLockPin
        {
            get => bool.Parse(AppSettings.GetValueOrDefault(nameof(UseScreenLockPin), bool.TrueString));

            set => AppSettings.AddOrUpdateValue(nameof(UseScreenLockPin), value.ToString());
        }
        public static string ScreenLockPin
        {
            get => AppSettings.GetValueOrDefault(nameof(ScreenLockPin), "1234");

            set => AppSettings.AddOrUpdateValue(nameof(ScreenLockPin), value);
        }
        /// <summary>
        /// Provider name, like Facebook, Google, AzureB2C
        /// </summary>
        public static string LoginWithProvider
        {
            get => AppSettings.GetValueOrDefault(nameof(LoginWithProvider), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(LoginWithProvider), value);
        }

        
        #endregion


      

        #region Application settings


       


       

        // Settings Page
        public static bool ApplicationUsePin
        {
            get => AppSettings.GetValueOrDefault(nameof(ApplicationUsePin), false);
            set => AppSettings.AddOrUpdateValue(nameof(ApplicationUsePin), value);
        }

        public static string ApplicationPin
        {
            get => AppSettings.GetValueOrDefault(nameof(ApplicationPin), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(ApplicationPin), value);
        }

        


        #endregion

       

        #region User data settings
        public static string UserPrefix
        {
            get => AppSettings.GetValueOrDefault(nameof(UserPrefix), "Mr");
            set => AppSettings.AddOrUpdateValue(nameof(UserPrefix), value);
        }

        public static string UserFirstName
        {
            get => AppSettings.GetValueOrDefault(nameof(UserFirstName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserFirstName), value);
        }

        public static string UserSecondName
        {
            get => AppSettings.GetValueOrDefault(nameof(UserSecondName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserSecondName), value);
        }

        public static string UserEmail
        {
            get => AppSettings.GetValueOrDefault(nameof(UserEmail), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserEmail), value);
        }

        public static string UserPhone
        {
            get => AppSettings.GetValueOrDefault(nameof(UserPhone), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserPhone), value);
        }

        
        public static string UserCity
        {
            get => AppSettings.GetValueOrDefault(nameof(UserCity), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserCity), value);
        }

        public static string UserLanguage
        {
            get => AppSettings.GetValueOrDefault(nameof(UserLanguage), "Arabic");
            set => AppSettings.AddOrUpdateValue(nameof(UserLanguage), value);
        }

        #endregion

        #region Financial settings

        public static string FinancialCurrency
        {
            get => AppSettings.GetValueOrDefault(nameof(FinancialCurrency), "AED");
            set => AppSettings.AddOrUpdateValue(nameof(FinancialCurrency), value);
        }

        public static int FinancialPeriodStartDay
        {
            get => AppSettings.GetValueOrDefault(nameof(FinancialPeriodStartDay), 1);
            set => AppSettings.AddOrUpdateValue(nameof(FinancialPeriodStartDay), value);
        }

        public static decimal FinancialAverageWeekIncome
        {
            get => AppSettings.GetValueOrDefault(nameof(FinancialAverageWeekIncome), 0m);
            set => AppSettings.AddOrUpdateValue(nameof(FinancialAverageWeekIncome), value);
        }

        public static decimal FinancialAverageMonthIncome
        {
            get => AppSettings.GetValueOrDefault(nameof(FinancialAverageMonthIncome), 0m);
            set => AppSettings.AddOrUpdateValue(nameof(FinancialAverageMonthIncome), value);
        }

        public static bool FinancialIsWeekIncome
        {
            get => AppSettings.GetValueOrDefault(nameof(FinancialIsWeekIncome), false);
            set => AppSettings.AddOrUpdateValue(nameof(FinancialIsWeekIncome), value);
        }

        public static bool FinancialIsMonthIncome
        {
            get => AppSettings.GetValueOrDefault(nameof(FinancialIsMonthIncome), true);
            set => AppSettings.AddOrUpdateValue(nameof(FinancialIsMonthIncome), value);
        }

        #endregion

        #region Advanced (Tolerance) settings

        public static int TolerancePredefinedPaymentPercent
        {
            get => AppSettings.GetValueOrDefault(nameof(TolerancePredefinedPaymentPercent), 0);
            set => AppSettings.AddOrUpdateValue(nameof(TolerancePredefinedPaymentPercent), value);
        }

        public static int ToleranceIncomePerMonthPercent
        {
            get => AppSettings.GetValueOrDefault(nameof(ToleranceIncomePerMonthPercent), 0);
            set => AppSettings.AddOrUpdateValue(nameof(ToleranceIncomePerMonthPercent), value);
        }

        public static int TolerancePaymentDays
        {
            get => AppSettings.GetValueOrDefault(nameof(TolerancePaymentDays), 5);
            set => AppSettings.AddOrUpdateValue(nameof(TolerancePaymentDays), value);
        }

        public static int ToleranceIntervalDays
        {
            get => AppSettings.GetValueOrDefault(nameof(ToleranceIntervalDays), 5);
            set => AppSettings.AddOrUpdateValue(nameof(ToleranceIntervalDays), value);
        }

        #endregion

    }
}