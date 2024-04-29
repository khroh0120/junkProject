using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System;

public class GameDataManager:MonoBehaviour
{
    public static GameDataManager instance;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public PlayerData playerData = new PlayerData();
    static public List<SaveData> gameDatas = new List<SaveData>();

    public PlayerData NewPlayerData()
    { 
        playerData.trueEndingTrigger = false;

        for (int i = 0; i < (int)Common.Characters.End; ++i)
        {
            playerData.completeEnding[i] = false;
        }

        string json = JsonConvert.SerializeObject(playerData);
        File.WriteAllText("./SaveData/PlayerData.json", json);

        return playerData;
    }
    
    static public void SavePlayerData(PlayerData _playerData)
    {
        string json = JsonConvert.SerializeObject(_playerData);
        File.WriteAllText("./SaveData/PlayerData.json", json);
    }

    static public PlayerData LoadPlayerData()
    {
        string json = File.ReadAllText("./SaveData/PlayerData.json");
        PlayerData playerData = JsonConvert.DeserializeObject<PlayerData>(json);

        return playerData;
    }

    static public void SaveGameData(int _index, SaveData _gameData)
    {
        gameDatas[_index].currentDay[(int)Common.Day.Year] = DateTime.Now.ToString("yyyy");
        gameDatas[_index].currentDay[(int)Common.Day.Month] = DateTime.Now.ToString("M");
        gameDatas[_index].currentDay[(int)Common.Day.Day] = DateTime.Now.ToString("dd");
        gameDatas[_index].currentDay[(int)Common.Time.Hour] = DateTime.Now.ToString("H");
        gameDatas[_index].currentDay[(int)Common.Time.Minute] = DateTime.Now.ToString("mm");
        gameDatas[_index].currentDay[(int)Common.Time.Second] = DateTime.Now.ToString("ss");
        gameDatas[_index].currentSceneID = _gameData.currentSceneID;
        gameDatas[_index].currentSceneName = _gameData.currentSceneName;
        gameDatas[_index].currentScriptIndex = _gameData.currentScriptIndex;
        gameDatas[_index].favorotAbility = _gameData.favorotAbility;
        gameDatas[_index].routeTrigger = _gameData.routeTrigger;

        string json = JsonConvert.SerializeObject(gameDatas);
        File.WriteAllText("./SaveData/GameData.json", json);
    }

    public void SaveGameDatas()
    {
        string path = Path.Combine(Application.dataPath, "Resources/GameData/GameData.json");
        string json = JsonConvert.SerializeObject(gameDatas);
        File.WriteAllText(path, json);
#if UNITY_EDITOR
        Debug.Log("SaveGameData: " + json);
#endif
    }
}