using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void OnMainMenu()
    {
        PopUpManager.Instance.Show(AlarmType.MAINMENU);
    }

    public void CloseMainMenu()
    {
        PopUpManager.Instance.Hide(AlarmType.MAINMENU);
    }

    public void OnOption()
    {

    }

    public void OnInventory()
    {

    }
}