using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Color TeamColor;
    private static string SaveFileName = "savefile.json";
    private string pathSave;
    private void Awake()
    {
        pathSave = Application.persistentDataPath + "/" + SaveFileName;
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    [Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(pathSave, json);
    }

    public void LoadColor()
    {
        if (File.Exists(pathSave))
        {
            string json =  File.ReadAllText(pathSave);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            TeamColor = data.TeamColor;
        }
    }
}
