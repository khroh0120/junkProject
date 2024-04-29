using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class ScriptData
{
    public int index;
    public string direction;
    public string assetString;
    public int wait;
    public int beforeText;
    public int nextText;
    public string characterName;
    public string script;
    public int branch1Next;
    public string branch1Text;
    public int branch2Next;
    public string branch2Text;
    public string getEndingTrigger;
    public string getFavorabilityCharacter;
    public int getFavorability;
}

[System.Serializable]
public class Script
{
    public List<ScriptData> scriptData;
}

public class ScriptDatas
{
    public static readonly ScriptDatas instance = new ScriptDatas();

    public ScriptData GetScriptDatas(string _sceneName)
    {
        string path = Path.Combine(Application.dataPath, "Resources/table/" + _sceneName + ".json");
        string jsonData = File.ReadAllText(path);

#if UNITY_EDITOR
        Debug.Log("Get ScriptDatas: " + jsonData);
#endif

        return JsonUtility.FromJson<ScriptData>(jsonData);
    }
}