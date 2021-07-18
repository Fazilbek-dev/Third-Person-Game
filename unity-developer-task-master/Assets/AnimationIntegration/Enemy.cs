using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animtorRagdoll;
    [SerializeField] private Transform _respawnPoint;

    private void Update()
    {
        if(_animtorRagdoll.enabled == false)
        {
            Quest._quest2 = true;
            StartCoroutine(Respawn());
        }
    }
    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5f);
        this.transform.position = _respawnPoint.transform.position;
        _animtorRagdoll.enabled = true;
    }
}
