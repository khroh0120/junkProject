using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[System.Serializable]
public class Scenario
{
    public List<ScenarioData> scenario;
}

[System.Serializable]
public class ScenarioData
{
    public int index;
    public string sceneID;
    public string sceneName;
    public string beforeScene;
    public string[] nextScene;
    public string requireCharacterFavorAbility;
    public int requireFavorabilityNumber;
    public string requireTrigger;
}

public class ScenarioDatas
{
    public static readonly ScenarioDatas instance = new ScenarioDatas();
    private Scenario scenarioDatas = new Scenario();
    private ScenarioData scenarioData = new ScenarioData();

    public ScenarioData LoadScenarioDatas()
    {
        string path = Path.Combine(Application.dataPath, "Resources/table/Scenario.json");
        string jsonData = File.ReadAllText(path);

//#if UNITY_EDITOR
//        Debug.Log("Load ScenarioDatas: " + jsonData);
//#endif

        scenarioData = JsonUtility.FromJson<ScenarioData>(jsonData);

        return scenarioData;
    }

    public ScenarioData GetScenarioData (string _scriptName)
    {
        ScenarioData _scriptData = new ScenarioData();
        //int _count = scenarioData.count;

        //for (int i = 0; i < _count; ++i)
        //{
        //    if (_scriptName == scenarioData.scenario[i].sceneID)
        //    {
        //        _scriptData = scenarioData.scenario[i];
        //    }
        //}

        return _scriptData;
    }
}