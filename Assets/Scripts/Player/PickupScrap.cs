using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScrap : MonoBehaviour
{
    public bool TouchingScrap = false, HoldingScrap = false;
    public int _maxAmountOfScrapHeld = 1;
    private int _amountOfScrapHeld = 0;

    public KeyCode PickupKey = KeyCode.E, DropKey = KeyCode.F;

    [SerializeField] private List<Transform> _scrapList = new List<Transform>();

    [SerializeField] private List<Transform> _grabbedScrapList = new List<Transform>();
    [SerializeField] private Transform _player;
    [SerializeField] private LayerMask _scrapLayer, _environmentLayer;





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
        if (Input.GetKeyDown(PickupKey) && _amountOfScrapHeld < _maxAmountOfScrapHeld && TouchingScrap)
        {
            GrabScrap();
        }
        else if (Input.GetKeyDown(DropKey) && HoldingScrap)
        {
            DropScrap();
        }
    }


    private void GrabScrap()
    {
        HoldingScrap = true;
        _amountOfScrapHeld++;

        _grabbedScrapList.Add(_scrapList[0]);
        SpringJoint2D _joint = _scrapList[0].gameObject.AddComponent<SpringJoint2D>();
        _joint.connectedBody = _player.GetComponent<Rigidbody2D>();
        
        //Turns Layer's value from Binary to Numerical
        _scrapList[0].gameObject.layer = (int)Mathf.Log(_scrapLayer.value, 2); ;


        _scrapList.Remove(_scrapList[0]);
    }



    private void DropScrap()
    {
        _amountOfScrapHeld--;

        if (_amountOfScrapHeld == 0)
            HoldingScrap = false;

        Destroy(_grabbedScrapList[0].GetComponent<SpringJoint2D>());
        _grabbedScrapList[_grabbedScrapList.Count - 1].gameObject.layer = (int)Mathf.Log(_environmentLayer.value, 2); ;


        _grabbedScrapList.Remove(_grabbedScrapList[0]);
    }
}
