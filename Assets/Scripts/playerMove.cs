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
           // Debug.Log("isGrounded = " + value);
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
        SwipeManager.instance.onSwipeEvent += Jump;
    }
    void FixedUpdate()
    {

       
        if (Input.GetKeyDown(KeyCode.O))
        {
            // positionCorrect();
            Debug.Log("O");
        }

    }
    void Update()
    {
        if (/*isGrounded &&*/ Input.GetKeyDown(KeyCode.RightArrow) )
        {
           
                Jump(0);
            

        }
        if (/*isGrounded &&*/ Input.GetKeyDown(KeyCode.LeftArrow) )
        {
            
                Jump(1);
           
        }
        if (/*isGrounded &&*/ Input.GetKeyDown(KeyCode.UpArrow) )
        {
           
                Jump(2);
        }
        if (/*isGrounded &&*/ Input.GetKeyDown(KeyCode.DownArrow))
        {
            
                Jump(3);
            

        }
        if (/*isGrounded &&*/ Input.GetKeyDown(KeyCode.Space))
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
    

  

    public void positionCorrect(Vector3 cellPosition)
    {
        newPosition = cellPosition;
        newPosition.y = staticY;
        transform.position = Vector3.Lerp(transform.position, newPosition, speed);
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag=="Cell")
    //    {

    //       Debug.Log("На клетке брат");



    //        newPosition = collision.gameObject.transform.position;
    //        newPosition.y = staticY;
    //        roundUp();
    //        //newPosition.y = transform.position.y;
    //        isGrounded = true;

    //        //if (transform.position.y >= staticY)
    //        //{
    //        //    roundUp();
    //        //}
    //        //staticY = transform.position.y;

    //    }
    //}
    public void playerLose()
    {
        isCorrect = false;
        rb.constraints = RigidbodyConstraints.None;
     //   rb.AddForce(transform.up * (3 * 2.5f), ForceMode.Impulse);
       // Physics.gravity = new Vector3(0, -9.81f, 0);
        transform.localScale = new Vector3(1f, 0.07f, 1f);

        // transform.rotation == transform.rotation + new Quaternion(0, 0, 0, 0);
        //rb.AddForce(transform.up * (4 * jumpForce), ForceMode.Impulse);
        //rb.AddForce(transform.right * (3 * jumpForce), ForceMode.Impulse);
        // rb.AddForce(transform. * (2 * jumpForce), ForceMode.Impulse);
        //  rb.AddTorque(new Vector3(transform.position.x+1, transform.position.y + 1, transform.position.z + 1),ForceMode.Impulse);


    }
}
