using UnityEngine;

public class PotRevive : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public GameObject pot;
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Instantiate(pot);
        }
    }
}
