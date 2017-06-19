using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public Vector3 m_vecDirection = new Vector3(1.0f, 0.0f, 0.0f);
    public float m_fSpeed = 5.0f;
    
	// Update is called once per frame
	void Update ()
    {
        this.transform.position += m_vecDirection * m_fSpeed * Time.deltaTime;
	}
}
