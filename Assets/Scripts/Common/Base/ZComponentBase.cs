using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 脚本组件基类，增加了Schedule、Animation相关函数
public class ZComponentBase : MonoBehaviour {

    private Dictionary<int, Coroutine> scheduleCoroutines = new Dictionary<int, Coroutine>();   // Schedule ID -> Coroutine，便于取消Schedule
    private int autoScheduleId = 0;         // 自增长的Schedule ID

    public void SafeCall(System.Action action) {
        if (action != null) {
            action();
        }
    }

    private IEnumerator DoSchedule(int scheduleId, float delay, float interval, int repeat, System.Action callback) {
        if (delay <= 0) {
            yield return null;
        } else {
            yield return new WaitForSeconds(delay);
        }
        bool forover = (repeat == -1);
        while (forover || repeat-- > 0) {
            SafeCall(callback);
            if (interval <= 0) {
                yield return null;
            } else {
                yield return new WaitForSeconds(interval);
            }
        }
        scheduleCoroutines.Remove(scheduleId);
    }

    private IEnumerator DoScheduleIf(int scheduleId, System.Func<bool> predicate, System.Action callback) {
        yield return new WaitUntil(predicate);
        SafeCall(callback);
        scheduleCoroutines.Remove(scheduleId);
    }


    public int Schedule(float delay, float interval, int repeat, System.Action callback) {
        int scheduleId = ++autoScheduleId;
        StartCoroutine(DoSchedule(scheduleId, delay, interval, repeat, callback));
        return scheduleId;
    }

    public int ScheduleOnce(float delay, System.Action callback) {
        int scheduleId = ++autoScheduleId;
        StartCoroutine(DoSchedule(scheduleId, delay, 0, 1, callback));
        return scheduleId;
    }

    public int ScheduleIf(System.Func<bool> condition, System.Action callback) {
        int scheduleId = ++autoScheduleId;
        this.StartCoroutine(DoScheduleIf(++autoScheduleId, condition, callback));
        return scheduleId;
    }

    public void StopAllSchedule() {
        foreach (var coro in scheduleCoroutines.Values) {
            this.StopCoroutine(coro);
        }
        scheduleCoroutines.Clear();
    }

    public void StopSchedule(int scheduleId) {
        Coroutine coro = null;
        if (scheduleCoroutines.TryGetValue(scheduleId, out coro)) {
            this.StopCoroutine(coro);
            scheduleCoroutines.Remove(scheduleId);
        }
    }

    public float PlayAnimationOnTarget(GameObject target, string name) {
        if (target == null) {
            return 0;
        }

        Animation anim = target.GetComponent<Animation>();
        if (anim == null) {
            return 0;
        }

        AnimationClip clip = anim.GetClip(name);
        if (clip == null) {
            return 0;
        }

        anim.clip = clip;
        anim.Play(PlayMode.StopAll);
        return clip.length;
    }

    public float PlayAnimation(string name) {
        return PlayAnimationOnTarget(gameObject, name);
    }

    public void StopAnimationOnTarget(GameObject target) {
        if (target == null) {
            return;
        }

        Animation anim = target.GetComponent<Animation>();
        if (anim == null) {
            return;
        }

        anim.Stop();
    }

    public void StopAnimation() {
        StopAnimationOnTarget(gameObject);
    }
}
