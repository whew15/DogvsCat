using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject normalCat; 
    public GameObject fatCat;
    public GameObject pirateCat;
    public GameObject retryBtn;
    public RectTransform levelFront;
    public Text levelTxt;

    public int level = 0 ;
    int score = 0 ;

     
    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }
        Application.targetFrameRate = 60;
        Time.timeScale = 1.0f;
    } 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeCat", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeCat()
    {
        Instantiate(normalCat) ;
        if(level == 1)
        {
            int p = Random.Range(0,10);
            if(p < 2)Instantiate(normalCat);
        }
        else if(level == 2)
        {
            int p = Random.Range(0,10);
            if(p < 5)Instantiate(normalCat);
        }
        else if (level == 3 )
        {
            Instantiate(fatCat);
        }
        else if (level >= 4)
        {
            float p = Random.Range(0,10);
            if (p < 5) Instantiate(normalCat);
            Instantiate(fatCat);
            Instantiate(pirateCat);
        }
    }
    public void GameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0f;
    }
    public void AddScore()
    {
        score++;
        level = score / 5;
        levelTxt.text = level.ToString();
        levelFront.localScale = new Vector3((score - level* 5) / 5.0f, 1f, 1f);
    }

}
