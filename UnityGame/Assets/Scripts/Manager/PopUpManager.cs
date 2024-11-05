using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AlarmType
{
    MAINMENU,
    OBTAIN,
    OPTION,
    INVENTORY,
    EXIT
}

public class PopUpManager : MonoBehaviour
{
    [SerializeField] List<GameObject> popUp;

    private static PopUpManager instance;

    public static PopUpManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);

            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Show(AlarmType alarmType)
    {
        popUp[(int)alarmType].gameObject.SetActive(true);
    }

    public void Hide(AlarmType alarmType)
    {
        popUp[(int)alarmType].gameObject.SetActive(false);
    }
}