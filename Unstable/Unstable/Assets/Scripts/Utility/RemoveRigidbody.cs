using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRigidbody : MonoBehaviour {

    private Rigidbody[] rigidbodies;
    private TrackPath[] m_paths;
	// Use this for initialization
	void Start () {
        StartCoroutine(LateStart());
	}

    IEnumerator LateStart()
    {
        yield return new WaitForEndOfFrame();
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        m_paths = GetComponentsInChildren<TrackPath>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F) && Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(LazyDestroy());
        }
	}

    IEnumerator LazyDestroy()
    {
        int i = 0;
        foreach (Rigidbody item in rigidbodies)
        {
            Destroy(item);
            ++i;
            if (i == 100)
            {
                yield return new WaitForEndOfFrame();
            }
        }
        foreach(TrackPath item in m_paths)
        {
            item.Complete();
        }
    }
}
