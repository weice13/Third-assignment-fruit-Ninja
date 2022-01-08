using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour {
    private GestureTestListener gestureListener;

    // Use this for initialization
    void Start () {
        gestureListener = GestureTestListener.Instance;

    }

    // Update is called once per frame
    void Update () {
        //水平方向 
        float h = Input.GetAxis("Horizontal");
        //垂直方向
        float v = Input.GetAxis("Vertical");

        //移动 
        transform.Translate(Vector3.up * v * (3) * Time.deltaTime);
        transform.Translate(Vector3.right * h*20  * Time.deltaTime);
        //绕y轴旋转 
        transform.Rotate(Vector3.up * h * 120 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.Rotate(Vector3.up * 20, Space.World);
            transform.Translate(Vector3.forward * 2, Space.World);
        }

        if (gestureListener&&gestureListener.IsSwipeLeft())
        {
            transform.Rotate(Vector3.up * 20, Space.World);
        }
    }
}
