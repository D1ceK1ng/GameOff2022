using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScrap : MonoBehaviour
{
    public bool TouchingScrap = false, HoldingScrap = false;

    public KeyCode PickupKey = KeyCode.F;

    [SerializeField] private List<Transform> _scrapList = new List<Transform>();

    private Transform _grabbedScrap;
    [SerializeField] private Transform _player;





    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<Grabbable>(out Grabbable _grabbable))
            _scrapList.Add(col.transform);

        CheckBool();
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.TryGetComponent<Grabbable>(out Grabbable _grabbable))
            _scrapList.Remove(col.transform);

        CheckBool();
    }

    private void CheckBool()
    {
        //If list is != 0, touchingScrap is true
        TouchingScrap = _scrapList.Count != 0;
    }





    private void Update()
    {
        if (Input.GetKeyDown(PickupKey) && !HoldingScrap && TouchingScrap)
        {
            GrabScrap();
        }
        else if (Input.GetKeyDown(PickupKey) && HoldingScrap)
        {
            DropScrap();
        }
    }


    private void GrabScrap()
    {
        HoldingScrap = true;

        _grabbedScrap = _scrapList[0];
        _grabbedScrap.SetParent(transform);
        _grabbedScrap.GetComponent<Rigidbody2D>().simulated = false;
        _grabbedScrap.GetComponent<BoxCollider2D>().enabled = false;
        _grabbedScrap.position = transform.position;

        _player.GetComponent<Rigidbody2D>().mass += _grabbedScrap.GetComponent<Rigidbody2D>().mass;
    }



    private void DropScrap()
    {
        HoldingScrap = false;

        _player.GetComponent<Rigidbody2D>().mass -= _grabbedScrap.GetComponent<Rigidbody2D>().mass;
        _grabbedScrap.SetParent(null);
        _grabbedScrap.GetComponent<Rigidbody2D>().simulated = true;
        _grabbedScrap.GetComponent<BoxCollider2D>().enabled = true;
    }
}
