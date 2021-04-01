/*************************************
*
*版本：     V1.0.0
*创建人： 杨晓涛
*日期：    21/4/1
*作用：    测试事件
*描述：    未知
*
***********************************/
using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript;
using UnityEngine;

public class TestEvent : MonoBehaviour
{
   
    void Start()
    {
        //就执行了一次
        TouchManager.Instance.PointersAdded += Handler1;

        TouchManager.Instance.PointersCancelled += Handler2;
        //按下执行一次
        TouchManager.Instance.PointersPressed += Handler3;
        //抬起执行一次
        TouchManager.Instance.PointersReleased += Handler4;

        TouchManager.Instance.PointersRemoved += Handler5;
        //鼠标移动了就执行一次
        TouchManager.Instance.PointersUpdated += Handler6;
        //每帧都执行
        TouchManager.Instance.FrameFinished += Handler7;
        //每帧都执行
        TouchManager.Instance.FrameStarted += Handler8;

       
    }
    private void OnEnable()
    {
        //就执行了一次
        TouchManager.Instance.PointersAdded -= Handler1;

        TouchManager.Instance.PointersCancelled -= Handler2;
        //按下执行一次
        TouchManager.Instance.PointersPressed -= Handler3;
        //抬起执行一次
        TouchManager.Instance.PointersReleased -= Handler4;

        TouchManager.Instance.PointersRemoved -= Handler5;
        //鼠标移动了就执行一次
        TouchManager.Instance.PointersUpdated -= Handler6;
        //每帧都执行
        TouchManager.Instance.FrameFinished -= Handler7;
        //每帧都执行
        TouchManager.Instance.FrameStarted -= Handler8;
    }
    private void Update()
    {
        
    }
    private void Handler1(object sender, PointerEventArgs e)
    {
        Debug.Log("1:PointersAdded");
        foreach (var pointer in e.Pointers)
        {

          
        }
    }
    private void Handler2(object sender, PointerEventArgs e)
    {
        Debug.Log("2:PointersCancelled");
        foreach (var pointer in e.Pointers)
        {


        }
    }
    private void Handler3(object sender, PointerEventArgs e)
    {
        Debug.Log("3:PointersPressed");
        foreach (var pointer in e.Pointers)
        {


        }
    }
    private void Handler4(object sender, PointerEventArgs e)
    {
        Debug.Log("4:PointersReleased");
        foreach (var pointer in e.Pointers)
        {


        }
    }
    private void Handler5(object sender, PointerEventArgs e)
    {
        Debug.Log("5:PointersRemoved");
        foreach (var pointer in e.Pointers)
        {


        }
             
    }
    private void Handler6(object sender, PointerEventArgs e)
    {
       
        Debug.Log("6:PointersUpdated");
        foreach (var pointer in e.Pointers)
        {


        }
    }
    private void Handler7(object sender, EventArgs e)
    {
        Debug.Log("7:FrameFinished");
       
    }
    private void Handler8(object sender, EventArgs e)
    {
        Debug.Log("8:FrameStarted");
         
      
    }
}
