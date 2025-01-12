using System.IO;
using UnityEditor;
using UnityEngine;

namespace ModulesGT.Save
{
    public class SaveManager<T> where T : class
    {
        public void Save(T data)
        {
            DataSaver.Save(data);
        }

        public T? Load()
        {
            return DataSaver.Load<T>();
        }
        
        private static void RemoveGameData()
        {
            string filePath = Path.Combine(Application.persistentDataPath, "Data", $"{typeof(T).Name}.json");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

#if UNITY_EDITOR
        
        [MenuItem("Custom Tools/Remove All Data")]
        private static void RemoveAllData()
        {
            RemoveGameData();
            PlayerPrefs.DeleteAll();
        }
#endif
    }
}