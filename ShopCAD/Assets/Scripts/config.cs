using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class config : MonoBehaviour {

    //camera settings
    public float wheelSpeed = 2f;
    public float orbitSpeed = 1f;
    public float panSpeed = 2f;
    public int orbitKey = 1;
    public int panKey = 2;

    //spawn
    public Vector3 spawnPos = new Vector3 (0,0,0);
}
