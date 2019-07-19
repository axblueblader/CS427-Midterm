using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSceneRespawnLevel_2 : MonoBehaviour
{
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
        Respawn.level = 2;
        Debug.Log("Switched to level 2 scene entirely");
    }
}
