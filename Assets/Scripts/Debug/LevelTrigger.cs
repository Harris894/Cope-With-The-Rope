using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelTrigger : MonoBehaviour {

    public string sceneName;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        SceneManager.LoadScene(sceneName);
    }

    [ContextMenu("Invoke trigger")]
    public void Invoke()
    {
        SceneManager.LoadScene(sceneName);
    }
}
