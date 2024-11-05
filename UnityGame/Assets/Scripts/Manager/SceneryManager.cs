using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneryManager : Singleton<SceneryManager>
{
    [SerializeField] GameObject mainCanvas;
    [SerializeField] Image loadingScenery;

    [SerializeField] float loadTime = 0;

    private void Start()
    {
        mainCanvas = GameObject.Find("Main Scene Canvas");
    }

    private void OnEnable()
    {
        // SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public IEnumerator OnLoadingScene()
    {        
        loadingScenery.gameObject.SetActive(true);

        while (loadTime <= 3.0f)
        {
            loadTime += Time.deltaTime;

            yield return null;
        }

        loadingScenery.gameObject.SetActive(false);
    }

    public IEnumerator AsyncLoad(int index)
    {
        if (index == 0)
        {
            CursorManager.Instance.SetCursor(true);

            MainSceneCanvas.Instance.ShowMainScene(false);
        }

        loadingScenery.gameObject.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);

        asyncOperation.allowSceneActivation = false;

        while (asyncOperation.isDone == false)
        {
            loadTime += Time.deltaTime;

            if (loadTime >= 3.0f)
            {
                loadingScenery.gameObject.SetActive(false);

                if (index == 0)
                {
                    MainSceneCanvas.Instance.ShowMainScene(true);
                }

                asyncOperation.allowSceneActivation = true;

                loadTime = 0;

                yield break;
            }

            yield return null;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // StartCoroutine(OnLoadingScene());
    }

    private void OnDisable()
    {
        // SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}