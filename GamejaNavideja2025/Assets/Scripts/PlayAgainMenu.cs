using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainMenu : MonoBehaviour
{
   
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    

    public void QuitGame()
    {
        Application.Quit();
    }
}