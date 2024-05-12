using UnityEngine;

namespace Utils.Camera
{
    public class CameraRaycaster
    {
        public static Collider2D Raycast(Vector2 screenPosition)
        {
            var rayFromScreen = UnityEngine.Camera.main.ScreenPointToRay(screenPosition);

            var results = new RaycastHit2D[1];
            
            if (Physics2D.RaycastNonAlloc(rayFromScreen.origin, rayFromScreen.direction, results) != 0)
                return results[0].collider;
            
            return null;
        }
    }
}