using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : UIBase
{
    public static UIManager instance;

    [SerializeField] Button[] mainButton;

    private void Awake()
    {
        if (null == instance)
            instance = this;
        else
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void Onclick_MainScene(int _index)
    {
        if ((int)Common.MainUI.NewGame == _index)
        {
        }
        else if ((int)Common.MainUI.Load == _index)
        {
            SceneManager.LoadScene("PlayScene");
        }
    }
}
