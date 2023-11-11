using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    GameManager gameManager;
    Rigidbody rb;
    public float moveSpeed = 5f;
    public float jumping = 7f;
    public int maxHealth=1;
    int currentHealth;
    private Camera mainCamera;
    private void Awake(){
        gameManager = FindAnyObjectByType<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        mainCamera = Camera.main;
        rb =GetComponent<Rigidbody>();
        currentHealth =maxHealth;
        gameManager.UpdateHealthText(currentHealth,maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       Movement();
       Jump();
    }
    public void Movement() {
 float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 cameraForward= mainCamera.transform.forward;
        Vector3 cameraRight= mainCamera.transform.right;
        cameraForward.y=0;
        cameraRight.y=0;

        Vector3 moveDirection = cameraForward.normalized * verticalInput + cameraRight.normalized * horizontalInput;
        
        if (moveDirection != Vector3.zero)
        {
            transform.forward=moveDirection;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        
    }
    public void Jump(){
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up *jumping,ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision other){
        if (other.gameObject.CompareTag("Damage"))
        {
            Vector3 damageDirection = other.transform.position -transform.position;
            damageDirection.Normalize();
            rb.AddForce(damageDirection*3,ForceMode.Impulse);
            currentHealth -=1;
            if (currentHealth<=0)
            {
                gameManager.Restart();
            }
            gameManager.UpdateHealthText(currentHealth,maxHealth);
        }

    }
}
