/*************************************
*
*版本：     V1.0.0
*创建人： 杨晓涛
*日期：    21/X/X
*作用：    未知
*描述：    未知
*
***********************************/
using System.Collections;
using System.Collections.Generic;
using TouchScript.InputSources;
using UnityEngine;

public class Tuio : MonoBehaviour
{

    TuioInput touchinput;
    bool b = true;
    private void Awake()
    {
        touchinput = GetComponent<TuioInput>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)|| Input.GetKeyDown(KeyCode.Alpha2))
        {
            b = !b;
            touchinput.enabled = b;
        }
    }
}
