using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class uiChanger : MonoBehaviour {

    public Button woodMat;  //the material buttons for each material
    public Button metalMat;
    public Button pvcMat;

    public GameObject woodSpPan; //the spawn panel for each material
    public GameObject metalSpPan;
    public GameObject pvcSpPan;
           
    public GameObject woodToolPan; //the tool panel for each material
    public GameObject metalToolPan;
    public GameObject pvcToolPan;

    // Use this for initialization
    void Start () {
        woodSpPan.SetActive(true);
        metalSpPan.SetActive(false);
        pvcSpPan.SetActive(false);

        woodToolPan.SetActive(true);
        metalToolPan.SetActive(false);
        pvcToolPan.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

    }                                              
}
