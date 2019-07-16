using UnityEngine;
using System.Collections;

public class ActivateTarget : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        target.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject target;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        target.SetActive(true);
    }
}
