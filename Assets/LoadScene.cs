using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    //public string sceneName = "scene2";

    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
