using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    public float horizontalDirection = 1f;
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
            destinationPos = new Vector2(originalPos.x + moveRange * horizontalDirection, originalPos.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (horizontalDirection == -1 &&
            (transform.position.x <= originalPos.x && transform.position.x < destinationPos.x)
            || (transform.position.x <= destinationPos.x && transform.position.x <= originalPos.x)) {
            horizontalDirection = 1;
        } else if (horizontalDirection == 1 && 
            (transform.position.x > originalPos.x && transform.position.x >= destinationPos.x)
            || (transform.position.x > destinationPos.x && transform.position.x >= originalPos.x))
        {
            horizontalDirection = -1;
        }

        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime * horizontalDirection,
            transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        collision.transform.parent = transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
    }
}
