using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
	
public class GameManager : MonoBehaviour
{
    public static float Speed;
    public static bool FirstPerson;

    public bool setFirstPerson;
    public float setSpeed;
    // Start is called before the first frame update
    void Start()
    {
    	Speed = setSpeed;
    	FirstPerson = setFirstPerson;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }




}
