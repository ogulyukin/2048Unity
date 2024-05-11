using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.UI
{
    [UsedImplicitly]
    public sealed class FieldStorageView : MonoBehaviour
    {
        [SerializeField] private GameObject _fieldPrefab;
        [SerializeField] private Transform _parentObject;
        [SerializeField] private GameObject _backgroundPrefab;
        [SerializeField] private GameObject _activeCubePrefab;

        private Vector3[] _fieldCoordinates;
        private GameObject[] _activeCubes;

        public void Setup()
        {
            _fieldCoordinates = new Vector3[16];
            _activeCubes = new GameObject[16];
            var count = 0;
            Instantiate(_backgroundPrefab, Vector3.zero, _backgroundPrefab.transform.rotation, _parentObject);
            
            for (var i = 4.38f; i > -5f; i -= 2.92f)
            {
                for (var j = -4.38f; j < 5f; j += 2.92f)
                {
                    var position = new Vector3(j, i, -0.5f);
                    Instantiate(_fieldPrefab, position, _fieldPrefab.transform.rotation , _parentObject);
                    position.z = -0.6f;
                    _fieldCoordinates[count] = position;
                    count++;
                }
            }
        }

        public void Clear()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }

        public void InstantiateNewActiveCube(int position, int value)
        {
            var newActiveCube = Instantiate(_activeCubePrefab, _fieldCoordinates[position], _activeCubePrefab.transform.rotation, _parentObject);
            _activeCubes[position] = newActiveCube;
            newActiveCube.GetComponent<ActiveCubeView>().SetCubeText($"{value}");
        }

        public void MoveActiveCube(int position, int target)
        {
            if (_activeCubes[position] == null)
            {
                throw new Exception($"ERROR! NO CUBE ENTITY FOUND AT {position}!");
            }
            
            var movedCube = _activeCubes[position];
            _activeCubes[target] = movedCube;
            _activeCubes[position] = null;
            movedCube.transform.position = _fieldCoordinates[target]; //this is temp
        }

        public void DestroyActiveCube(int position)
        {
            Destroy(_activeCubes[position]);
            _activeCubes[position] = null;
        }

        public void RiseActiveCubeValue(int position, int value)
        {
            _activeCubes[position].GetComponent<ActiveCubeView>().SetCubeText($"{value}");
        }
    }
}
