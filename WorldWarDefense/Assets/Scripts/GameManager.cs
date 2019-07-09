using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    
    private bool gameEnd = false;
    public GameObject gameOverUI;

    void Update(){
        if(gameEnd){
            return;
        }

        if(PlayerStats.Lives <= 0){
            EndGame();
        }
    }

    void EndGame(){
        gameEnd = true;
        Debug.Log("Fim de jogo");
        gameOverUI.SetActive(true);
    }
}
