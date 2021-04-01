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
        bool b = false;
        bool b2 = false;
        private void Awake()
        {
           
          
        }
       
        #region   自己添加的事件
        private void Start()
        {
            //base.Start
            TouchManager.Instance.PointersPressed += pointersPressedHandler;
            TouchManager.Instance.PointersAdded += pointersAHandler;
            TouchManager.Instance.FrameStarted += Tstart;
            cursor = GameObject.Find("Cursors").GetComponent<CursorManager>();

           
        }

        private void Tstart(object sender, EventArgs e)
        {
            try
            {
                cursor.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                cursor.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
            catch
            {
            }
        }

        private void pointersPressedHandler(object sender, PointerEventArgs e)
        {
            foreach (var pointer in e.Pointers)
            {

                GetRay(pointer.Position);
            }
        }
        private void pointersAHandler(object sender, PointerEventArgs e)
        {
            foreach (var pointer in e.Pointers)
            {

                GetRay(pointer.Position);
            }
        }
        #endregion

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha3)|| Input.GetKeyDown(KeyCode.Alpha4)||Input.GetKeyDown(KeyCode.Alpha5))
            {
                b = !b;
                if (b)
                {
                    cursor.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                   
                }
                else
                {
                    cursor.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    try
                    {
                        cursor.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    }
                    catch
                    {
                    }
                }
               
            }
            if(Input.GetMouseButtonDown(1))
            {
              //  if (b)              
              //      material.color = new Color(0, 0, 0, 1);
              //else
              //      material.color = new Color(1, 1, 1, 0);
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
