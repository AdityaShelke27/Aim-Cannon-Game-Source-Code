using UnityEngine;

public class Credits : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            this.gameObject.SetActive(false);
        }
    }
    public void Back()
    {
        this.gameObject.SetActive(false);
    }
}
