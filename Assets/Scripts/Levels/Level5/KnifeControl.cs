using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeControl : MonoBehaviour
{
   
        public Transform target;
    [SerializeField] float smoothSpeed = 0.125f;
        //public Vector3 offset;
       [SerializeField] bool isMove;
       [SerializeField] bool isCut;
        public static KnifeControl instance;
        float height = 8f;
        float tablePosition = 2.85f;
    [SerializeField] float speed = 10f;
    Vector3 desiredPosition;
        private void Awake()
        {
            instance = this;
        Vector3 knifePosition = this.gameObject.transform.position;
        knifePosition.y = height;
            this.gameObject.transform.position = knifePosition;
        

        }
        void Start()
        {
        isMove = true;
        StartCoroutine("knifeMoveCoroutine");
        StartCoroutine(knifeCutCoroutine());

        
        }
       
    public void addSpeed(float value)
    {
        smoothSpeed += value;
    }


 
    IEnumerator knifeMoveCoroutine()
    {

        while (isMove)
        {

            desiredPosition = this.gameObject.transform.position;
            desiredPosition.z = target.position.z;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            yield return new WaitForSeconds(0.001f);
        }


    }
    IEnumerator knifeCutCoroutine()
    {
        while (isCut)
        {
            yield return new WaitForSecondsRealtime(UnityEngine.Random.Range(7, 10));

          //   StopCoroutine("knifeMoveCoroutine");
           isMove = false;
                 StartCoroutine(knifeDownCoroutine());
               

        }
     }
    IEnumerator knifeDownCoroutine()
    {
        StopCoroutine(knifeCutCoroutine());
        while (transform.position.y!= tablePosition)
        {
            //isCut = false;
            desiredPosition = this.gameObject.transform.position;
            desiredPosition.y = tablePosition;
            Vector3 smoothedPosition = Vector3.MoveTowards(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            yield return new WaitForSeconds(0.001f);
        }
        Debug.Log("Дошел до доски");
        StartCoroutine(knifeUpCoroutine());
        
    }
    IEnumerator knifeUpCoroutine()
    {
        //
      //  StopCoroutine(knifeDownCoroutine());
        
        while (transform.position.y!=height)
        {
            
            desiredPosition = this.gameObject.transform.position;
            desiredPosition.y = height;
            Vector3 smoothedPosition = Vector3.MoveTowards(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            yield return new WaitForSeconds(0.001f);
        }
        Debug.Log("Вернулся на орбиту");
        isMove = true;
        StartCoroutine("knifeMoveCoroutine");
        


    }
    private void OnTriggerEnter(Collider collider)
    {
       
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Player!");
            
        }

    }
}
