#nullable enable
using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace ModulesGT.Save
{
    public static class DataSaver
    {
        private static readonly string BasePath = Path.Combine(Application.persistentDataPath, "Data");

        public static T? Load<T>(Action<T?>? onLoad = null) where T : class
        {
            string filePath = Path.Combine(BasePath, $"{typeof(T).Name}.json");

            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(BasePath);
                return null;
            }

            T? data = JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
            onLoad?.Invoke(data);
            return data;
        }

        public static void Save<T>(T data, Action? onSave = null) where T : class
        {
            Directory.CreateDirectory(BasePath);
            string filePath = Path.Combine(BasePath, $"{typeof(T).Name}.json");
            File.WriteAllText(filePath, JsonConvert.SerializeObject(data));
            onSave?.Invoke();
        }
    }

    public static class PrefsManager
    {
        public static void SetInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        public static int GetInt(string key)
        {
            return PlayerPrefs.GetInt(key, 0);
        }
    }
}