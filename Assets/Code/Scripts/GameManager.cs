using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState{
    inGame, winGame, gameOver
}

public class GameManager : MonoBehaviour{
    
    public static GameManager instance;

    [Header("References")]
    public GameState state;
    public GameObject inGameUI;
    public GameObject gameOverUI;

    private void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }

    private void Start(){

        state = GameState.inGame;
    }

    private void Update(){

        switch (state){
            case GameState.inGame:
                inGameUI.SetActive(true);
                gameOverUI.SetActive(false);
                break;
            case GameState.winGame:
                inGameUI.SetActive(false);
                gameOverUI.SetActive(false);
                break;
            case GameState.gameOver:
                inGameUI.SetActive(false);
                gameOverUI.SetActive(true);
                break;
            default:
                break;
        }
    }

    // Scene controller
    public void GoToScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void ResetScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToNextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}