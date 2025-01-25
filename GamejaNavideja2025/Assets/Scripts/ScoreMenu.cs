using TMPro;
using UnityEngine;

public class ScoreMenu : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text += " "+ScoreManager.instance.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
