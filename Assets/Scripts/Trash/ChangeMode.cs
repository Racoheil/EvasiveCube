using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMode : MonoBehaviour
{
    //private float[] jumpForces=new float[12] { 2.584685f,3.6111f,4.33331f,5.41543f,5.909055f,6.49841f,6.511112f,7.22217f,8.12164f,8.124933f,9.28105f,9.28563f};
    //private float[] gravitations = new float[12] { -9.81f,-19.62f, -28f,-42f, -52f,-60, -64f,-78, -90f,-100f, -115f,-125f };
    public static ChangeMode instance;
    [SerializeField] bool isChange=true;
    
    [SerializeField] public int mode=0;
    [SerializeField] int maxMode = 5;
    public float[] drags;
    public float[] waitTimes;
    public bool isFirstLevel = true;
    public bool isSecondLevel = false;

    void Start()
    {
        drags = new float[6] { 10, 8, 6, 4, 0, 0 };
        waitTimes = new float[6] { 1f, 0.98f, 0.96f, 0.94f, 92f, 90f };
        instance = this;
    if(isChange)StartCoroutine("changeModeCoroutine");

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {

            changeMode(mode);

        }
    }
    public void changeMode(int mode)
    {

        //playerMove.instance.jumpForce = jumpForces[mode];
        playerMove2.instance.speed = playerMove2.instance.speeds[mode];
        //BombControl.instance.rb.drag = drags[mode];
        if (isFirstLevel) { BombsGenerate.instance.currentDrag = drags[mode]; }
        else if (isSecondLevel) { CellsHeat.instance.waitTime = waitTimes[mode]; }

            //Physics.gravity = new Vector3(0, gravitations[mode], 0);
            Debug.Log("Mode changed on " + mode);
    }
    IEnumerator changeModeCoroutine()
    {
        Debug.Log("Timer started");
        while (mode<maxMode)
        {
          //  if (mode > maxMode) { StopCoroutine("changeModeCoroutine"); yield break; }
            //if (playerMove.instance.IsGrounded == true)
            //{
            //    changeMode(mode);

            //}
            //else
            //{
            //    StartCoroutine(waitForChangeMode(mode));
            //}

            changeMode(mode);
            yield return new WaitForSeconds(10f);
            mode++;
        }


    }
    //IEnumerator waitForChangeMode(int mode)
    //{
    //    while (true)
    //    {
    //        if (playerMove.instance.IsGrounded == false)
    //        {
    //            yield return new WaitForSeconds(waitFor);
    //        }
    //        else
    //        {
    //            changeMode(mode);
    //          //  Debug.Log("Mode changed on "+mode);
    //            yield break;
    //        }
    //    }
    //}
    public void StopCoroutine()
    {
        StopCoroutine(changeModeCoroutine());
        StopAllCoroutines();
    }

}
