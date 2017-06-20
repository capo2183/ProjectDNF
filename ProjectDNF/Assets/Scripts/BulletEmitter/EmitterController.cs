using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterController : MonoBehaviour
{
    public GameObject m_BulletPooledPrefab;
    public int m_iPooledAmount = 20;

    [Space(10)]
    public float m_fInterval = 1f;

    private ObjectPoolContrller m_ObjPool;

    void Awake()
    {
        RegisterDelegateFunction();
    }

    void OnDestroy()
    {
        UnregisterDelegateFunction();
    }

    private void RegisterDelegateFunction()
    {
        Bullet.OnDespawn += OnDespawn;
    }

    private void UnregisterDelegateFunction()
    {
        Bullet.OnDespawn -= OnDespawn;
    }

    // Use this for initialization
    void Start ()
    {
        GameObject m_ObjPoolRoot = new GameObject();
        m_ObjPoolRoot.transform.parent = this.transform;
        m_ObjPoolRoot.name = "ObjectPool";

        m_ObjPool = m_ObjPoolRoot.AddComponent<ObjectPoolContrller>();
        
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
            m_ObjPool.Spawn();
        }
    }

    public void OnDespawn(Bullet _bt)
    {
        m_ObjPool.DeSpawn(_bt.gameObject);
    }
}
