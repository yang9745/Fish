/*************************************
*
*版本：     V1.0.0
*创建人： 杨晓涛
*日期：    21/X/X
*作用：    未知
*描述：    未知
*
***********************************/
//点击鼠标产生波纹
using System.Collections;
using System.Collections.Generic;
using TouchScript;
using UnityEngine;
using UnityEngine.UI;

public class AddRipper : MonoBehaviour
{
    public Camera mainCamera;
    public Shader shader;
    public RipperPostEffect components;
    float t = 0;
    Vector2 v2=Vector2.zero;
    Vector2 v3 = Vector2.zero;
  
    bool b = false;
    bool start = false;
    private void Awake()
    {
        components = transform.GetComponent<RipperPostEffect>();
        TouchManager.Instance.PointersPressed += pointersPressedHandler;
      //  TouchManager.Instance.PointersAdded += pointersAHandler;
        TouchManager.Instance.PointersUpdated += pointersAHandler;
        TouchManager.Instance.PointersReleased += Cancelled;

    }
   private void Cancelled(object sender, PointerEventArgs e)
    {
        start = false;
    }
    private void pointersPressedHandler(object sender, PointerEventArgs e)
    {
        start = true;
        foreach (var pointer in e.Pointers)
        {
           
            v3 = pointer.Position - v2;
            v2 = pointer.Position;
            RipperPostEffect r = MyStack.Instance.GetObject(transform);
            r.shader = shader;
            r.vector4 = new Vector4(v3.x, v3.y, 0, 0);
            r.startPos = new Vector4(pointer.Position.x / Screen.width, pointer.Position.y / Screen.height, 0, 0);

        }
    }
    private void pointersAHandler(object sender, PointerEventArgs e)
    {
        if (!b|| !start)
            return;
        b = false;
        
        foreach (var pointer in e.Pointers)
        {
           
            v3 = pointer.Position - v2;
            v2 = pointer.Position;
            RipperPostEffect r = MyStack.Instance.GetObject(transform);
            r.shader = shader;
            r.vector4 = new Vector4(v3.x, v3.y, 0, 0);
            r.startPos = new Vector4(pointer.Position.x / Screen.width, pointer.Position.y / Screen.height, 0, 0);

        }
    }
        void Update()
    {
      
        t += Time.deltaTime;
        if (t <0.15f)
        {           
            return;
        }
        t = 0;
        b = true;
       //if(Input.GetMouseButton(0))
       //     text.text += "有鼠标";
       //     v3 =  (Vector2)Input.mousePosition-v2;
       //     v2 = Input.mousePosition;
       //    RipperPostEffect r= MyStack.Instance.GetObject( transform);
           
       //     r.shader = shader;
       //     r.vector4 = new Vector4( v3.x,v3.y,0,0);
         
       //     r.startPos = new Vector4(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height, 0, 0);
           
     
    }
  
}
