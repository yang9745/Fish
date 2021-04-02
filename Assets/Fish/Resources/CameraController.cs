/*****************************
 * 
 * 鱼基类
 * 
 * ****************************/
using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Behaviors.Cursors;
using UnityEngine;
namespace TouchScript
{
    public class CameraController : MonoBehaviour
    {
        public CursorManager cursor;
      //  public Material material;
       public static bool b_CloseCursors = false;
       bool b_Cursor=false;
    
       
        #region   自己添加的事件
        private void Start()
        {
            //base.Start
            TouchManager.Instance.PointersPressed += pointersPressedHandler;
           // TouchManager.Instance.pointers += pointersAHandler;         
            cursor = GameObject.Find("Cursors").GetComponent<CursorManager>();
            Cursor.visible = false;


        }
      
     
           
        private void pointersPressedHandler(object sender, PointerEventArgs e)
        {        
            foreach (var pointer in e.Pointers)
            {              
                GetRay(pointer.Position);
            }
        
        }
     
        #endregion
        //按下后执行 隐藏
        private void Update()
        {

            if(Input.GetKeyDown(KeyCode.Alpha3)|| Input.GetKeyDown(KeyCode.Alpha2))
            {
                b_CloseCursors = !b_CloseCursors;
            }
          if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                b_Cursor = !b_Cursor;
                Cursor.visible = b_Cursor;
            }
        }
        public void GetRay(Vector2 v2)
        {
            Debug.Log("有执行");
            // Camera.main.

            Ray ray = Camera.main.ScreenPointToRay(v2);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 20);
            RaycastHit[] info;
            LayerMask mask = 1 << LayerMask.NameToLayer("Player");
            if ((info = Physics.RaycastAll(ray, 50, mask)) != null)
            {
                foreach (var item in info)
                    item.transform.gameObject.GetComponent<FishBase>().Going(item.point);
            }
        }
    }
}
