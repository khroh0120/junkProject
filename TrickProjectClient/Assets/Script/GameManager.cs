using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    PlayerData playerData;
    
    private void Awake()
    {
        if (null==instance)
        instance = this;
                else
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        LoadPlayerData();
    }

    private void LoadPlayerData()
    {
        playerData = PlayerDatas.instance.LoadPlayerData();
    }
}
