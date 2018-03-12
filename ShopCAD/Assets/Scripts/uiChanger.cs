using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class uiChanger : MonoBehaviour {

    public Button woodMatObj;  //the material buttons for each material
    public Button metalMatObj;
    public Button pvcMatObj;


    //the Spawn Buttons and Tool Buttons for each material
    public GameObject woodSp;
    public GameObject woodTool;

    public GameObject metalSp;
    public GameObject metalTool;

    public GameObject pvcSp;
    public GameObject pvcTool;


    public bool woodBool = false;
    public bool metalBool = false;
    public bool pvcBool = false;

    // Use this for initialization
    void Start () {

        Button woodMat = woodMatObj.GetComponent<Button>();
        Button metalMat = metalMatObj.GetComponent<Button>();
        Button pvcMat = pvcMatObj.GetComponent<Button>();

        
        woodMat.onClick.AddListener(woodSwitch);
        metalMat.onClick.AddListener(metalSwitch);
        pvcMat.onClick.AddListener(pvcSwitch);

        woodSp.SetActive(woodBool);
        woodTool.SetActive(woodBool);

        metalSp.SetActive(metalBool);
        metalTool.SetActive(metalBool);

        pvcSp.SetActive(pvcBool);
        pvcTool.SetActive(pvcBool);
    }
	
	// Update is called once per frame
	void Update () {
        woodSp.SetActive(woodBool);
        woodTool.SetActive(woodBool);

        metalSp.SetActive(metalBool);
        metalTool.SetActive(metalBool);

        pvcSp.SetActive(pvcBool);
        pvcTool.SetActive(pvcBool);
    }
    
    void stateSwitch(ref bool selection)
    {
        woodBool = false;
        metalBool = false;
        pvcBool = false;

        selection = true;
    }

    void woodSwitch()
    {
        stateSwitch(ref woodBool);
    }
    
    void metalSwitch()
    {
        stateSwitch(ref metalBool);
    }

    void pvcSwitch()
    {
        stateSwitch(ref pvcBool);
    }
}
