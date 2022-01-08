using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HandButton : MonoBehaviour {

    public Camera foreCamera; //前景摄像机
    public Transform handCursor;//手形图标
    public Text debugText;

    public EventSystem _mEventSystem;
    public GraphicRaycaster gra;
    List<RaycastResult> list;


    private List<RaycastResult> GraphicRaycaster(Vector2 pos)
    {
        var mPointerEventData = new PointerEventData(_mEventSystem);
        mPointerEventData.position = pos;
        List<RaycastResult> results = new List<RaycastResult>();

        gra.Raycast(mPointerEventData, results);
        return results;
    }
    // Use this for initialization
    void Start () {
        list = new List<RaycastResult>();
    }

    // Update is called once per frame
    void Update()
    {
      
        //手形图标选择按钮
        if (handCursor)
        {

            Vector3 jointScreenPos = foreCamera.WorldToScreenPoint(handCursor.transform.position);
            list = GraphicRaycaster(jointScreenPos);
            //debugText.text += item.gameObject.name;
            debugText.text ="list count:"+ list.Count;
            foreach (var item in list)
            {
                if (item.gameObject)
                {
                    debugText.text = item.gameObject.name;
                    item.gameObject.GetComponent<Button>().onClick.Invoke();
                    handCursor = null; //检测到碰撞后禁止重复检测
                }


            }
        }
    }


}
