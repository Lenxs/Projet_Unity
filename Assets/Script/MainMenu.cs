using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
	public string levelname;

    public void Select(string levelname){

    	SceneManager.LoadScene(levelname);
    }

    public void Quit(){
    	Application.Quit();
    }
}
