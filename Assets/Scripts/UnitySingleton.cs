using UnityEngine;

public class UnitySingleton<T> : MonoBehaviour where T : Component{
    private static T s_instance;
    public static T Instance {
        get {
            if (s_instance == null) {
                s_instance = FindObjectOfType<T> ();
            }
            return s_instance;
        }
    }
 
    public virtual void Awake () {
        if (s_instance == null) {
            s_instance = this as T;
        } else {
            Destroy (gameObject);
        }
    }
}
