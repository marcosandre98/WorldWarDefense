using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
	public void Sair() {
		Debug.Log("Voltando ao menu...");
		SceneManager.LoadScene("CenaMenu");
	}
}
