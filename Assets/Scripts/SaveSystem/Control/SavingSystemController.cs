using SaveSystem.Core;
using UnityEngine;
using Zenject;

namespace SaveSystem.Control
{
    public sealed class SavingSystemController : MonoBehaviour
    {
        private SavingSystem _saveSystem;

        private void OnEnable()
        {
            Load();
        }

        private void OnDisable()
        {
            Save();
        }

        [Inject]
        private void Construct(SavingSystem manager)
        {
            _saveSystem = manager;
        }


        private void Load()
        {
            _saveSystem.LoadSceneData();
        }


        private void Save()
        {
            _saveSystem.SaveSceneData();
        }
    }
}
