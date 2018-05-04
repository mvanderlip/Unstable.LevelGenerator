using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SerializeTests : MonoBehaviour {

	// Use this for initialization
	void Start () {

        string transformString = transform.position.ToString();
        File.WriteAllText("TestData.txt", transformString);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
