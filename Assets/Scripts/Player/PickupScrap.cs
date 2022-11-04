using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScrap : MonoBehaviour
{
    

    [SerializeField]private KeyCode _pickupKey = KeyCode.F;
    [SerializeField] private List<Transform> _scrapList = new List<Transform>();
    [SerializeField] private Transform _player;
    private Transform _grabbedScrap;
    private bool _touchingScrap, _holdingScrap;




    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<Grabbable>(out Grabbable grabbable))
            _scrapList.Add(col.transform);

        CheckBool();
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.TryGetComponent<Grabbable>(out Grabbable grabbable))
            _scrapList.Remove(col.transform);

        CheckBool();
    }

    private void CheckBool()
    {
        //If list is != 0, touchingScrap is true
        _touchingScrap = _scrapList.Count != 0;
    }





    private void Update()
    {
        if (Input.GetKeyDown(_pickupKey) && !_holdingScrap && _touchingScrap)
        {
            GrabScrap();
        }
        else if (Input.GetKeyDown(_pickupKey) && _holdingScrap)
        {
            DropScrap();
        }
    }


    private void GrabScrap()
    {
        _holdingScrap = true;

        _grabbedScrap = _scrapList[0];
        _grabbedScrap.SetParent(transform);
        _grabbedScrap.GetComponent<Rigidbody2D>().simulated = false;
        _grabbedScrap.GetComponent<BoxCollider2D>().enabled = false;
        _grabbedScrap.position = transform.position;

        _player.GetComponent<Rigidbody2D>().mass += _grabbedScrap.GetComponent<Rigidbody2D>().mass;
    }



    private void DropScrap()
    {
        _holdingScrap = false;

        _player.GetComponent<Rigidbody2D>().mass -= _grabbedScrap.GetComponent<Rigidbody2D>().mass;
        _grabbedScrap.SetParent(null);
        _grabbedScrap.GetComponent<Rigidbody2D>().simulated = true;
        _grabbedScrap.GetComponent<BoxCollider2D>().enabled = true;
    }
}
