﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryPanelText : MonoBehaviour
{
    public GameObject panel;
    public GameObject statusPanel;
    public Text storyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        storyText.text = MessageConstants.WorldMessage.story;
        statusPanel.SetActive(false);
        panel.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        panel.SetActive(false);
        statusPanel.SetActive(true);
        storyText.text = "";
    }
}