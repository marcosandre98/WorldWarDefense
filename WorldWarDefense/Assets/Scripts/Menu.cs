using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour{

    public void jogar(){
        Debug.Log("Entrou no jogo");
        SceneManager.LoadScene("MenuSecundario");
    }

}