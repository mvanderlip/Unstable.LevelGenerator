using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPath : MonoBehaviour {

    Vector3 m_start;
    Vector3 m_end;
    Dictionary<string, int> m_rotation = new Dictionary<string, int>();
    private bool done = false;


    private void Start()
    {
        m_start = transform.position;
        StartCoroutine(Track());
    }

    IEnumerator Track()
    {
        while (!done)
        {
            if (m_rotation.ContainsKey(transform.rotation.ToString()))
            {
                m_rotation[transform.rotation.ToString()] += 1;
            }
            else
            {
                m_rotation.Add(transform.rotation.ToString(), 0);
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void Print()
    {
        done = true;
        m_end = transform.position;
        Debug.Log(m_start);
        Debug.Log(m_end);
        foreach (var item in m_rotation)
        {
            Debug.Log(item);
        }
    }

    public void Complete()
    {
        done = true;
    }
}
