using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScrap : MonoBehaviour
{
    public bool TouchingScrap = false, HoldingScrap = false;

    public KeyCode PickupKey = KeyCode.F;

    [SerializeField] private List<Transform> scrapList = new List<Transform>();

    private Transform grabbedScrap;
    [SerializeField] private Transform player;





    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<Grabbable>(out Grabbable _grabbable))
            scrapList.Add(col.transform);

        CheckBool();
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.TryGetComponent<Grabbable>(out Grabbable _grabbable))
            scrapList.Remove(col.transform);

        CheckBool();
    }

    private void CheckBool()
    {
        //If list is != 0, touchingScrap is true
        TouchingScrap = scrapList.Count != 0;
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

        grabbedScrap = scrapList[0];
        grabbedScrap.SetParent(transform);
        grabbedScrap.GetComponent<Rigidbody2D>().simulated = false;
        grabbedScrap.GetComponent<BoxCollider2D>().enabled = false;
        grabbedScrap.position = transform.position;

        player.GetComponent<Rigidbody2D>().mass += grabbedScrap.GetComponent<Rigidbody2D>().mass;
    }



    private void DropScrap()
    {
        HoldingScrap = false;

        player.GetComponent<Rigidbody2D>().mass -= grabbedScrap.GetComponent<Rigidbody2D>().mass;
        grabbedScrap.SetParent(null);
        grabbedScrap.GetComponent<Rigidbody2D>().simulated = true;
        grabbedScrap.GetComponent<BoxCollider2D>().enabled = true;
    }
}
