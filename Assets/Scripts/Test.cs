using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button btn;
    float timer;
    UnityAction OnTime;
    void Start()
    {
        btn.onClick.AddListener(Btn);
    }

    public void Btn_Click()
    {
        Debug.Log("û��Thread");
        Thread.Sleep(3000);
        Debug.Log("�ȴ���3s");
        Thread.Sleep(3000);
        Debug.Log("�ֵȴ���3s");
    }
    public async Task Btn_Click2Async()
    {
        timer = Time.time+3;
        OnTime = () => { timer += Time.deltaTime; Debug.Log(timer); if (timer >= 3) OnTime = null; };
        /*Thread t = new Thread(Btn_Click);
        t.Start();*/

        await Task.Run(Btn_Click);

        
    }
    public void Btn()
    {
        //��ͬDOTween.OnComplete
        Task.WhenAll(Btn_Click2Async()).ContinueWith(t=> {
            Thread.Sleep(3000);
            Debug.Log("�������");
            
            //��ͬDOTween.Sequence().AppendInterval(delayTime)
            //Thread.Sleep(3000);
            //��ͬ.AppendCallback(() => { callback(); });
            Task.WhenAll().ContinueWith(t => {
                Thread.Sleep(3000);
                Debug.Log("�������֮��");
            });
        });

        StartCoroutine(RotateForSeconds(3));
    }
    public IEnumerator RotateForSeconds(float duration)
    {
        var end = Time.time + duration;
        while (Time.time < end)
        {
            transform.Rotate(new Vector3(1, 1) * Time.deltaTime * 150);
            yield return null;
        }
    }
    private void Update()
    {
        
        OnTime?.Invoke();
    }
}
