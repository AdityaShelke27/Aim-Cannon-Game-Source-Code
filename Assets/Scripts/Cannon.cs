using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class Cannon : MonoBehaviour
{
    public float horizontalMov;
    public float verticalMov;
    public float speed;
    public static float sensitivity;
    public GameObject bullet;
    public GameObject spawnPoint;
    public GameObject Gameover;
    public GameObject Winner;
    public GameObject PauseGame;
    public float ForceMagnitude;
    public static int score;
    public static int Round = 0;
    public static float Timer;
    public float coolDown;
    public float coolAmount;
    public static float MinScore;
    public static bool Lost;
    public AudioClip cannonSound;
    public GameObject FireEffect;
    public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        Round++;
        cannonSound = GetComponent<AudioSource>().clip;
        MinScore = 50 * ( Round + 1 );
        Timer = 20 * ( 2 * Round - 1 );
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Lost = false;
        Gameover.SetActive(false);
        Winner.SetActive(false);
        PauseGame.SetActive(false);
        horizontalMov = -90f;
        coolDown = 0;
        score = 0;      
    }

    // Update is called once per frame
    void Update()
    {
        if(UI.Count > 1 || Lost)
        {
            return;
        }
        if (score >= MinScore)
        {
            Debug.Log("You Won");
            Winner.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return;
        }
        if (coolDown > 0f)
        {
            coolDown -= Time.deltaTime;
        }
        Pause();
        if(!isPaused)
        {
            Look();
            Shoot();
            CountDown();
        }

        sensitivity = Options.sensVal;
    }

    void Look()
    {
        float smooth = speed * Time.fixedDeltaTime;
        horizontalMov += Input.GetAxis("Mouse X") * smooth * sensitivity;
        verticalMov -= Input.GetAxis("Mouse Y") * smooth * sensitivity;
        verticalMov = Mathf.Clamp(verticalMov, -60f, 89f);
        horizontalMov = Mathf.Clamp(horizontalMov, -180f, 0f);
        transform.rotation = Quaternion.Euler(verticalMov, horizontalMov, transform.eulerAngles.z);
    }

    void Shoot()
    {
        if(Input.GetButtonDown("Fire1") && coolDown <= 0)
        {
            GameObject _bullet =  Instantiate(bullet, spawnPoint.transform.position, Quaternion.identity);
           _bullet.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * ForceMagnitude);
            AudioSource.PlayClipAtPoint(cannonSound,spawnPoint.transform.position);
            GameObject fire = Instantiate(FireEffect, spawnPoint.transform);
            coolDown = coolAmount;
            Destroy(fire, 1f);
            Destroy(_bullet, 5f);
        }
    }
    
    void CountDown()
    {
        if(Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            GameOver();
            Timer = 0f;
            Debug.Log("You Lose");
        }
    }

    void GameOver()
    {
        Lost = true;
        Gameover.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Pause()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 0f;
            PauseGame.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isPaused = true;
        }
    }
}
