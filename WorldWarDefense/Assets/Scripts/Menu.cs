﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour{

    public void jogar(){
        Debug.Log("Entrou no menu secundario");
        SceneManager.LoadScene("MenuSecundario");
    }

    public void opcoes(){
        Debug.Log("Entrou na cena de opções");
        SceneManager.LoadScene("Opcoes");
    }

    public void sair(){
        Debug.Log("Saiu do jogo");
        Application.Quit();
    }
}