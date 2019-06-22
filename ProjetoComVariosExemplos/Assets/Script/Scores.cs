using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour
{
    // Use this for initialization

    public GameObject txtFacil;
    public GameObject txtMedio;
    public GameObject txtDificil;

    private void Start()
    {
        float ScoreFacil = PlayerPrefs.GetFloat("ScoreFacil");
        float ScoreMedio = PlayerPrefs.GetFloat("ScoreMedio");
        float ScoreDificil = PlayerPrefs.GetFloat("ScoreDificil");

        string minutes = Mathf.Floor(ScoreFacil / 60).ToString("00");
        string seconds = (ScoreFacil % 60).ToString("00");
        txtFacil.GetComponent<TextMeshProUGUI>().text = string.Format("{0}:{1}", minutes, seconds);

        minutes = Mathf.Floor(ScoreMedio / 60).ToString("00");
        seconds = (ScoreMedio % 60).ToString("00");
        txtMedio.GetComponent<TextMeshProUGUI>().text = string.Format("{0}:{1}", minutes, seconds);

        minutes = Mathf.Floor(ScoreDificil / 60).ToString("00");
        seconds = (ScoreDificil % 60).ToString("00");
        txtDificil.GetComponent<TextMeshProUGUI>().text = string.Format("{0}:{1}", minutes, seconds);

    }

    public void Back()
    {
        Debug.Log("Salvou o game e voltou a tela inicial");
        SceneManager.LoadScene("CenaMenu");
    }

}
