using UnityEngine;
using UnityEngine.UI;

public class Challenge_1_Message : MonoBehaviour
{
    public Text messTextBox;
    private string prevText;
    public GameObject spikes;
    private bool haveRead = false;
    // Start is called before the first frame update
    void Start()
    {
        spikes.SetActive(false);
        messTextBox = GameObject.Find("text_object_name").GetComponent<Text>();
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
            messTextBox.text = MessageConstants.Challenge1.sign;
            haveRead = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" 
            && haveRead)
        {
            
            spikes.SetActive(true);
        }
        messTextBox.text = prevText;

    }
}
