using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Text messTextBox;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        messTextBox.text = MessageConstants.WorldMessage.win;
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("EndMenu");
        }
    }
}
