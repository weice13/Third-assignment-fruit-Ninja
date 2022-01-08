using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseController : MonoBehaviour {
    public GameObject fruitObject; //
    public Transform overlayObject;
    public Camera foreCamera;

    public GameObject leftHalf;
    public GameObject rightHalf;

    // Use this for initialization
    void Start () {
        leftHalf.SetActive(false);
        rightHalf.SetActive(false);
 
    }

    // Update is called once per frame
    void Update () {
        //1.获取前景摄像机与手形图标之间的z向距离zdistance
        //float zdistance = overlayObject.position.z - foreCamera.transform.position.z;
        
        //2.获取鼠标当前位置，并将距离摄像机的z值设置为以上的zdistance
        //Vector3 worldPos = foreCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zdistance));
       // overlayObject.position = worldPos;

     
        //3.建立forecamera与鼠标位置点之间的射线ray，距离无穷远
		Ray ray = foreCamera.ScreenPointToRay(foreCamera.WorldToScreenPoint(overlayObject.position));

        //4.射线ray如果穿透碰撞体collider，则让水果坠落
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            fruitObject.GetComponent<Rigidbody>().useGravity = true;
            leftHalf.transform.position = fruitObject.transform.position;
            rightHalf.transform.position = fruitObject.transform.position;
            fruitObject.SetActive(false);
            leftHalf.SetActive(true);
            rightHalf.SetActive(true);

            leftHalf.GetComponent<Rigidbody>().AddForce(new Vector3(-100, 100, 0));
            rightHalf.GetComponent<Rigidbody>().AddForce(new Vector3(100, 100, 0));

            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("splatter");
            GetComponent<AudioSource>().Play();

        }

    }
}
