using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelectPanel : Panel {

    public Dropdown levelSelectDropdown;
    List<LevelDatas.Level> levelDataList = new List<LevelDatas.Level>();
    private void Start()
    {
        levelSelectDropdown.ClearOptions();
        List<string> levelList = new List<string>();
        foreach (LevelDatas.Level level in MySceneManager.instance.levelDatas.levelList)
        {
            levelList.Add(level.name);
            levelDataList.Add(level);
        }
        levelSelectDropdown.AddOptions(levelList);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(levelDataList[levelSelectDropdown.value].sceneName);
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
