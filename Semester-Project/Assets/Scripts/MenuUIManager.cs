using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI heightText;

    public static MenuUIManager instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        setScoreText(PlayerPrefs.GetInt("Score"));
        setHeightText(PlayerPrefs.GetInt("Height"));
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

    //Start a new game of 1 player
    public void Start1Player()
    {
        SceneManager.LoadScene(1);
    }


    //Start a new game of 2 player
    public void Start2Player()
    {
        SceneManager.LoadScene(2);
    }

}
