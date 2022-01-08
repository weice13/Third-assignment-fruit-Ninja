using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startScene : MonoBehaviour {

    public Button btn1;
    public Button btn2;
    public Button btn3;
    public GameObject panel;
    float angle = 2f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (btn1)
        {
            btn1.GetComponent<Transform>().Rotate(Vector3.forward, angle);
            btn2.GetComponent<Transform>().Rotate(Vector3.forward, angle);
            btn3.GetComponent<Transform>().Rotate(Vector3.forward, angle);
        }
        //btn.transform.Rotate(Vector3.forward, angle);
    }

    public void OnNewGame()
    {
        SceneManager.LoadScene("game2");
    }

    public void OnGameTips()
    {
        if (panel)
        {
            panel.SetActive(true);
            Invoke("ExitGameTips", 3f);
        }
    }
    public void ExitGameTips()
    {

        if (panel)
        {
            panel.SetActive(false);

        }

    }

    public void OnGameExit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                        Application.Quit();
        #endif
    }
}
