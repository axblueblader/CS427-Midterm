using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingShard : MonoBehaviour
{
    public float verticalDirection = 1f;
    public float speed = 2f;
    public Vector2 destinationPos;
    public float moveRange = 0;
    private Vector2 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        if (moveRange != 0)
        {
            destinationPos = new Vector2(originalPos.x , originalPos.y + moveRange * verticalDirection);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (verticalDirection == -1 &&
            transform.position.y >= destinationPos.y)
        {
            transform.position = new Vector2(transform.position.x,
                transform.position.y + speed * Time.deltaTime * verticalDirection);
        }

        Debug.Log("Current: " + transform.position.y);
        Debug.Log("Dest: " + destinationPos.y);
        if (transform.position.y < destinationPos.y)
        {
            
            transform.position = originalPos;
            gameObject.SetActive(false);
            Debug.Log("Deactivated itself");
        }

    }
}
