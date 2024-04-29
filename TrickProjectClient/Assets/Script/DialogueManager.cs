using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text scriptText;
    [SerializeField] float typingSpeed = 0.1f;
    string currentScene = "";



private void Start()
    {
        StartCoroutine(InputText());
    }

    IEnumerator UpdateDialogue(string name, string script)
    {
        int index = 0;
        nameText.text = name;
        scriptText.text = "";

        while (index < script.Length)
        {
            scriptText.text += script[index];

            index++;

            yield return new WaitForSeconds(typingSpeed);
        }

        while (true)
        {
            if (Input.GetMouseButton(0))
            {
                break;
            }
            yield return null;
        }
    }

    IEnumerator InputText()
    {
        yield return StartCoroutine(UpdateDialogue("ÀåÅä³¢", "¾È³çÇÏ¼¼¿ä"));
        yield return StartCoroutine(UpdateDialogue("ÀåÅä³¢", "¹Ý°©½À´Ï´Ù"));
    }
}
