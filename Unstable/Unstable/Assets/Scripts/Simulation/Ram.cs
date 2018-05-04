using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ram : MonoBehaviour {

    [SerializeField] Vector3 m_velocity;
    private Rigidbody m_rigidbody;
	// Use this for initialization
	void Start () {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.velocity = m_velocity;
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
