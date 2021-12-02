using UnityEngine.Events;

public static class UnityEventsExtension
{
    public static void AddListenerOnce(this UnityEvent unityEvent, UnityAction action)
    {
        unityEvent.AddListener(Call);
        
        void Call()
        {
            action.Invoke();
            unityEvent.RemoveListener(Call);
        }
    }
}