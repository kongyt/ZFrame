using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace ZFrame {
    public class LocalStorage {

        public static int GetInt(string name, int defaultValue = 0) {
            return PlayerPrefs.GetInt(name, defaultValue);
        }

        public static void SetInt(string name, int value) {
            PlayerPrefs.SetInt(name, value);
        }


        public static string GetString(string name, string defaultValue = "") {
            return PlayerPrefs.GetString(name, defaultValue);
        }

        public static void SetString(string name, string value) {
            PlayerPrefs.SetString(name, value);
        }


        public static float GetFloat(string name, float defaultValue = 0) {
            return PlayerPrefs.GetFloat(name, defaultValue);
        }

        public static void SetFloat(string name, float value) {
            PlayerPrefs.SetFloat(name, value);
        }


        public static bool GetBool(string name, bool defaultValue = false) {
            return PlayerPrefs.GetInt(name, defaultValue ? 1 : 0) == 1;
        }

        public static void SetBool(string name, bool value) {
            PlayerPrefs.SetInt(name, value ? 1 : 0);
        }


        public static long GetLong(string name, long defaultValue = 0) {
            return Convert.ToInt64(PlayerPrefs.GetString(name, Convert.ToString(defaultValue)));
        }

        public static void SetLong(string name, long value) {
            PlayerPrefs.SetString(name, Convert.ToString(value));
        }
    }

}
