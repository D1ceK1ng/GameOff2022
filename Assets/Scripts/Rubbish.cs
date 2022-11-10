using UnityEngine;

public class Rubbish : MonoBehaviour
{
    [SerializeField]private int _scrapValue;
    public int ScrapValue { get => _scrapValue; set => _scrapValue = value; }
}
