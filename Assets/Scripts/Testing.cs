using System;
using Firebase.RemoteConfig;
using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Testing : MonoBehaviour
{
    private TextMeshProUGUI text;
    
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Input());
    }

    IEnumerator Input()
    {
        FirebaseRemoteConfig remoteConfig = FirebaseRemoteConfig.DefaultInstance;
        
        Task fetchTask = remoteConfig.FetchAsync(TimeSpan.Zero);

        yield return new WaitUntil(() => fetchTask.IsCompleted);

        remoteConfig.ActivateAsync();

        text.text = FirebaseRemoteConfig.DefaultInstance.GetValue("Text").StringValue;
    }
}