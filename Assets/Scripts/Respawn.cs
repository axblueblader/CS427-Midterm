using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public Transform respawnArea;
    private Transform target;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<Transform>();
        respawnAtArea();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("isDead: " + animator.GetBool("isDead"));
        if (animator.GetBool("isDead") && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void respawnAtArea()
    {
        if (target && respawnArea)
        {
            target.position = respawnArea.position;
        }
    }
}
