using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainObject : MonoBehaviour {

    public bool ascend { get; set; }
    public float objectSpeed { get; set; }

    // Use this for initialization
    void Start () {
        ascend = true;
	}
}
