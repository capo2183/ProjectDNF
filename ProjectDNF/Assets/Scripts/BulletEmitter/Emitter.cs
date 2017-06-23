using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    public GameObject m_BulletPooledPrefab;
    public GameObject m_TargetObjPoolRoot;
    public int m_iPooledAmount = 20;

    [Space(10)]
    public float m_fInterval = 1f;

    private ObjectPoolContrller m_ObjPool;
        
    // Use this for initialization
    void Start ()
    {
        GameObject _ObjRoot = new GameObject();
        _ObjRoot.transform.localPosition = Vector3.zero;
        _ObjRoot.transform.localScale = Vector3.one;
        _ObjRoot.name = "ObjectPool";

        if (m_TargetObjPoolRoot != null)
            _ObjRoot.transform.parent = m_TargetObjPoolRoot.transform;
        else
            _ObjRoot.transform.parent = this.transform;

        if (_ObjRoot.GetComponent<ObjectPoolContrller>() == null)
            m_ObjPool = _ObjRoot.AddComponent<ObjectPoolContrller>();
        
        m_ObjPool.m_PooledPrefab = m_BulletPooledPrefab;
        m_ObjPool.m_iPooledAmount = m_iPooledAmount;
        m_ObjPool.m_bIsExpand = true;

        m_ObjPool.Init();

        StartCoroutine(Emit());
    }
	
    private IEnumerator Emit()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_fInterval);
            m_ObjPool.Spawn(this.transform.localPosition, this.transform.localRotation);
        }
    }

    public void OnDespawn(Bullet _bt)
    {
        m_ObjPool.DeSpawn(_bt.gameObject);
    }
}
