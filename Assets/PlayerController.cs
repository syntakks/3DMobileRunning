using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public Animator animator; 
    float horizontal;
    float vertical;
    Vector3 movement; 
    public float moveSpeed;
    float animationSpeed;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
        HandleAnimation(); 
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void HandleMovementInput()
    {
        horizontal = CrossPlatformInputManager.GetAxis("Horizontal"); 
        vertical = CrossPlatformInputManager.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0, vertical).normalized; 
    }

    private bool UpdateAngles()
    {
        return horizontal != 0 || vertical != 0; 
    }

    private void Move()
    {
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        if (UpdateAngles())
        {
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(horizontal, vertical) * 180 / Mathf.PI, 0);
        }
    }

    private void HandleAnimation()
    {
        float horizontalMag = Mathf.Abs(horizontal);
        float verticalMag = Mathf.Abs(vertical);
        animationSpeed = Mathf.Max(horizontalMag, verticalMag); 
        animator.SetFloat("Speed", animationSpeed); 
    }
    
}
