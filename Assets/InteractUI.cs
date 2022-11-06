using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    private Vector3 _cachedPos;

    [SerializeField] private Vector3 _posOffset = new Vector3(0, 0.4f, 0);
    [SerializeField] private GameObject _ui, _canvas;
    private GameObject _spawnedUI;
    private PickupScrap _pickupScript;
    private bool _uiIsAlive = false;


    private void Start()
    {
        _pickupScript = GetComponent<PickupScrap>();
    }

    void Update()
    {
        if (_pickupScript.ScrapList.Count == 0)
        {
            if (_uiIsAlive) DestroyUI();
            return;
        }
        


        if (_uiIsAlive)
        {
            UIPosition();
        }

        else
        {
            SpawnUI();
        }
    }




    private void SpawnUI()
    {
        _uiIsAlive = true;
        _spawnedUI = Instantiate(_ui, _pickupScript.ScrapList[0].position, Quaternion.identity);
        _spawnedUI.transform.SetParent(_canvas.transform);
    }


    private void UIPosition()
    {
        _cachedPos = _pickupScript.ScrapList[0].position;
        Vector3 offset = new Vector3(0, _pickupScript.ScrapList[0].localScale.y + _posOffset.y, 0);
        _spawnedUI.transform.position = Camera.main.WorldToScreenPoint(_cachedPos + offset);
    }

    private void DestroyUI()
    {
        Destroy(_spawnedUI);
        _uiIsAlive = false;
    }
}
