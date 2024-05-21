using UnityEngine;
using Zenject;

namespace Game.Control
{
    public class ScreenControl: IFixedTickable
    {
        public void FixedTick()
        {
            if(Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
                return;
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }
}
