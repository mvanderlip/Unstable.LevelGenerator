using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainFactory2 : MonoBehaviour {

    [SerializeField] private GameObject m_terrainObject;
    [SerializeField, Range(1, 1000)] float m_maxLength;
    [SerializeField, Range(1, 1000)] float m_maxWidth;
    [SerializeField, Range(0, 1)] float m_perlinStep;
    [SerializeField, Range(0, 10)] float m_perlinAmp;
    [SerializeField, Range(0, 50)] float m_terrainSpeed;
    [SerializeField, Range(0, 20)] float m_terrainSpeedVariance;
    [SerializeField] bool m_freezable = false;
    [SerializeField, Range(0, 1)] float m_perlinFilter;

    // Use this for initialization
    void Start()
    {
        for (int k = 0; k < m_maxLength; k++)
        {
            for (int j = 0; j < m_maxWidth; j++)
            {
                float perlin = Mathf.PerlinNoise(j * m_perlinStep, k * m_perlinStep) * m_perlinAmp;
                if (perlin < m_perlinFilter * m_perlinAmp)
                {
                    GameObject child = Instantiate(m_terrainObject, Vector3.right * ((j - m_maxWidth / 2) * m_terrainObject.transform.localScale.x) + Vector3.forward * ((k - m_maxLength / 2) * m_terrainObject.transform.localScale.z) + transform.position, Quaternion.identity, transform);
                    child.GetComponent<TerrainObject>().objectSpeed = m_terrainSpeed + 
                        m_terrainSpeed * perlin;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_freezable)
        {
            for (int k = 0; k < transform.childCount; k++)
            {
                TerrainObject child = transform.GetChild(k).GetComponent<TerrainObject>();
                float mod = 1;
                if (!child.ascend && child.transform.position.y > m_perlinAmp + transform.position.y + 1)
                {
                    mod = 0;
                }
                else if (child.ascend && child.transform.position.y < 0 + transform.position.y - 1)
                {
                    mod = 0;
                }
                if (child.transform.position.y > m_perlinAmp + transform.position.y)
                {
                    child.ascend = false;
                }
                else if (child.transform.position.y < 0 + transform.position.y)
                {
                    child.ascend = true;
                }
                
                child.transform.position = Vector3.right * child.transform.position.x + Vector3.forward * child.transform.position.z + (Vector3.up * (child.transform.position.y + Time.deltaTime * mod * child.objectSpeed * (m_perlinStep * (child.ascend ? 1 : -1))));
            }
        }


        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.F) && m_freezable)
        {
            for (int k = 0; k < transform.childCount; k++)
            {
                Rigidbody child = transform.GetChild(k).GetComponent<Rigidbody>();
                child.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
}
