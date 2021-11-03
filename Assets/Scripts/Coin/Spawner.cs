using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _coinPoints;
    [SerializeField] private GameObject _coinPrefab;


    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < _coinPoints.Length; i++)
        {
            Instantiate(_coinPrefab, _coinPoints[i]);
        }
    }
}
