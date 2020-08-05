using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamestatus : MonoBehaviour
{
    [Range(0.1f,10f)] [SerializeField] float gameSpeed;
    [SerializeField] int scorePerBlockDestroyed = 73;
    [SerializeField] TextMeshProUGUI scoretext;
    [SerializeField] bool isAutoplayEnabled;
    // Start is called before the first frame update

    //state variables
    [SerializeField] int currentScore = 0;
    // Update is called once per frame
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<Gamestatus>().Length;
        if (gameStatusCount>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    private void Start()
    {
        scoretext.text = currentScore.ToString();
    }
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
    public void AddToScore() 
    {
        currentScore += scorePerBlockDestroyed;
        scoretext.text = currentScore.ToString();
    }
    public void ResetGame() 
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled() 
    {
        return isAutoplayEnabled;
    }
}
