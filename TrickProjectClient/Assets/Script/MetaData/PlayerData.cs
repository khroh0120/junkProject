using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class PlayerData
{
    public List<bool> completeEnding = new List<bool>();

    public bool trueEndingTrigger { get; set; }
}

public class PlayerDatas
{

    public static readonly PlayerDatas instance = new PlayerDatas();
    public PlayerData playerData = new PlayerData();

    public void SettingEnding(int _ending, bool _bool)
    {
        playerData.completeEnding[_ending] = _bool;
        SavePlayerData();

#if UNITY_EDITOR
        Debug.Log("SettingEnding:" + (Common.Characters)_ending + playerData.completeEnding[_ending]);
#endif
    }

    public void SettingTrueEndingTrigger(bool _bool)
    {
        playerData.trueEndingTrigger = _bool;
        SavePlayerData();

#if UNITY_EDITOR
        Debug.Log("SettingTrueEndingTrigger:" + playerData.trueEndingTrigger);
#endif
    }

    public void SavePlayerData()
    {
        string path = Path.Combine(Application.dataPath, "Resources/PlayerData/PlayerData.json");
        string json = JsonConvert.SerializeObject(playerData);
        File.WriteAllText(path, json);

#if UNITY_EDITOR
        Debug.Log("SavePlayerData: " + json);
#endif
    }

    public PlayerData LoadPlayerData()
    {
        string path = Path.Combine(Application.dataPath, "Resources/PlayerData/PlayerData.json");
        bool fileExist = File.Exists(path);

        if (true == fileExist)
        {
            string jsonData = File.ReadAllText(path);
            File.WriteAllText(path, jsonData);
            playerData = JsonUtility.FromJson<PlayerData>(jsonData);

#if UNITY_EDITOR
            Debug.Log("PlayerData Load: " + jsonData);
#endif
        }

        else
        {
            playerData = CreditNewPlayerData();

#if UNITY_EDITOR
            Debug.Log("Not Found PlayerData: " + path);
#endif
        }

        return playerData;
    }

    private PlayerData CreditNewPlayerData()
    {
        for (int i = 0; i < (int)Common.Characters.End; ++i)
        {
            playerData.completeEnding.Insert(i, false);
        }

        playerData.trueEndingTrigger = false;
        SavePlayerData();

#if UNITY_EDITOR
        Debug.Log("Credit: new PlayerData");
#endif

        return playerData;
    }
}