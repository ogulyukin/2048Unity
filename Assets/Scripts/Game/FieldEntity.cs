using UnityEngine;

namespace Game
{
    public sealed class FieldEntity
    {
        private int _value;
        private int _count;

        public int Count => _count;

        public int Value
        {
            get => _value;
            set => _value = value;
        }

        public void Reset()
        {
            _value = 0;
        }

        public int Rise()
        {
            _value += _value;
            return _value;
        }

        public int SetupValue()
        {
            _value = Random.Range(0, 100) < 90 ? 2 : 4;
            return _value;
        }
        
        public void SetupPosition(int count)
        {
            _count = count;
        }
    }
}
