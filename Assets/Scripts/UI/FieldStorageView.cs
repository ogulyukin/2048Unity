using System;
using System.Collections;
using System.Collections.Generic;
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
        [SerializeField] private List<Color> _cubeColors;

        private const float ActionCoefficient = 0.15f;

        private Vector3[] _fieldCoordinates;
        private GameObject[] _activeCubes;
        private readonly Dictionary<int, Color> _colorsDictionary = new();

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

            count = 0;
            for (var i = 2; i < 2049; i *= 2)
            {
                _colorsDictionary.Add(i, _cubeColors[count]);
                count++;
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
            var view = newActiveCube.GetComponent<ActiveCubeView>();
            view.SetCubeText($"{value}");
            view.SetPanelColor(_colorsDictionary[value]);
            view.ChangeValueAnimation(ActionCoefficient);
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
            _activeCubes[target].GetComponent<ActiveCubeView>().Move(_fieldCoordinates[target], duration * ActionCoefficient);
        }

        public void DestroyActiveCube(int position, float timeout)
        {
            StartCoroutine(DestroyCoroutine(position, timeout * ActionCoefficient));
        }

        private IEnumerator DestroyCoroutine(int position, float timeout)
        {
            var cubeToDestroy = _activeCubes[position];
            _activeCubes[position] = null;
            yield return new WaitForSeconds(timeout);
            cubeToDestroy.GetComponent<ActiveCubeView>().DestroyAnimation(ActionCoefficient);
            Destroy(cubeToDestroy, ActionCoefficient);
        }

        public void RiseActiveCubeValue(int position, int value, float timeout)
        {
            StartCoroutine(RiseValueCoroutine(position, value, timeout * ActionCoefficient));
        }

        private IEnumerator RiseValueCoroutine(int position, int value, float timeout)
        {
            yield return new WaitForSeconds(timeout);
            var view = _activeCubes[position]?.GetComponent<ActiveCubeView>();
            if (view == null) yield break;
            view.SetCubeText($"{value}");
            view.SetPanelColor(_colorsDictionary[value]);
            view.ChangeValueAnimation(ActionCoefficient);
        }
    }
}
