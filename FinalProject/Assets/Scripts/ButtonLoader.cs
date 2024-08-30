using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoader : MonoBehaviour
{
    // In win and lose scene, there will be buttons, this script is used to do some action when the buttons are pressed

    public void StartGame()                   // takes us to level 1
    {
        SceneManager.LoadScene("Level 1");

    }

    public void PlayAgain()
    {                                        // takes us to menu scene
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
