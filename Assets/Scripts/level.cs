using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int breakbleBlocks;
    //cashed reference
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        
    }
    public void CountBlocks() 
    {
        breakbleBlocks++;
    }
    public void BlockDestroyed() 
    {
        breakbleBlocks--;
        if (breakbleBlocks<=0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
