using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Opcoes : MonoBehaviour
{
    public GameObject sdlNivel;

    private void Start()
    {
        sdlNivel.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Dificuldade");
    }

    public void Dificuldade(float v) {
		Debug.Log(v);
		PlayerPrefs.SetFloat("Dificuldade", v);
	}

	public void Salvar() {
		Debug.Log("Salvou o game e voltou a tela inicial");
		SceneManager.LoadScene("CenaMenu");
	}
}
