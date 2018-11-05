using System;
using System.Collections.Generic;
using UnityEngine;

namespace GitHubUnityTable.Save
{
    public class Saves
    {
        private readonly Dictionary<Type, string> _saveKeys = new Dictionary<Type, string>
        {
            {typeof(RepositoriesInfoSave), "RepositoriesSave"},
        };

        public RepositoriesInfoSave RepositoriesInfoSave { get; private set; }

        public Saves()
        {
            RepositoriesInfoSave = Load<RepositoriesInfoSave>();
        }

        private TSavePart Load<TSavePart>() where TSavePart : ISavePart, new()
        {
            var key = GetKey<TSavePart>();
            var savedString = PlayerPrefs.GetString(key, string.Empty);
            var obj = String.IsNullOrEmpty(savedString)
                ? new TSavePart()
                : (TSavePart)JsonUtility.FromJson(savedString, typeof(TSavePart));
            obj.OnChanged += Save;
            return obj;
        }

        private void Save(ISavePart savePart)
        {
            var key = GetKey(savePart.GetType());
            var saveString = JsonUtility.ToJson(savePart);
            PlayerPrefs.SetString(key, saveString);
        }

        private string GetKey<T>()
        {
            return GetKey(typeof(T));
        }

        private string GetKey(Type type)
        {
            return _saveKeys[type];
        }
    }
}