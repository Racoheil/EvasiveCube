using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmControl : MonoBehaviour
{
    [SerializeField]float speed = 10f;
    [SerializeField] GameObject pacm;
    [SerializeField] bool isMove;
    void Update()
    {
      // pacmMove();
    }
    private void Start()
    {
        StartCoroutine("pacmMoveCoroutine");
    }
    void pacmMove()
    {
        pacm.transform.Translate(transform.right * speed * Time.deltaTime);
     //   pacm.transform.Tr
    }
    IEnumerator pacmMoveCoroutine()
    {
       



            while (isMove)
            {

            //pacm.transform.position.z -= 0.1;
            var step = speed * Time.deltaTime;
            pacm.transform.position = new Vector3(pacm.transform.position.x+step, pacm.transform.position.y, pacm.transform.position.z);

                 yield return new WaitForSeconds(0.001f);
            }
        

    }
    
    private void OnTriggerEnter(Collider collider)
    {
       // Debug.Log("TurninAround");
        if (collider.gameObject.tag == "TurningArea")
        {
           // Debug.Log("TurninAround");
            speed *= -1;


        }
         if(collider.gameObject.tag == "Player")
        {
          //  Debug.Log("Player!");
            playerMove2.instance.playerFly();
            playerMove2.instance.playerFall();
            LoseWinManager.instance.playerLose();
        }

    }
  
}
