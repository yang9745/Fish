/*************************************
*
*版本：     V1.0.0
*创建人： 杨晓涛
*日期：    21/4/2
*作用：   根据CameraController的静态布尔值，隐藏显示，插件的鼠标
*描述：    未知
*
***********************************/
using System.Collections;
using System.Collections.Generic;
using TouchScript;
using UnityEngine;

public class CloseCursors : MonoBehaviour
{
    public GameObject[] objs;
    void Start()
    {
        foreach(var item in objs)
        {
            item.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(CameraController.b_CloseCursors &&(objs[0].activeSelf==false))
        {
            foreach (var item in objs)
            {
                item.gameObject.SetActive(true);
            }
        }
        if (!CameraController.b_CloseCursors && (objs[0].activeSelf == true))
        {
            foreach (var item in objs)
            {
                item.gameObject.SetActive(false);
            }
        }
    }
}
