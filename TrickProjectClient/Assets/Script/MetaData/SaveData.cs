using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public string[] currentDay;
    public string[] currentTime;
    public string currentSceneID { get; set; }
    public string currentSceneName { get; set; }
    public int currentScriptIndex { get; set; }
    public List<int> favorotAbility = new List<int>();
    public List<bool> routeTrigger = new List<bool>();
}
