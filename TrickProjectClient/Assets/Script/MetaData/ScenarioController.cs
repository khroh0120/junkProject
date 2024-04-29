using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioController : MonoBehaviour
{
    private ScenarioData scenarioData;
    private string currentScenarioID;
    private Script CurrentScriptData;

    private void Start()
    {
        LoadScenarioData();
    }

    private void LoadScenarioData()
    {
        ScenarioDatas.instance.LoadScenarioDatas();
    }

    private string NewGameStart()
    {
        return currentScenarioID;
    }

    private string GetScript(string _ScenarioID)
    {
        return ScriptDatas.instance.GetScriptDatas(_ScenarioID).script;
    }

    private string NextScene()
    {
        currentScenarioID = scenarioData.sceneID;
        return currentScenarioID;
    }
}
