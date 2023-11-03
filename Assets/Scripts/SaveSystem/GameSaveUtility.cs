
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem
{
    public static class GameSaveUtility
    {
        public static void SaveObject<T>(string key, T data) where T : class , ISave
        {
            string dataAsString = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(key, dataAsString);
            PlayerPrefs.Save();
        }

        public static T LoadObject<T>(string key) where T : class , ISave
        {
            if (!PlayerPrefs.HasKey(key)) 
                throw new Exception($"Can not find save data using key: {key}");
            
            string dataAsString = PlayerPrefs.GetString(key);
            return JsonUtility.FromJson<T>(dataAsString);
        }
        
        public static void SaveObjects<T>(string key, IEnumerable<T> datas) where T : class, ISave
        {
            SerializeArray<T> serializeData = new SerializeArray<T>(datas);

            string dataAsString = JsonUtility.ToJson(serializeData);
            PlayerPrefs.SetString(key, dataAsString);
            PlayerPrefs.Save();
        }

        public static IEnumerable<T> LoadObjects<T>(string key) where T : class, ISave
        {
            if (!PlayerPrefs.HasKey(key))
                throw new Exception($"Can not find save data using key: {key}");
            
            string dataAsString = PlayerPrefs.GetString(key);
            SerializeArray<T> serializeData = JsonUtility.FromJson<SerializeArray<T>>(dataAsString);
                
            return serializeData.SavedData;
        }
    }
}
