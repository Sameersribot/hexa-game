using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maincontroller : MonoBehaviour
{
    private float initialPosition;
    private bool isDragging = false;
    private Rigidbody2D rb;
    public int skinNumber;
    [HideInInspector]
    public Transform posToSpawn;
    [HideInInspector]
    public bool isSpawner = false;
    [SerializeField]
    private GameObject[] newBall;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        initialPosition = 2.18f;
    }

    void Update()
    {
        // Check for touch input on mobile
        if (Input.touchCount > 0)
        {
            if(gameObject.transform.position.y >=initialPosition-0.5f && gameObject.transform.position.y < initialPosition + 0.5f)
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        isDragging = true;
                        rb.isKinematic = true;
                        break;

                    case TouchPhase.Moved:
                        if (isDragging)
                        {
                            // Move ball horizontally based on touch x position horizontally in the place 
                            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
                            transform.position = new Vector3(touchPosition.x, initialPosition, 0f);
                        }
                        break;
                    case TouchPhase.Stationary:
                        if (isDragging)
                        {
                            rb.gravityScale = 0f;
                        }
                        break;
                    case TouchPhase.Ended:
                        if (isDragging)
                        {
                            isDragging = false;
                            rb.isKinematic = false;
                            rb.gravityScale = 0.3f;
                            Invoke("instantiateNewBall", 1f);
                        }
                        break;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("skin" + skinNumber.ToString()))
        {
            if(!isSpawner && gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
            {
                posToSpawn = gameObject.transform;
                if(skinNumber != 4)
                {
                    GameObject g = Instantiate(newBall[skinNumber+1], posToSpawn.position, Quaternion.identity);
                    g.GetComponent<Rigidbody2D>().gravityScale = 0.4f;
                }
                else
                {
                    int p = Random.Range(0, 4);
                    GameObject g = Instantiate(newBall[p], posToSpawn.position, Quaternion.identity);
                    g.GetComponent<Rigidbody2D>().gravityScale = 0.4f;
                }
                isSpawner = true;
            }
            Destroy(this.gameObject);//I am learning android app development 
            Destroy(collision.gameObject);
        }
    }
    void instantiateNewBall()
    {
        int randomGen = Random.Range(0, 5);
        GameObject obj = Instantiate(newBall[randomGen], new Vector3(-0.3f, initialPosition,0f), Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().gravityScale = 0f;
    }
}
