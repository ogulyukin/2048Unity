using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    [UsedImplicitly]
    public sealed class GameObjectsStorageView : MonoBehaviour
    {
        [FormerlySerializedAs("_fieldPrefab")] [SerializeField] private GameObject fieldPrefab;
        [FormerlySerializedAs("_parentObject")] [SerializeField] private Transform parentObject;
        [FormerlySerializedAs("_backgroundPrefab")] [SerializeField] private GameObject backgroundPrefab;
        [FormerlySerializedAs("_activeCubePrefab")] [SerializeField] private GameObject activeCubePrefab;
        [FormerlySerializedAs("_cubeColors")] [SerializeField] private List<Color> cubeColors;

        [SerializeField] private float actionCoefficient = 0.15f;

        public float ActionCoefficient => actionCoefficient;

        private Vector3[] _fieldCoordinates;
        private GameObject[] _activeCubes;
        private readonly Dictionary<int, Color> _colorsDictionary = new();
        
        public void Setup()
        {
            _fieldCoordinates = new Vector3[16];
            _activeCubes = new GameObject[16];
            var count = 0;
            Instantiate(backgroundPrefab, Vector3.zero, backgroundPrefab.transform.rotation, parentObject);
            
            for (var i = 4.38f; i > -5f; i -= 2.92f)
            {
                for (var j = -4.38f; j < 5f; j += 2.92f)
                {
                    var position = new Vector3(j, i, -0.5f);
                    Instantiate(fieldPrefab, position, fieldPrefab.transform.rotation , parentObject);
                    position.z = -0.6f;
                    _fieldCoordinates[count] = position;
                    count++;
                }
            }
            count = 0;
            for (var i = 2; i < 2049; i *= 2)
            {
                _colorsDictionary.Add(i, cubeColors[count]);
                count++;
            }
        }

        public void Clear()
        {
            _colorsDictionary.Clear();
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }

        public void InstantiateNewActiveCube(int position, int value)
        {
            var newActiveCube = Instantiate(activeCubePrefab, _fieldCoordinates[position], activeCubePrefab.transform.rotation, parentObject);
            _activeCubes[position] = newActiveCube;
            var view = newActiveCube.GetComponent<ActiveCubeView>();
            view.SetCubeText($"{value}");
            view.SetPanelColor(_colorsDictionary[value]);
            view.ChangeValueAnimation(actionCoefficient);
        }

        public void MoveActiveCube(int position, int target, float duration)
        {
            if (_activeCubes[position] == null)
            {
                throw new Exception($"ERROR! NO CUBE ENTITY FOUND AT {position}!");
            }
            
            var movedCube = _activeCubes[position];
            _activeCubes[target] = movedCube;
            _activeCubes[position] = null;
            _activeCubes[target].GetComponent<ActiveCubeView>().Move(_fieldCoordinates[target], duration * actionCoefficient);
        }

        public void DestroyActiveCube(int position, float timeout)
        {
            StartCoroutine(DestroyCoroutine(position, timeout * actionCoefficient));
        }

        private IEnumerator DestroyCoroutine(int position, float timeout)
        {
            var cubeToDestroy = _activeCubes[position];
            _activeCubes[position] = null;
            yield return new WaitForSeconds(timeout);
            cubeToDestroy.GetComponent<ActiveCubeView>().DestroyAnimation(actionCoefficient);
            Destroy(cubeToDestroy, actionCoefficient);
        }

        public void RaiseActiveCubeValue(int position, int value, float timeout)
        {
            StartCoroutine(RaiseValueCoroutine(position, value, timeout * actionCoefficient));
        }

        private IEnumerator RaiseValueCoroutine(int position, int value, float timeout)
        {
            yield return new WaitForSeconds(timeout);
            var view = _activeCubes[position]?.GetComponent<ActiveCubeView>();
            if (view == null) yield break;
            view.SetCubeText($"{value}");
            view.SetPanelColor(_colorsDictionary[value]);
            view.ChangeValueAnimation(actionCoefficient);
        }
    }
}
