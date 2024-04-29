using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    protected virtual void popupOpen()
    {
        gameObject.SetActive(false);
    }
    protected virtual void popupClose()
    {
        gameObject.SetActive(false);
    }
}
