using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public void ClickedYes()
    {
        MainSceneCanvas.Instance.ReturnScene();

        gameObject.SetActive(false);
    }

    public void ClickedNo()
    {
        gameObject.SetActive(false);
    }
}