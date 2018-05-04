using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCutOut : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C) && Input.GetKeyDown(KeyCode.X))
        {
            Transform[] renderers = GetComponentsInChildren<Transform>();
            for (int k = 0; k < renderers.Length; k++)
            {
                if (renderers[k].localPosition.y < 1.0f)
                {
                    renderers[k].gameObject.SetActive(false);
                }
            }
        }
	}
}
