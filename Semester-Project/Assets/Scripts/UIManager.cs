using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI heightText;

    private UIManager instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setScoreText(int score)
    {
        scoreText.text = "" + score;
    }

    public void setHeightText(int height)
    {
        heightText.text = "" + height;
    }

    //Start a new game
    public void RestartTheGame()
    {
        SceneManager.LoadScene("Scene0");
    }
}
