using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    private MenuManager menuManager;

    public void ClickedYes()
    {
        menuManager.GetComponent<MenuManager>().MenuActivated = false;

        MainSceneCanvas.Instance.ReturnScene();

        gameObject.SetActive(false);
    }

    public void ClickedNo()
    {
        gameObject.SetActive(false);
    }
}