using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private List<Transform> _enemyList = new List<Transform>();




    //Idle animation
    //Find Tagret
    //Look at target
    //Shoot
    //Bullets track enemies?


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.TryGetComponent<Enemy>(out Enemy _enemy))
            _enemyList.Add(_enemy.transform);
        
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.TryGetComponent<Enemy>(out Enemy _enemy))
            _enemyList.Remove(_enemy.transform);
    }
}
