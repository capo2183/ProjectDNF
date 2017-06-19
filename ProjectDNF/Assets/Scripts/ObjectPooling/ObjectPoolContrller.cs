using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolContrller : MonoBehaviour
{
    public GameObject m_PooledPrefab;
    public int m_iPooledAmount = 20;
    public bool m_bIsExpand = true;

    private List<GameObject> m_PooledObjsList;
        
    // Use this for initialization
    public void Init()
    {
        if(m_PooledPrefab == null)
        {
            Debug.LogError("[Object Pool] Pooled object is null.");
            return;
        }

        m_PooledObjsList = new List<GameObject>();
        for(int i=0; i<m_iPooledAmount; i++)
        {
            GameObject _obj = Instantiate(m_PooledPrefab) as GameObject;
            _obj.transform.parent = this.transform;
            _obj.SetActive(false);
            m_PooledObjsList.Add(_obj);
        }
    }

    public GameObject Spawn()
    {
        GameObject retObj = Spawn(Vector3.zero, Quaternion.identity);
        return retObj;
    }

    public GameObject Spawn(Vector3 _pos, Quaternion _rot)
    {
        GameObject _retObj = null;
        for (int i=0; i<m_PooledObjsList.Count; i++)
        {
            _retObj = m_PooledObjsList[i];
            if (!_retObj.activeInHierarchy)
            {
                _retObj.SetActive(true);
                _retObj.transform.position = _pos;
                _retObj.transform.rotation = _rot;
                return _retObj;
            }
        }

        if (m_bIsExpand)
        {
            _retObj = Instantiate(m_PooledPrefab) as GameObject;
            _retObj.transform.parent = this.transform;
            _retObj.SetActive(false);
            _retObj.transform.position = _pos;
            _retObj.transform.rotation = _rot;
            m_PooledObjsList.Add(_retObj);
            return _retObj;
        }

        return _retObj;
    }

    public void DeSpawn(GameObject _go)
    {
        _go.SetActive(false);
    }
}

