using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Text controls_Text;
    void Start()
    {
        //SceneManager.LoadScene("Main Menu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void OpenControls()
    {
        controls_Text.gameObject.SetActive(true);
    }
}
