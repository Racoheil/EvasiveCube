using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeControl : MonoBehaviour
{
   
        public Transform target;
    [SerializeField] float smoothSpeed = 0.125f;
        //public Vector3 offset;
       [SerializeField] bool isMove;
        public static KnifeControl instance;
        float height = 6f;
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

        
        }
       
        //private void LateUpdate()
        //{
        //    if (isMove)
        //    {
        //       desiredPosition = this.gameObject.transform.position;
        //       desiredPosition.z = target.position.z;
        //       Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //    transform.position = smoothedPosition;
        //    //  Vector3 desiredPosition.position.y = target.position.y;
        //    // Vector3 desiredPosition = target.position + offset;
        //    //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //    //transform.position = smoothedPosition;
        //    //transform.LookAt(target);
        //    }
        //}

    void knifeMove()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
        //   pacm.transform.Tr
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


}
