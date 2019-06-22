using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CreateGame : MonoBehaviour
{
	public GameObject canvas;
	public GameObject cards;
	public Sprite question;
	public Sprite mario;
	public Sprite luigi;
	public Sprite peach;
	public Sprite up;
	public Sprite mushroom;
	public Sprite star;
	public Sprite coin;
	public Sprite bulletbill;
	public Sprite thwomp;
	public AudioSource blocoSuccess;
	public AudioSource blocoError;
	public AudioSource blocoPoint;
	public AudioSource blocoMico;
	public AudioSource blocoWin;
	public AudioSource blocoLose;

    public GameObject txtTimeOut;
    Coroutine cTimer = null;
    int timer = 0;
    float timerNow = 0;

    int ACC = 0;
    int DEFALULT_CORRECT = 8;

    int[] ids_1 = {0, 1, 2, 3, 4, 5, 6, 7, 8};
	int[] ids_2 = {0, 1, 2, 3, 4, 5, 6, 7};
	int[] ids_3 = {-1, -1};
	string[] images = {"mario", "luigi", "peach", "1up", "mushroom", "star", "coin", "bulletbill", "thwomp"};
	Sprite[] images_s = new Sprite[10];
	GameObject[] cards_s = new GameObject[17];
	int[] cards_aux = {-1, -1};
	int flag = 0;
	float df = 1;
    float lf = 10;

    bool isOpenWin = false;
    bool isOpenLoser = false;

    private Rect windowRect = new Rect((Screen.width - 300) / 2, (Screen.height - 500) / 2, 300, 500);


    // Start is called before the first frame update
    void Start()
    {	    	    
        if (PlayerPrefs.GetFloat("Dificuldade") == 0) { timer = 60; }
        else if (PlayerPrefs.GetFloat("Dificuldade") == 1) { timer = 40; }
        else if (PlayerPrefs.GetFloat("Dificuldade") == 2) {timer = 20;}
	    
    	Random.InitState(System.Environment.TickCount);

    	reshuffle(ids_1);
    	reshuffle(ids_2);

    	images_s[0] = mario;
    	images_s[1] = luigi;
    	images_s[2] = peach;
    	images_s[3] = up;
    	images_s[4] = mushroom;
    	images_s[5] = star;
    	images_s[6] = coin;
    	images_s[7] = bulletbill;
    	images_s[8] = thwomp;
    	images_s[9] = question;

    	int j = 0;
    	int k = 0;
    	for(int i = 0; i < cards.transform.childCount; i++) {
    		cards_s[i] = cards.transform.GetChild(i).gameObject;
    		if((i % 2) == 0) {
    			AddListener(cards_s[i].GetComponent<Button>(), ids_1[j], i);
    			j++;
    		}
    		else {
    			AddListener(cards_s[i].GetComponent<Button>(), ids_2[k], i);
    			k++;
    		}
    	}

        cTimer = StartCoroutine(dimissTime());

      //  StartCoroutine(rotateAll());
    }

    void addTime()
    {
        StopCoroutine(cTimer);

        timerNow = timerNow + 10;
        timer = (int) timerNow;
        cTimer = StartCoroutine(dimissTime());
    }

    IEnumerator dimissTime()
    {	    
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");
        txtTimeOut.GetComponent<TextMeshProUGUI>().text = string.Format("{0}:{1}", minutes, seconds);

        for (float i = timer; i >= 0; i -= (Time.deltaTime * 1))
        {
            minutes = Mathf.Floor(i / 60).ToString("00");
            seconds = (i % 60).ToString("00");
            txtTimeOut.GetComponent<TextMeshProUGUI>().text = string.Format("{0}:{1}", minutes, seconds);
            timerNow = i;
            yield return null;
        }

        // set gameover

        print("end game");

        isOpenLoser = true;

		canvas.GetComponent<AudioSource>().Stop();
		blocoLose.Play();

        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void reshuffle(int[] texts)
    {
        for (int t = 0; t < texts.Length; t++)
        {
            int tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }

    void AddListener(Button b, int value, int i) 
	{
		b.onClick.AddListener(() => clickCard(b, value, i));
	}

    void clickCard(Button b, int value, int i)
    {
    	if(b.image.sprite == images_s[9] && flag == 0) {
	    	blocoSuccess.Play();
	    	
	    	b.image.sprite = images_s[value];

	    	if(ids_3[0] == -1) {
	    		ids_3[0] = value;
	    		cards_aux[0] = i;
	    	}
	    	else if(ids_3[1] == -1) {
	    		ids_3[1] = value;
	    		cards_aux[1] = i;
	    	}
	    	
	    	if(value == 8) {
		    	blocoMico.Play();
		    	flag = 1;
		    	
		    	if(ids_3[0] != -1 && ids_3[1] != -1) {
			    	StartCoroutine(waitAndBackface(cards_s[cards_aux[0]].GetComponent<Button>(), cards_s[cards_aux[1]].GetComponent<Button>(), 9));	
		    	}
		    	else {
			    	if(ids_3[0] != -1) {
			    		StartCoroutine(waitAndBackfaceOne(cards_s[cards_aux[0]].GetComponent<Button>(), 9));
			    	}
			    	if(ids_3[1] != -1) {
			    		StartCoroutine(waitAndBackfaceOne(cards_s[cards_aux[1]].GetComponent<Button>(), 9));
			    	}
		    	}
		    	ids_3[0] = -1;
	    		ids_3[1] = -1;
	    		cards_aux[0] = -1;
	    		cards_aux[1] = -1;
	    	}
			else if(ids_3[0] != -1 && ids_3[1] != -1) {

	    		if(ids_3[0] != ids_3[1]) {
	    			flag = 1;
					StartCoroutine(waitAndBackface(cards_s[cards_aux[0]].GetComponent<Button>(), cards_s[cards_aux[1]].GetComponent<Button>(), 9));
	    		}
	    		else {

                    ACC++;
                    blocoPoint.Play();
                    addTime();

                    if(ACC == DEFALULT_CORRECT) {
                        print("end game");
                        endGame();
                    }

                }
	    		ids_3[0] = -1;
	    		ids_3[1] = -1;
	    		cards_aux[0] = -1;
	    		cards_aux[1] = -1;
	    	}
    	}
    	else {
	    	blocoError.Play();
    	}
    }

    IEnumerator waitAndBackface(Button a, Button b, int i)
    {
    	yield return new WaitForSeconds(1.0f);
        a.image.sprite = images_s[9];
	    b.image.sprite = images_s[9];
	    flag = 0;
    }
    
    IEnumerator waitAndBackfaceOne(Button a, int i)
    {
    	yield return new WaitForSeconds(1.0f);
        a.image.sprite = images_s[9];
	    flag = 0;
    }

    private void endGame() {

        StopCoroutine(cTimer);
        print(timerNow);

        string valFind = "";
        if (PlayerPrefs.GetFloat("Dificuldade") == 0){valFind = "ScoreFacil";}
        else if (PlayerPrefs.GetFloat("Dificuldade") == 1){valFind = "ScoreMedio";}
        else if (PlayerPrefs.GetFloat("Dificuldade") == 2) {valFind = "ScoreDificil";}

        float x = PlayerPrefs.GetFloat(valFind);
        if (timerNow > x)
        {
            print("set new");
            PlayerPrefs.SetFloat(valFind, timerNow);
        }
        
        canvas.GetComponent<AudioSource>().Stop();
        blocoWin.Play();

        StartCoroutine(rotateAll());

    }

    IEnumerator rotateAll()
    {

        for (int i = 0; i < cards.transform.childCount; i++)
        {
            StartCoroutine(rotate(i));
        }

        for (float j = 2.5F; j >= 0; j -= (Time.deltaTime * 1)){
            yield return null;
        }

        print("end game");
        isOpenWin = true;

    }

    IEnumerator rotate(int i)
    {
        for (float j = 2; j >= 0; j -= (Time.deltaTime * 1))
        {
            cards.transform.GetChild(i).gameObject.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, j * 100);
            yield return null;
        }
    }

    void OnGUI() //I think this must be used on the camera so you may have to reference a gui controller on the camera
    {
        if (isOpenWin) //Is it Open?
        {
            flag = 1;
            GUI.Window(0, windowRect, DialogWindowWin, "PARABÉNS");
        }

        if (isOpenLoser) //Is it Open?
        {
            flag = 1;
            GUI.Window(0, windowRect, DialogWindowLoser, "VOCÊ PERDEU CARA");
        }
    }

    // This is the actual window.
    void DialogWindowWin(int windowID)
    {	    
        float y = 20;
        GUI.Label(new Rect((windowRect.width / 2) - 50, y, windowRect.width, 20), "VOCÊ VENCEU");
        y = y + 20;

        GUI.Label(new Rect((windowRect.width / 2) - 45, y, windowRect.width, 20), "SEU TEMPO");
        y = y + 20;

        GUI.Label(new Rect((windowRect.width / 2) - 25, y, windowRect.width, 50), txtTimeOut.GetComponent<TextMeshProUGUI>().text);
        y = y + 20;

        string nivel = "";
        if (PlayerPrefs.GetFloat("Dificuldade") == 0) { nivel = "FÁCIL"; }
        else if (PlayerPrefs.GetFloat("Dificuldade") == 1) { nivel = "MÉDIO"; }
        else if (PlayerPrefs.GetFloat("Dificuldade") == 2) { nivel = "DIFÍCIL"; }

        GUI.Label(new Rect((windowRect.width / 2) - 65, y, windowRect.width, 50), "DIFICULDADE: "+nivel);
        y = y + 20;

        GUI.Label(new Rect((windowRect.width / 2) - 55, y, windowRect.width, 50), "MELHOR TEMPO");
        y = y + 20;

        string valFind = "";
        if (PlayerPrefs.GetFloat("Dificuldade") == 0) { valFind = "ScoreFacil"; }
        else if (PlayerPrefs.GetFloat("Dificuldade") == 1) { valFind = "ScoreMedio"; }
        else if (PlayerPrefs.GetFloat("Dificuldade") == 2) { valFind = "ScoreDificil"; }
        float x = PlayerPrefs.GetFloat(valFind);

        string minutes = Mathf.Floor(x / 60).ToString("00");
        string seconds = (x % 60).ToString("00");
        GUI.Label(new Rect((windowRect.width / 2) - 25, y, windowRect.width, 50), string.Format("{0}:{1}", minutes, seconds));
        y = y + 40;

        if (GUI.Button(new Rect(5, y, windowRect.width - 10, 20), "JOGAR NOVAMENTE"))
        {
            Application.LoadLevel(1);
            isOpenWin = false;
        }
        y = y + 30;

        if (GUI.Button(new Rect(5, y, windowRect.width - 10, 20), "SCORES"))
        {
            SceneManager.LoadScene("CenaScores");
        }
        y = y + 30;

        if (GUI.Button(new Rect(5, y, windowRect.width - 10, 20), "SAIR"))
        {
            SceneManager.LoadScene("CenaMenu");
        }
        y = y + 30;

    }

    // This is the actual window.
    void DialogWindowLoser(int windowID)
    {	    
        float y = 20;
        GUI.Label(new Rect((windowRect.width / 2) - 65, y, windowRect.width, 20), "NAO FOI DESSA VEZ");
        y = y + 20;

        GUI.Label(new Rect((windowRect.width / 2) - 70, y, windowRect.width, 20), "ESGOTOU SEU TEMPO");
        y = y + 20;

        string nivel = "";
        if (PlayerPrefs.GetFloat("Dificuldade") == 0) { nivel = "FÁCIL"; }
        else if (PlayerPrefs.GetFloat("Dificuldade") == 1) { nivel = "MÉDIO"; }
        else if (PlayerPrefs.GetFloat("Dificuldade") == 2) { nivel = "DIFÍCIL"; }

        GUI.Label(new Rect((windowRect.width / 2) - 65, y, windowRect.width, 50), "DIFICULDADE: " + nivel);
        y = y + 20;

        GUI.Label(new Rect((windowRect.width / 2) - 55, y, windowRect.width, 50), "MELHOR TEMPO");
        y = y + 20;

        string valFind = "";
        if (PlayerPrefs.GetFloat("Dificuldade") == 0) { valFind = "ScoreFacil"; }
        else if (PlayerPrefs.GetFloat("Dificuldade") == 1) { valFind = "ScoreMedio"; }
        else if (PlayerPrefs.GetFloat("Dificuldade") == 2) { valFind = "ScoreDificil"; }
        float x = PlayerPrefs.GetFloat(valFind);

        string minutes = Mathf.Floor(x / 60).ToString("00");
        string seconds = (x % 60).ToString("00");
        GUI.Label(new Rect((windowRect.width / 2) - 25, y, windowRect.width, 50), string.Format("{0}:{1}", minutes, seconds));
        y = y + 40;

        if (GUI.Button(new Rect(5, y, windowRect.width - 10, 20), "JOGAR NOVAMENTE"))
        {
            Application.LoadLevel(1);
            isOpenLoser = false;
        }
        y = y + 30;

        if (GUI.Button(new Rect(5, y, windowRect.width - 10, 20), "SCORES"))
        {
            SceneManager.LoadScene("CenaScores");
        }
        y = y + 30;

        if (GUI.Button(new Rect(5, y, windowRect.width - 10, 20), "SAIR"))
        {
            SceneManager.LoadScene("CenaMenu");
        }
        y = y + 30;

    }
}
