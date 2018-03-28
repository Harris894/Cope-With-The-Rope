using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Data", menuName = "Data/Level Data")]
public class LevelDatas : ScriptableObject {

    [System.Serializable]
    public class Level
    {
        public string name;
        public string sceneName;
        public Sprite thumb;
    }


    public List<Level> levelList = new List<Level>();
}
