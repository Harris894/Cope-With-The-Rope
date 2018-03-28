using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FootballUI : MonoBehaviour {

    private Football football;
    public Text[] teamScores;
    public Text resultText;

	// Use this for initialization
	void Start () {
        football = GetComponent<Football>();
	}
	
	// Update is called once per frame
	public void UpdateScores () {
		for(int i = 0; i < football.teamList.Count; i++) {
            Debug.Log(football.teamList[i].score.ToString());
            teamScores[i].text = football.teamList[i].score.ToString();
        }
	}

    public void SetResultMessage(string message) {
        resultText.gameObject.SetActive(true);
        resultText.text = message;
    }
}
