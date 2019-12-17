using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Button start, quit, tutorial;
    // Start is called before the first frame update
    
    public void StartClick()
    {
        SceneManager.LoadScene("Briefing");
    }

    public void TutorialClick()
    {
        SceneManager.LoadScene("Player_Test");
    }

    public void QuitClick()
    {
        Application.Quit();
    }
}
