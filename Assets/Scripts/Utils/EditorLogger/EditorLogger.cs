using UnityEngine;

namespace Utils.EditorLogger
{
    public class EditorLogger
    {
        public static void Log(string message)
        {
#if UNITY_EDITOR
            Debug.Log(message);
#endif
        }
    }
}