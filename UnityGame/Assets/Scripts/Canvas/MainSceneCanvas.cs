using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneCanvas : MonoBehaviour
{
    public void Start()
    {

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