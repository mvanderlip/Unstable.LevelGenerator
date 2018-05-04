using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spill : MonoBehaviour {

    [SerializeField] GameObject m_object;
    [SerializeField, Range(1, 1000)] int m_numObjects;
    [SerializeField, Range(0, 10.0f)] float m_delay;

	// Use this for initialization
	void Start () {
        StartCoroutine(GenerateObjects());
	}
	
    IEnumerator GenerateObjects()
    {
        for (int k = 0; k < m_numObjects; k++)
        {
            Instantiate(m_object, transform.position + (Vector3.forward * Random.insideUnitCircle.y + Vector3.right * Random.insideUnitCircle.x) * 200.0f,Quaternion.identity,transform);
            yield return new WaitForSeconds(m_delay);
        }
    }
}
