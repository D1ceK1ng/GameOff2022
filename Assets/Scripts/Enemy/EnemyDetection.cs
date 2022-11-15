using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private enum _priorityList
    {
        Player,
        Rocket,
        Turret
    }

    [SerializeField] private _priorityList _priority;



    private void OnTriggerEnter2D(Collider2D col)
    {
        if(GetComponent<Enemy>().Target == null)
        {
            if (_priority == _priorityList.Player && col.transform.TryGetComponent<Player>(out Player playerScript) ||
              _priority == _priorityList.Rocket && col.transform.TryGetComponent<Rocket>(out Rocket rocketScript) ||
              _priority == _priorityList.Turret && col.transform.TryGetComponent<Turret>(out Turret turretScript))
            {
                GetComponent<Enemy>().Target = col.transform;
            }
        }
    }
}
