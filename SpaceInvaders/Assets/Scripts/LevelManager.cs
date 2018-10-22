using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour{

    public GameObject continueButton;
    public GameObject AlienManager;
    public GameObject Spaceship;
    public GameObject Notes;
    public int alienCount;
    public GameObject Stars;
    public AudioClip loadSound;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GetComponent<AudioSource>().Play();
        Stats.pause = true;
        GameObject.Find("Shields").GetComponent<Shields>().down();
        Stars.SetActive(false);
        restart();
    }
    private void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Aliens").Length == 0 && !Stats.pause)
        {
            loadNextLevel();
        }
    }
    public void restart()
    {
        Stats.pause = true;
        Stats.level = 1;
        StartCoroutine(nextLevel());
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Aliens");
        for (int i = 0; i < aliens.Length; i++)
        {
            Destroy(aliens[i]);
        }
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i]);
        }
        Spaceship.transform.position = new Vector3(0, -4.5f, 0);
        continueButton.SetActive(false);
        Spaceship.SetActive(true);
        Notes.GetComponent<TextMesh>().text = "";
        Stats.level = 0;
        Stats.score = 0;
        Stats.lives = 3;
        loadNextLevel();
    }
    public void loadFirstBoss()
    {
        Stats.level = 11;
        loadNextLevel();
    }
    public void loadNextLevel()
    {
        Stats.lives = 3;
        Stars.SetActive(false);
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Aliens");
        for (int i = 0; i < aliens.Length; i++)
        {
            Destroy(aliens[i]);
        }
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i]);
        }
        Stats.level++;
        GameObject.Find("Shields").GetComponent<Shields>().down();
        if (Stats.level > 11 && Stats.level < 16)
        {
            StartCoroutine(loadBoss());
        }
        else if (Stats.level <= 11)
        {
            StartCoroutine(nextLevel());
        }
        else
        {
            win();
        }
    }
    public void win()
    {
        Stats.pause = true;
        TextMesh text = Notes.GetComponent<TextMesh>();
        text.text = "You Win!\nScore: " + Stats.score;
        continueButton.SetActive(true);
        Stars.SetActive(false);
    }
    IEnumerator loadBoss()
    {
        Stats.pause = true;
        TextMesh text = Notes.GetComponent<TextMesh>();
        text.text = "Level " + Stats.level;
        yield return new WaitForSecondsRealtime(2.5f);
        text.text = "3";
        source.PlayOneShot(loadSound, .75f);
        yield return new WaitForSecondsRealtime(1);
        text.text = "2";
        source.PlayOneShot(loadSound, .75f);
        yield return new WaitForSecondsRealtime(1);
        source.PlayOneShot(loadSound, .75f);
        text.text = "1";
        yield return new WaitForSecondsRealtime(1);
        text.text = "GO!";
        source.PlayOneShot(loadSound, .75f);
        yield return new WaitForSecondsRealtime(.25f);
        text.text = "";
        AlienManager.GetComponent<AlienManager>().makeBoss();
        GameObject.Find("Shields").GetComponent<Shields>().up();
        Stars.SetActive(true);
        Stats.pause = false;
    }

    IEnumerator nextLevel()
    {
        Stats.pause = true;
        TextMesh text = Notes.GetComponent<TextMesh>();
        text.text = "Level " + Stats.level;
        yield return new WaitForSecondsRealtime(2.5f);
        text.text = "3";
        source.PlayOneShot(loadSound, .75f);
        yield return new WaitForSecondsRealtime(1);
        text.text = "2";
        source.PlayOneShot(loadSound, .75f);
        yield return new WaitForSecondsRealtime(1);
        text.text = "1";
        source.PlayOneShot(loadSound, .75f);
        yield return new WaitForSecondsRealtime(1);
        text.text = "GO!";
        source.PlayOneShot(loadSound, .75f);
        yield return new WaitForSecondsRealtime(.25f);
        text.text = "";
        AlienManager.GetComponent<AlienManager>().makeAliens();
        GameObject.Find("Shields").GetComponent<Shields>().up();
        Stars.SetActive(true);
        Stats.pause = false;
    }

    public void death()
    {
        Stars.SetActive(false);
        GameObject[] shields = GameObject.FindGameObjectsWithTag("Shield");
        for (int i = 0; i < shields.Length; i++)
        {
            shields[i].SetActive(false);
        }
        Spaceship.SetActive(false);
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Aliens");
        for (int i = 0; i < aliens.Length; i++)
        {
            Destroy(aliens[i]);
        }
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i]);
        }
        Stats.pause = true;
        TextMesh text = Notes.GetComponent<TextMesh>();
        text.text = "You died.\nScore: " + Stats.score;
        continueButton.SetActive(true);
    }
}
