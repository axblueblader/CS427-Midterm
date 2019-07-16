using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMessTextBoxInArea : MonoBehaviour
{
    public Text messTextBox;

    public string messageToDisplay;

    public bool doExit = false;

    private string prevText;
    // Start is called before the first frame update
    void Start()
    {
        if (messTextBox == null)
        {
            messTextBox = GameObject.Find("MessTextBox").GetComponent<Text>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        prevText = messTextBox.text;
        messTextBox.text = messageToDisplay;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (messTextBox == null && doExit)
        {
            messTextBox = GameObject.Find("MessTextBox").GetComponent<Text>();
        }
    }
}
