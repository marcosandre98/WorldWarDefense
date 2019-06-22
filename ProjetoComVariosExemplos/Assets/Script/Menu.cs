using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Menu : MonoBehaviour
{

    public void Jogar() {
		Debug.Log("Entrou no jogo");
		SceneManager.LoadScene("CenaJogo");
	}

	public void Opcoes() {
		Debug.Log("Entrou em opções");
		SceneManager.LoadScene("CenaOpcoes");
	}

    public void Scores()
    {
        Debug.Log("Entrou em scores");
        SceneManager.LoadScene("CenaScores");
    }

    public void Sair() {
		Debug.Log("Saiu do jogo");
		Application.Quit();
	}
	
	public void Creditos() {
		Debug.Log("Entrou na cena de créditos");
		SceneManager.LoadScene("CenaCreditos");
	}

}
