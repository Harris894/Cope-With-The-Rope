using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Football : GameMode {

    public static Football instance;

    public List<FootballProfiles> teamList = new List<FootballProfiles>();
    public List<Transform> ballSpawnLocations = new List<Transform>();
    public GameObject ballPrefab;
    public Ball currentBall;

    private FootballUI footballUI;

    private void Awake() {
        if (instance != null) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
    }

    private void Start() {
        OnEnter();
        Debug.Log((Football)instance);
        footballUI = GetComponent<FootballUI>();
        StartNewMatch();
    }

    public override void OnEnter() {
        base.OnEnter();
    }

    public void StartNewMatch() {
        ResetBall();
        footballUI.UpdateScores();
    }

    public void GoalScored(int teamID, int goalValue) {
        foreach(FootballProfiles team in teamList) {
            if(team.teamID == teamID) {
                team.score += goalValue;
                if(team.score <= 0) {
                    MatchOver();
                }
                break;
            }
        }
        footballUI.UpdateScores();
        ResetBall();
    }

    void MatchOver() {
        footballUI.SetResultMessage("Game Over!");
        Invoke("RestartScene", 5f);
    }

    void RestartScene() {
        SceneManager.LoadScene(0);
    }

    public void ResetBall() {
        if (!currentBall) {
            SpawnBall();
            return;
        }

        int random = Random.Range(0, ballSpawnLocations.Count - 1);

        if(ballSpawnLocations.Count > 0) {
            currentBall.transform.position = ballSpawnLocations[random].position;
            if(ballSpawnLocations[random] == null) {
                Debug.LogError(string.Format("Ball location {0} is null.", ballSpawnLocations[random].gameObject.name));
            }
            Rigidbody ballRigidbody = currentBall.GetComponent<Rigidbody>();
            ballRigidbody.velocity = Vector3.zero;
            ballRigidbody.angularVelocity = Vector3.zero;
        }
        
    }

    public void SpawnBall() {
        if(ballPrefab != null) {
            currentBall = Instantiate(ballPrefab).GetComponent<Ball>();
            ResetBall();
        }
    }
}
