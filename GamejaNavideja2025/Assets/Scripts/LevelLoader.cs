using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    private static readonly int Start = Animator.StringToHash("Start");

    public Animator transition;
    public float transitionTime = 1f;
    void Update()
    {
        
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger(Start);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
