using UnityEngine;



public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource bgAudio;

    [SerializeField]
    private AudioClip bgMusic, mainMenuMusic, gameOverSound, playerAttackSound, playerJumpSound, playerDeathSound, 
        enemyAttackSound,enemyDeathSound, collectableSound, destroyObstacleSound;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        bgAudio = GetComponent<AudioSource>();
    }


    public void PlayBGMusic(bool gameplay)
    {
        if (gameplay)
        {
            bgAudio.clip = bgMusic;
        }
        else
        {
            bgAudio.clip = mainMenuMusic;
        }

        bgAudio.Play();

    }

    public void Play_GameOver_Sound()
    {
        AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
    }

    public void Play_PlayerAttack_Sound()
    {
        AudioSource.PlayClipAtPoint(playerAttackSound, transform.position);
    }

    public void Play_PlayerJump_Sound()
    {
        AudioSource.PlayClipAtPoint(playerJumpSound, transform.position);
    }

    public void Play_PlayerDeath_Sound()
    {
        AudioSource.PlayClipAtPoint(playerDeathSound, transform.position);
    }

    public void Play_EnemyAttack_Sound()
    {
        AudioSource.PlayClipAtPoint(enemyAttackSound, transform.position);
    }

    public void Play_EnemyDeath_Sound()
    {
        AudioSource.PlayClipAtPoint(enemyDeathSound, transform.position);
    }

    public void Play_Collectable_Sound()
    {
        AudioSource.PlayClipAtPoint(collectableSound, transform.position);
    }

    public void Play_DestroyObstacle_Sound()
    {
        AudioSource.PlayClipAtPoint(destroyObstacleSound, transform.position);
    }

}
