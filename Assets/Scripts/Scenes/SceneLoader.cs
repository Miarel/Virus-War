using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static AsyncOperation asyncOperation;

    public static void LoadScene (string sceneName)
    {
        asyncOperation = SceneManager.LoadSceneAsync(sceneName);
    }
}
