using UnityEngine;

namespace Game.Control
{
    public class ScreenControl : MonoBehaviour
    {
        private void OnEnable()
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            Screen.autorotateToLandscapeLeft = true;
        }
    }
}
