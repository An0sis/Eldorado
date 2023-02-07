using UnityEngine;

public class textPopUp : MonoBehaviour
{
    public void DestroyParent()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        Destroy(parent);
    }
}
