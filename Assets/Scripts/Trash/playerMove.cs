using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMove : MonoBehaviour
{
   public static playerMove instance;

    private Rigidbody rb;
   
    [SerializeField] public float jumpForce = 2.584685f;

    public Vector3 fromPosition;
    public Vector3 toPosition ;
    [SerializeField]public float speed = 1;
    private float progress;
    [SerializeField] private float newX, newZ;
    [SerializeField] private float staticY;
    [SerializeField]private Vector3 moveValue, newPosition;
    public bool isCorrect;
    public bool isMove = true;

    [SerializeField]private bool isGrounded;
    public bool IsGrounded
    {
        get
        {
            return isGrounded;
        }
        set 
        {
           
            isGrounded = value;
        }
    }
    void Awake()
    {
        instance = this;

        rb = GetComponent<Rigidbody>();
      
        fromPosition = transform.position;

        staticY = transform.position.y;

        Debug.Log("Y = " + staticY);
    }
    void Start()
    {
    
    }
    void FixedUpdate()
    {

    }
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.RightArrow) )
        {
           
                Jump(0);
            

        }
        if ( Input.GetKeyDown(KeyCode.LeftArrow) )
        {
            
                Jump(1);
           
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) )
        {
           
                Jump(2);
        }
        if ( Input.GetKeyDown(KeyCode.DownArrow))
        {
            
                Jump(3);
            

        }
        if ( Input.GetKeyDown(KeyCode.Space))
        {

            Jump(4);


        }
    }
    public void Jump(int direct)
    {
        if (IsGrounded&&isMove)
        {
            switch (direct)
            {
                case 0:
                    rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                    rb.AddForce(transform.right * jumpForce, ForceMode.Impulse);
                    break;
                case 1:
                    rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                    rb.AddForce(transform.right * (-jumpForce), ForceMode.Impulse);
                    break;
                case 2:
                    rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                    rb.AddForce(transform.forward * jumpForce, ForceMode.Impulse);
                    break;
                case 3:
                    rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                    rb.AddForce(transform.forward * (-jumpForce), ForceMode.Impulse);
                    break;
                case 4:
                    rb.AddForce(transform.up * jumpForce*2, ForceMode.Impulse);
                    break;

            }
        }

        isGrounded = false;
    }
    

  

   
    
    public void playerLose()
    {
        isCorrect = false;
        rb.constraints = RigidbodyConstraints.None;
     
        transform.localScale = new Vector3(1f, 0.07f, 1f);

        

    }
}
