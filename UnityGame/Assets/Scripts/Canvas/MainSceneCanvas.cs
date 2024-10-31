using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneCanvas : MonoBehaviour
{
    [SerializeField] GameObject childManager;

    private void Start()
    {
        childManager = GameObject.Find("Child Manager");
    }

    public void Execute()
    {
        childManager.SetActive(false);

        StartCoroutine(SceneryManager.Instance.AsyncLoad(1));
    }

    public void Option()
    {

    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif 
    }
}