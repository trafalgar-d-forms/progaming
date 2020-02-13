using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingController : MonoBehaviour
{
    AsyncOperation async;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingScreen());
    }

    IEnumerator LoadingScreen()
    {
        async = SceneManager.LoadSceneAsync(2);
        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            if (async.progress == 0.9f)
            {
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
