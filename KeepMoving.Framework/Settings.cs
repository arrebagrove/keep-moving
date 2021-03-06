﻿using Windows.Storage;
using System.Collections.Generic;

namespace KeepMoving.Framework
{
    public class Settings
    {
        private const string DeviceSettingsContainerName = "DeviceSettings";
        private const string TimeoutPeriodSettingName = "TimeoutPeriod";
        private const string TrackingEnabledSettingName = "TrackingEnabled";

        public static void SetTrackingEnabled(bool enabled)
        {
            SetSetting(TrackingEnabledSettingName, enabled);
        }

        public static bool GetTrackingEnabled()
        {
            return GetSetting(TrackingEnabledSettingName, true);
        }

        public static void SetTimeoutPeriod(int newValue)
        {
            SetSetting(TimeoutPeriodSettingName, newValue);
        }

        public static int GetTimeoutPeriod()
        {
            var value = GetSetting<int>(TimeoutPeriodSettingName);
            return value == default(int) ? 15 : value;
        }

        private static T GetSetting<T>(string settingName)
        {
            return GetSetting<T>(settingName, default(T));
        }

        private static T GetSetting<T>(string settingName, T defaultValue)
        {
            var settingsContainer = ApplicationData.Current.LocalSettings.CreateContainer(DeviceSettingsContainerName,
                ApplicationDataCreateDisposition.Always);

            var settingObj = settingsContainer.Values[settingName];

            if (settingObj == null)
            {
                return defaultValue;
            }

            return (T)settingObj;
        }

        private static void SetSetting(string settingName, object value)
        {
            var settingsContainer = ApplicationData.Current.LocalSettings.CreateContainer(DeviceSettingsContainerName,
    ApplicationDataCreateDisposition.Always);

            settingsContainer.Values[settingName] = value;

        }
    }
}
