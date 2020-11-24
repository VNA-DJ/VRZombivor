using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
    float random;
    float curTime;
    AudioSource AudioSource;
    GameObject Flash1;
    GameObject Flash2;
    // Use this for initialization
    void Start()
    {
        AudioSource = gameObject.GetComponent<AudioSource>();
        Flash1 = GameObject.Find("Fire1");
        Flash2 = GameObject.Find("Fire2");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        random = Random.Range(0, 100);
        if (random > 95 && !AudioSource.isPlaying)
        {
            AudioSource.Play();
        }
        if (AudioSource.isPlaying)
        {
            curTime += Time.deltaTime;
            if (curTime > 0.1)
            {
                Flash1.GetComponent<Light>().enabled = !Flash1.GetComponent<Light>().enabled;
                if (Flash1.GetComponent<Light>().enabled)
                {
                    Flash2.GetComponent<Light>().enabled = false;
                }
                else
                {
                    Flash2.GetComponent<Light>().enabled = true;
                }
                curTime = 0;
            }
        }
        else
        {
            Flash1.GetComponent<Light>().enabled = false;
            Flash2.GetComponent<Light>().enabled = false;
        }
    }
}