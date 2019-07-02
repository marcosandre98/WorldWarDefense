using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour{

    public string nomeCena;
    public AudioMixer audioMixer;

    public void jogar(string MenuSecundario){
        Debug.Log("Entrou no menu secundario");
        nomeCena = "MenuSecundario";
        StartCoroutine("Abrir");
    }

    public void opcoes(string Opcoes){
        Debug.Log("Entrou na cena de opções");
        nomeCena = "Opcoes";
        StartCoroutine("Abrir");
    }

    public void sair(){
        Debug.Log("Saiu do jogo");
        Application.Quit();
    }

    public void iniciarCutscene(string CutsceneInicial)
    {
        Debug.Log("Entrou na cutscene incial");
        nomeCena = "CutsceneInicial";
        StartCoroutine("Abrir");
    }

    public void iniciarFaseEixo(string MapaEixo){
        Debug.Log("Entrou na cena do mapa do Eixo");
        nomeCena = "MapaEixo";
        StartCoroutine("Abrir");
    }

    public void iniciarFaseAliados(string MapaAliados){
        Debug.Log("Entrou na cena do mapa dos Aliados");
        nomeCena = "MapaAliados";
        StartCoroutine("Abrir");
    }

    // Classe feita para ter um delay de 0.5s quando um botão for clicado
    private IEnumerator Abrir(){
        yield return new WaitForSeconds (0.5f);
        SceneManager.LoadScene(nomeCena);
    }

    public void SetVolume (float volume){
        audioMixer.SetFloat("volume", volume);
    }
}