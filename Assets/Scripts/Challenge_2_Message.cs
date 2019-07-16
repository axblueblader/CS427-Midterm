using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Challenge_2_Message : MonoBehaviour
{
    public Text messTextBox;

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
        if (collision.gameObject.tag == "Player")
        {
            messTextBox.text = MessageConstants.Challenge2.sign;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            messTextBox.text = prevText;
        }
    }
}
