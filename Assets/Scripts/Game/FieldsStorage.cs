using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Game
{
    [UsedImplicitly]
    public sealed class FieldsStorage
    {
        private const int FieldStorageSize = 16;
        private readonly FieldEntity[] _fieldsStorage = new FieldEntity[FieldStorageSize];

        public FieldsStorage()
        {
            for (int i = 0; i < FieldStorageSize; i++)
            {
                _fieldsStorage[i] = new FieldEntity();
                _fieldsStorage[i].SetupPosition(i);
            }
        }

        public void Clear()
        {
            foreach (var entity in _fieldsStorage)
            {
                entity.Reset();
            }
        }

        public int AddNewRandomValue()
        {
            var emptyFields = new List<FieldEntity>();
            foreach (var entity in _fieldsStorage)
            {
                if (entity.Value == 0)
                {
                    emptyFields.Add(entity);
                }
            }
            Debug.Log($"Empty fields found: {emptyFields.Count}");
            if (emptyFields.Count == 0) return -1;
            var randomValue = Random.Range(0, emptyFields.Count - 1);
            emptyFields[randomValue].SetupValue();
            Debug.Log($"New Random Cube at{emptyFields[randomValue].Count}");
            return emptyFields[randomValue].Count;
        }
        
        public void MoveEntity(int position, int target)
        {
            if (target < 0 || target > 15)
            {
                throw new Exception($"ERROR! TARGET INDEX OUT OF RANGE {target}!");
            }

            _fieldsStorage[target].Value = _fieldsStorage[position].Value;
            _fieldsStorage[position].Value = 0;
        }

        public int GetMaxFieldValue()
        {
            var result = 0;
            foreach (var entity in _fieldsStorage)
            {
                if (entity.Value > result) result = entity.Value;
            }
            return result;
        }

        public int GetFieldEntityValue(int position)
        {
            return _fieldsStorage[position].Value;
        }

        public void ClearEntity(int position)
        {
            _fieldsStorage[position].Value = 0;
        }

        public int RiseEntityValue(int position)
        {
            return _fieldsStorage[position].Rise();
        }
    }
}
