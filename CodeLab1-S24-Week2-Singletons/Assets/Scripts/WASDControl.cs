using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WASDControl : MonoBehaviour
{
    public static WASDControl Instance;
    
    Rigidbody2D rb2d;
    
    public float forceAmount = 60;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb2d.AddForce(Vector2.up * forceAmount);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddForce(Vector2.left * forceAmount);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb2d.AddForce(Vector2.down * forceAmount);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(Vector2.right * forceAmount);
        }

        rb2d.velocity *= 0.999f;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        //size goes up by 1
        if (other.gameObject.tag == "fire")
        {
            gameObject.transform.localScale += new Vector3(.25f, .25f, .25f);
        }
        
        if (other.gameObject.tag == "building")
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1);
            
        }
        
    }
    
    
}
