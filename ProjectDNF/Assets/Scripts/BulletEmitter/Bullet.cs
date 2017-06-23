using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public Vector3 m_vecDirection = new Vector3(1.0f, 0.0f, 0.0f);
    public float m_fSpeed = 10.0f;
    
    private void Start()
    {
        StartCoroutine(DestorySelf());
    }

    // Update is called once per frame
    private void Update ()
    {
        this.transform.position += m_vecDirection * m_fSpeed * Time.deltaTime;
	}

    private IEnumerator DestorySelf()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy();
    }

    private void Destroy()
    {
        this.gameObject.SetActive(false);
    }
}
