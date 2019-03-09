using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStats : MonoBehaviour
{
  
    public Image MorImg;
    public float currentMor;
    public float maxMor;
    public Image libImg;
    public float currentLib;
    public float maxLib;
    public Image BonImg;
    public float currentBon;
    public float maxBon;
    public Image fadePlane;
  
    public GameObject gameOverUI;
    public FirstPersonController player;


    void Start()
    {
        player=GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        

        float percentageMor = ((currentMor * 100) / maxMor) / 100;
        MorImg.fillAmount = percentageMor;
        

        float percentageLib = ((currentLib * 100) / maxLib) / 100;
        libImg.fillAmount = percentageLib;
        

        float percentageBon = ((currentBon * 100) / maxBon) / 100;
        BonImg.fillAmount = percentageBon;
        


        //test 
        if (Input.GetKeyDown(KeyCode.K))
        {
            Action(2);
        }
    }

    public void Action(float TheAction)
    {
        currentLib = currentLib - TheAction;
        currentMor = currentMor - TheAction;
        currentBon = currentBon - TheAction;

        if (currentBon<= 0 ||  currentMor <= 0 || currentLib <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        player.gameOver = true;
        Debug.Log("Perdu");
        StartCoroutine(Fade(Color.clear, new Color(0, 0, 0, .95f), 1));
    }

    IEnumerator Fade(Color from, Color to, float time)
    {
        float speed = 1 / time;
        float percent = 0;

        while (percent < 1)
        {
            percent += Time.deltaTime * speed;
            fadePlane.color = Color.Lerp(from, to, percent);
            yield return null;
        }
    }
}
