using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScrap : MonoBehaviour
{
    public bool TouchingScrap = false, HoldingScrap = false;
    public int _maxAmountOfScrapHeld = 1;
    private int _amountOfScrapHeld = 0;

    public KeyCode PickupKey = KeyCode.E, DropKey = KeyCode.F;

    public List<Transform> ScrapList = new List<Transform>();

    public List<Transform> GrabbedScrapList = new List<Transform>();
    [SerializeField] private Transform _player;
    [SerializeField] private LayerMask _scrapLayer, _environmentLayer;





    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<Rubbish>(out Rubbish _grabbable))
            ScrapList.Add(col.transform);
        CheckBool();

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.TryGetComponent<Rubbish>(out Rubbish _grabbable))
            ScrapList.Remove(col.transform);
        CheckBool();

    }

    private void CheckBool()
    {
        //If list is != 0, touchingScrap is true
        TouchingScrap = ScrapList.Count != 0;
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

        GrabbedScrapList.Add(ScrapList[0]);
        SpringJoint2D _joint = ScrapList[0].gameObject.AddComponent<SpringJoint2D>();
        _joint.connectedBody = _player.GetComponent<Rigidbody2D>();

        //Turns Layer's value from Binary to Numerical
        ScrapList[0].gameObject.layer = (int)Mathf.Log(_scrapLayer.value, 2);


        ScrapList.Remove(ScrapList[0]);
    }



    private void DropScrap()
    {
        _amountOfScrapHeld--;

        if (_amountOfScrapHeld == 0)
            HoldingScrap = false;

        int i = GrabbedScrapList.Count - 1;

        Destroy(GrabbedScrapList[i].GetComponent<SpringJoint2D>());
        GrabbedScrapList[i].gameObject.layer = (int)Mathf.Log(_environmentLayer.value, 2); ;


        GrabbedScrapList.Remove(GrabbedScrapList[i]);
    }
}