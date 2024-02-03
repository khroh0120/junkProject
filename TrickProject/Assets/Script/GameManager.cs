using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Button[] Buttons;


    private static GameManager instance = null;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    enum MainButton { Start, End, }

    public void OnClick_MainButton ()
    {
        if (Buttons[(int)MainButton.Start])
        {
            SceneManager.LoadScene("Play");
        }
    }
}
