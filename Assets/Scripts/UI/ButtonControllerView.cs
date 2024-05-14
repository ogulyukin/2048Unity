using UnityEngine;

namespace UI
{
    public class ButtonControllerView : MonoBehaviour
    {
        [SerializeField] private ButtonView buttonUp;
        [SerializeField] private ButtonView buttonDown;
        [SerializeField] private ButtonView buttonLeft;
        [SerializeField] private ButtonView buttonRight;

        public ButtonView ButtonUp => buttonUp;

        public ButtonView ButtonDown => buttonDown;

        public ButtonView ButtonLeft => buttonLeft;

        public ButtonView ButtonRight => buttonRight;

        public void SetActiveness(bool activeness)
        {
            gameObject.SetActive(activeness);
        }
    }
}
