using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SetSerialize : MonoBehaviour {

    [SerializeField] private Vector3 lerp;

    private Vector3 readPos;

	// Use this for initialization
	void Start () {
        string[] transformString = File.ReadAllLines("TestData.txt");
        string position = transformString[0].Substring(1, transformString[0].Length - 2);
        string[] sposition = position.Split(',');
        Vector3 vposition = new Vector3(float.Parse(sposition[0]), float.Parse(sposition[1]), float.Parse(sposition[2]));
        readPos = vposition;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, readPos, Time.deltaTime);
	}
}
