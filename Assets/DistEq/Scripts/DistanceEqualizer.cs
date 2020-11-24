using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioLowPassFilter))]
[RequireComponent(typeof(AudioSource))]
public class DistanceEqualizer : MonoBehaviour {
    public bool Cutoff = true;
    public bool VolumeDecrease = true;
    public bool Debugging = true;

    public float StartCutoffFrom = 10f;
    [Range(0f, 1f)] public float WallCutoff = 0.5f;
    [Range(0.01f, 1f)] public float DistanceCutoff = 0.3f; 
    [Range(0f, 1f)] public float VolDecPerWall = 0.05f;   
    
    float distance;
    float distcut;
    float wallcut;

    AudioListener AudioListener;
    AudioSource AudioSource;
    RaycastHit[] hits;
    Ray ray;

    // Use this for initialization
    void Start () {
        AudioListener = FindObjectOfType<AudioListener>();
        AudioSource = gameObject.GetComponent<AudioSource>();
        gameObject.GetComponent<AudioLowPassFilter>().enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate () {
        distance = Vector3.Distance(transform.position, AudioListener.transform.position);
        if (distance < AudioSource.maxDistance) 
        {   
            //Raycast from AudioSource to AudioListener
            ray = new Ray(transform.position, AudioListener.transform.position - transform.position);
            hits = Physics.RaycastAll(ray, distance);

            // Volume decrease
            if (VolumeDecrease)
            {
                gameObject.GetComponent<AudioSource>().volume = 1 - VolDecPerWall * hits.Length;
            }

            //Lowpass filter cutoff frequency          
            if (Cutoff)
            {
                distcut = 22000 * Mathf.Pow(0.6f, (distance - StartCutoffFrom) * Mathf.Pow(DistanceCutoff * 10, 3) / 1000);
                wallcut = Mathf.Atan(hits.Length * (1 + 10 * WallCutoff)) * distcut * WallCutoff;
                gameObject.GetComponent<AudioLowPassFilter>().cutoffFrequency = distcut - wallcut;
            }
      
            // Degub Log 
            if (Debugging)
            {
                Debug.Log("Gameobject '" + gameObject.name + "' :: " + "Walls: " + hits.Length +
                          "; current volume: " + gameObject.GetComponent<AudioSource>().volume +
                          "; current cutoff: " + gameObject.GetComponent<AudioLowPassFilter>().cutoffFrequency);
                Debug.DrawLine(transform.position, AudioListener.transform.position, Color.green);
            }
        } 
    }
}
