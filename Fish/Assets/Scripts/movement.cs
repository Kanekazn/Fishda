using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public GameObject boat;
    public GameObject hook;
    public int maxy = -5;
    public float miny = 1.5f;
    public TextMeshProUGUI text;
    public TextMeshProUGUI fishtext;
    public GameObject mintarg;
    public GameObject maxtarg;
    public bool isMovingDown = true;
    public bool isMoving = false;
    public bool inplace = true;
    public float speed = 5f;
    fish fish;

    public int fishcount = 0;
    private int keyPressCount = 0; 
    private bool isHookStopped = false; 
    private float stopDuration = 5f;
    private float timer = 0f; 
    private float keyPressTimeLimit = 5f;
    bool ishooked = false;
    private GameObject currentCollidedObject;

    public float gameTimer = 60;

    public void Start()
    {
         fish = fish.GetComponent<fish>();
        
        
    }

    public void Update()
    {
        gameTimer -= Time.deltaTime;
        text.text = gameTimer.ToString("F0");
        float horizontalMovement = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            horizontalMovement = -1f;
            boat.transform.localScale = new Vector3(1, 1, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalMovement = 1f;
            boat.transform.localScale = new Vector3(-1, 1, 0);
        }

        transform.Translate(Vector3.right * horizontalMovement * moveSpeed * Time.deltaTime);

       
        if (Input.GetKeyDown(KeyCode.Q) && !isMoving && !isHookStopped)
        {
            isMoving = true;
            isMovingDown = true;
        }

       
        if (isMoving)
        {
            if (isMovingDown)
            {
                hook.transform.position = Vector3.MoveTowards(hook.transform.position, maxtarg.transform.position, speed * Time.deltaTime);

               
                if (isHookStopped)
                {
                    float timer =+ Time.deltaTime;
                  
                    if (timer >= 5f)
                    {
                      
                        isMovingDown = false;
                        isMoving = true;
                    }
                    isMovingDown = false;
                    isMoving = false;

                }
                if (hook.transform.position.y <= maxtarg.transform.position.y)
                {
                    isMovingDown = false;
                }
            }
            else
            {
                hook.transform.position = Vector3.MoveTowards(hook.transform.position, mintarg.transform.position, speed * Time.deltaTime);

                
                if (hook.transform.position.y >= mintarg.transform.position.y)
                {
                    isMoving = false;
                    EnableObjectCollider();
                }
            }
        }

        
        if (isHookStopped)
        {
            timer += Time.deltaTime;

            if (timer <= keyPressTimeLimit)
            {
                if (Input.GetKeyDown(KeyCode.K)){
                    keyPressCount++;
                    Debug.Log("K key pressed! Current count: " + keyPressCount);
                }
            }

            // If key press count is less than 20 within 5 seconds, move hook up
            if (timer >= stopDuration)
            {
                if (keyPressCount < 20)
                {
                    
                    Debug.Log("Not enough 'K' presses. Moving hook up...");
                    isMoving = true;
                    isMovingDown = false;
                    ishooked = false;
                    keyPressCount = 0; 
                }

                if (keyPressCount >= 20)
                {
                    Debug.Log("enough 'K' presses. Moving hook up...");
                  
                    ishooked = true;
                    isMoving = true;
                   
                    isMovingDown = false;
                   
                    if (currentCollidedObject != null)
                    {
                        currentCollidedObject.SetActive(false);
                        Debug.Log("Object deactivated after 20 key presses");
                    }
                    fishcount++;
                    fishtext.text = "Fish : " + fishcount;
                }
               
                timer = 0f;
                isHookStopped = false; // Stop the hook after 5 seconds
            }
        }
        if(fishcount >= 15 || gameTimer <= 0)
        {
            SceneManager.LoadScene("Bonusgame");
            DontDestroyOnLoad(text);
        }
    }


     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fish"))
        {
            Debug.Log("Hook collided with fish! Stopping hook for 5 seconds.");
            isHookStopped = true;
            DisableObjectCollider();
            currentCollidedObject = collision.gameObject;

            keyPressCount = 0; 
            timer = 0f; 

        }
      
    }
    void DisableObjectCollider()
    {

        hook.GetComponent<Collider2D>().enabled = false;
        
    }
    void EnableObjectCollider()
    {
        hook.GetComponent<Collider2D>().enabled = true;

    }

    
}
