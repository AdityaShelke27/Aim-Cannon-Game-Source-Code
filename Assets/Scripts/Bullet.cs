using UnityEngine;
using UnityEngine.Audio;

public class Bullet : MonoBehaviour
{
    
    public GameObject target;
    public bool IsCollided = false;
    public AudioClip strike;

    private void Start()
    {
        strike = target.GetComponent<AudioSource>().clip;
    }
    private void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);

        if(!IsCollided && collision.collider.tag == "Target")
        {
            Destroy(collision.gameObject);
            Cannon.score += 10;
            AudioSource.PlayClipAtPoint(strike, collision.collider.transform.position);
            IsCollided = true;
            return;
        }
        else
        {
            //if(collision.collider.tag != "Player")
            //{
                IsCollided = true;
            //}
            
        }
        
        
    }
}
