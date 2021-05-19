using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBehaviour : MonoBehaviour
{
    private Animator robotAnimator;
    private int scoreAmount = 5;
    private int lastScore = 0;
    private int maxScore;
    private float hitsToWin;

    // Start is called before the first frame update
    void Start()
    {
        robotAnimator = this.GetComponent<Animator>();
        maxScore = GameManager.gm.beatLevelScore;
        hitsToWin = (float)(maxScore / scoreAmount);
        StartCoroutine(RobotStartAnimationControl());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.gm.score > lastScore)
        {
            lastScore = GameManager.gm.score;
        }
        
    }

    IEnumerator RobotStartAnimationControl()
    {
        int newScore = lastScore;
        float animLength = robotAnimator.runtimeAnimatorController.animationClips[0].length;
        float timeToWait = Mathf.Round( animLength / hitsToWin * 100f ) / 100f;
        float timePassed = 0.0f;

        while (animLength > timePassed + 0.3f)
        {
            if (newScore != lastScore)
            {
                robotAnimator.speed = 1f;
                newScore = lastScore;
                yield return new WaitForSeconds(timeToWait);
                robotAnimator.speed = 0.0f;
                timePassed += timeToWait;
            }
            yield return new WaitForEndOfFrame();
        }

        robotAnimator.speed = 1f;
        robotAnimator.SetTrigger("Dance");
    }
}
