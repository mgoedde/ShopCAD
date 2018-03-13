using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class spawnPrefab : MonoBehaviour {

    public GameObject config;

    public Button btn;
    public GameObject part;
    public GameObject assembly;

    public Vector3 spawnPos;

	// Use this for initialization
	void Start () {

        spawnPos = config.GetComponent<config>().spawnPos;

        Button thisButton = btn.GetComponent<Button>();
        thisButton.onClick.AddListener(spawnPart);
	}
	
	void spawnPart()
    {
        Instantiate(part, spawnPos, assembly.transform.rotation, assembly.transform);
    }
}
