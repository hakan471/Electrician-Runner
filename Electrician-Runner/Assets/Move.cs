using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Move : MonoBehaviour
{

    public AudioSource coinAudioSource;
    public AudioClip getAudioCli, gameOverSound;
    [SerializeField] public GameObject engel;
    [SerializeField] public GameObject SingleLine;
    [SerializeField] public GameObject FourtyFive;
    public GameObject startButton, endButton;
    public List<GameObject> grounds = new List<GameObject>();
    [SerializeField] private AnimatorOverrideController[] animatorOverrides;
    public static float speed;
    public GameObject camera;
    public GameObject destroyObj;

    int number, Four = 4;
    float vec,artisZ=30,artisZ2=30;
    Touch touch;
    public TextMeshProUGUI score;
    public TextMeshProUGUI level;
    public static int scoreInt = 0,groundLocation = 0;
    public static float yPointCamera = 0;
    public static float zPointCamera = 0;
    public static float playerY = 0;

    public static float xMin;
    public static float xMax;
    float flag = 0;
    float kontrol = 5.1f;
    bool gameover = true;
    Animator animator;
    CapsuleCollider collider;

    CoinMoveing coinMoveing;
    // Start is called before the first frame update
    //private void Awake()
    //{
    //    collider = gameObject.GetComponent<CapsuleCollider>();
    //    //while (artisZ < 150)
    //    //{
    //    //    System.Random rand = new System.Random();
    //    //    number = rand.Next(1, Four);
    //    //    //Debug.Log(number);
    //    //    switch (number)
    //    //    {
    //    //        case 1:
    //    //            Coins(artisZ);
    //    //            SingleLineObstacle(artisZ);
    //    //            artisZ += 5;
    //    //            Coins(artisZ);
    //    //            break;
    //    //        case 2:
    //    //            Coins(artisZ);
    //    //            SingleObstacle(artisZ);
    //    //            artisZ += 10;
    //    //            Coins(artisZ);
    //    //            break;
    //    //        case 3:
    //    //            Coins(artisZ);
    //    //            FourtyFiveObstacles(artisZ);
    //    //            artisZ += 10;
    //    //            Coins(artisZ);
    //    //            Four = 3;
    //    //            break;
    //    //        default:
    //    //            break;
    //    //    }
    //    //}
    //    //artisZ2 = artisZ;
    //    vec = camera.transform.position.z - transform.position.z;
    //    animator = gameObject.GetComponent<Animator>();
    //    animator.runtimeAnimatorController = animatorOverrides[2];
    //}
    void Start()
    {
        speed = 0.2f;
        xMin = -3;
        xMax = 3;
        yPointCamera = 0;
        zPointCamera = 0;
        playerY = 0;
        Magnet.magnetFlag = false;
        collider = gameObject.GetComponent<CapsuleCollider>();
        //while (artisZ < 150)
        //{
        //    System.Random rand = new System.Random();
        //    number = rand.Next(1, Four);
        //    //Debug.Log(number);
        //    switch (number)
        //    {
        //        case 1:
        //            Coins(artisZ);
        //            SingleLineObstacle(artisZ);
        //            artisZ += 5;
        //            Coins(artisZ);
        //            break;
        //        case 2:
        //            Coins(artisZ);
        //            SingleObstacle(artisZ);
        //            artisZ += 10;
        //            Coins(artisZ);
        //            break;
        //        case 3:
        //            Coins(artisZ);
        //            FourtyFiveObstacles(artisZ);
        //            artisZ += 10;
        //            Coins(artisZ);
        //            Four = 3;
        //            break;
        //        default:
        //            break;
        //    }
        //}
        //artisZ2 = artisZ;
        vec = camera.transform.position.z - transform.position.z;
        animator = gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = animatorOverrides[2];
        level.text = (SceneManager.GetActiveScene().buildIndex + 1).ToString();
        score.text = scoreInt.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameover)
        {
            CharacterControl();
            transform.position = new Vector3(transform.position.x, transform.position.y+playerY, transform.position.z + speed);
            //camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y+yPointCamera, transform.position.z + vec + zPointCamera);
            camera.transform.position = new Vector3(transform.position.x, camera.transform.position.y + yPointCamera, transform.position.z + vec + zPointCamera);
            destroyObj.transform.position = new Vector3(destroyObj.transform.position.x, destroyObj.transform.position.y, transform.position.z + vec - 20);
            #region Sonsuz oyunda oluþturma
            //if (transform.position.z > artisZ2)
            //{
            //    if (artisZ < 150)
            //    {
            //        System.Random rand = new System.Random();
            //        number = rand.Next(1, Four);
            //        //Debug.Log(number);
            //        switch (number)
            //        {
            //            case 1:
            //                Coins(artisZ);
            //                SingleLineObstacle(artisZ);
            //                artisZ += 5;
            //                Coins(artisZ);
            //                break;
            //            case 2:
            //                Coins(artisZ);
            //                SingleObstacle(artisZ);
            //                artisZ += 10;
            //                Coins(artisZ);
            //                break;
            //            case 3:
            //                Coins(artisZ);
            //                FourtyFiveObstacles(artisZ);
            //                artisZ += 10;
            //                Coins(artisZ);
            //                Four = 3;
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //    else
            //    {
            //        speed += 0.01f;
            //        artisZ2 += artisZ;
            //    }
            //}
            //else
            //{
            //    Four = 4;
            //    artisZ = 30;
            //}
            #endregion
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //or enemy oyun bitiþi
        if (other.gameObject.tag == "Coin")
        {
            coinAudioSource.PlayOneShot(getAudioCli, 0.4f);
            Vibrator.Vibrate();
            scoreInt += 100;
            score.text = scoreInt.ToString();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Engel")
        {
            coinAudioSource.PlayOneShot(gameOverSound,3);
            Vibrator.Vibrate(1000);
            animator.runtimeAnimatorController = animatorOverrides[2];
            speed = 0;
            gameover = true;
            
            score.text = scoreInt.ToString();

            if(HighScore.highscoreList.Length > 10)
            {
                if(HighScore.highscoreList[9].score < scoreInt)
                {
                    SceneManager.LoadScene("HighScoreName");
                }
                else
                {
                    scoreInt = 0;
                    endButton.SetActive(true);
                }
            }
            else 
            {
                if (HighScore.highscoreList[HighScore.highscoreList.Length - 1].score < scoreInt)
                {
                    SceneManager.LoadScene("HighScoreName");
                }
                else
                {
                    scoreInt = 0;
                    endButton.SetActive(true);
                }
            }
        }
        //if (other.gameObject.tag == "GroundNext")
        //{
        //    if (groundLocation == 3) groundLocation = 0;
        //    grounds[groundLocation].transform.position = new Vector3(grounds[groundLocation].transform.position.x, grounds[groundLocation].transform.position.y, grounds[groundLocation].transform.position.z + 150);
        //    groundLocation++;
        //}
        if (other.gameObject.tag == "Finish")
        {
            if(SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCount - 2)
            {
                animator.runtimeAnimatorController = animatorOverrides[2];
                speed = 0;

                SceneManager.LoadScene("HighScoreName");
            }
            else
            {
                animator.runtimeAnimatorController = animatorOverrides[2];
                speed = 0;

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    float time = 0.6f;
    bool flag3 = false;
    private void CharacterControl()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    collider.height = 1.45f;
        //    animator.runtimeAnimatorController = animatorOverrides[0];
        //    flag3 = true;
        //}
        if (flag3)
        {
            time -= Time.deltaTime;
        }

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                //Eðer hareket var ise miknatis kodu calissin.
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * 0.006f,
                    transform.position.y,
                    transform.position.z /*+ touch.deltaPosition.y *//** 0.02f*/);
            }
        }
        //karakter sinirlandirma
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, xMin, xMax),
            0.289f,
            Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z + 20)
        );
        if (time < 0)
        {
            collider.height = 1.78f;
            animator.runtimeAnimatorController = animatorOverrides[1];
            flag3 = false;
            time = 0.6f;
        }
    }
    public void Jump()
    {
        collider.height = 1.25f;
        animator.runtimeAnimatorController = animatorOverrides[0];
        flag3 = true;
    }
    int artis = 25;
    #region Sonsuz oyun fonksiyonlarý
    //void Coins(float zArtis)
    //{
    //    //-2f, 3.4fx, 1.66f y
    //    Instantiate(coin, new Vector3(Random.Range(-2f, 3.4f), 1.66f, transform.position.z + zArtis), Quaternion.identity);
    //}
    //void SingleLineObstacle(float zArtis)
    //{
    //    //1.82f x, 1.815543f y
    //    Instantiate(SingleLine, new Vector3(Random.Range(1.76f, 1.76f), 1.8f, transform.position.z + zArtis), Quaternion.identity);
    //}
    //void SingleObstacle(float zArtis)
    //{
    //    //-3.8f, 3.8f x, 0.4f y
    //    Instantiate(engel, new Vector3(Random.Range(-3.8f, 3.8f), 0.4f, transform.position.z + zArtis), Quaternion.identity);
    //}
    //void FourtyFiveObstacles(float zArtis)
    //{
    //    //-0.2438359 x, 0.3657692f y
    //    Instantiate(FourtyFive, new Vector3(Random.Range(-0.2438359f, -0.2438359f), 0.4f, transform.position.z + zArtis), Quaternion.identity);
    //}
    #endregion
    public void StartButton()
    {
        startButton.SetActive(false);
        gameover = false;
        animator.runtimeAnimatorController = animatorOverrides[1];

    }
    public void EndButton()
    {
        //burada herþeyi sýfýrla----------------------------------
        SceneManager.LoadScene(0);
        startButton.SetActive(true);
        endButton.SetActive(false);
    }

    public void LeaderBoard()
    {
        HighScore.activeLevel = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("HighScore");
    }
}
public static class Vibrator
{
#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#else
    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject androidJavaObject;
    public static AndroidJavaObject vibrator;
#endif
    public static void Vibrate(long milliseconds = 100)
    {
        if (IsAndroid())
        {
            vibrator.Call("vibrate", milliseconds);
        }
        else
        {
            Handheld.Vibrate();
        }
    }
    public static void Cancel()
    {
        if (IsAndroid())
            vibrator.Call("cancel");
    }

    public static bool IsAndroid()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return true;
#else
        return false;
#endif
    }
}
