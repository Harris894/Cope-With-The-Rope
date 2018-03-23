using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MySceneManager : MonoBehaviour {
    public LevelDatas levelDatas;
    public static MySceneManager instance;
    public SceneManager sceneManager;

	void Start () {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
	}
}
