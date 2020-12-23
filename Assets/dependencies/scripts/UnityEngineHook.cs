using GameMakingKit.Classes;
using GameMakingKit.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace GameMakingKit._UnitySpecific
{
    public class UnityEngineHook : MonoBehaviour, IEngineHook
    {
        public static UnityEngineHook Instance { get; private set; }
        private readonly SortedDictionary<int, List<Action<float>>> _updateEvents = new SortedDictionary<int, List<Action<float>>>();
        private readonly SortedDictionary<int, List<Action<float>>> _updateLateEvents = new SortedDictionary<int, List<Action<float>>>();
        private readonly SortedDictionary<int, List<Action<float>>> _updateEventsFixed = new SortedDictionary<int, List<Action<float>>>();

        void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = gameObject.GetComponent<UnityEngineHook>();
            }
        }

        public void Update()
        {
            foreach (var kv in _updateEvents)
            {
                for (int i = 0; i < kv.Value.Count; i++)
                {
                    try
                    {
                        var v = kv.Value[i];
                        if (v != null)
                        {
                            v.Invoke(Time.deltaTime);
                        }
                    }
                    catch(Exception e)
                    {
                        Debug.Log("Exception during update loop");
                        //ignore
                    }
                }
            }
        }

        public void LateUpdate()
        {
            foreach (var kv in _updateLateEvents)
            {
                for (int i = 0; i < kv.Value.Count; i++)
                {
                    try
                    {
                        var v = kv.Value[i];
                        if (v != null)
                        {
                            v.Invoke(Time.deltaTime);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.Log("Exception during update loop");
                        //ignore
                    }
                }
            }
        }

        public void FixedUpdate()
        {
            foreach (var kv in _updateEventsFixed)
            {
                for (int i = 0; i < kv.Value.Count; i++)
                {
                    try
                    {
                        var v = kv.Value[i];
                        if (v != null)
                        {
                            v.Invoke(Time.deltaTime);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.Log("Exception during update loop");
                        //ignore
                    }
                }
            }
        }

        public void AddUpdate(Action<float> onUpdate, int priority = 0)
        {
            if (_updateEvents.ContainsKey(priority))
            {
                _updateEvents[priority].Add(onUpdate);
            }
            else
            {
                _updateEvents.Add(priority, new List<Action<float>>() { onUpdate });
            }
        }

        public void AddLateUpdate(Action<float> onUpdate, int priority = 0)
        {
            if (_updateLateEvents.ContainsKey(priority))
            {
                _updateLateEvents[priority].Add(onUpdate);
            }
            else
            {
                _updateLateEvents.Add(priority, new List<Action<float>>() { onUpdate });
            }
        }

        public void AddUpdateFixed(Action<float> onUpdate, int priority = 0)
        {
            if(_updateEventsFixed.ContainsKey(priority))
            {
                _updateEventsFixed[priority].Add(onUpdate);
            }
            else
            {
                _updateEventsFixed.Add(priority, new List<Action<float>>() { onUpdate });
            }
        }

        public void DestroyGameobject(IGameObject objectToDestroy)
        {
            Destroy(objectToDestroy.Reference as GameObject);
        }

        public IGameObject Spawn(IGameObject objectToSpawn)
        {
            var instance = Instantiate(objectToSpawn.Reference as GameObject);
            return new UnityGameObject(instance);
        }

        public T Spawn<T>(IGameObject objectToSpawn)
        {
            return Instantiate(objectToSpawn.Reference as GameObject).GetComponent<UnityMonoBehaviourClass<T>>().ClassInstance;
        }

        public void DestroyGameobjectDelay(IGameObject objectToDestroy, float delay)
        {
            Delay(TimeSpan.FromSeconds(delay), () =>
            {
                DestroyGameobject(objectToDestroy);
            });
        }

        public System.Numerics.Vector3? Raycast(System.Numerics.Vector3 origin, System.Numerics.Vector3 target, float distance = 20)
        {
            RaycastHit hit;
            var rayStart = UnityUtill.ToUnityVector3(origin);
            var rayEnd = UnityUtill.ToUnityVector3(target);

            if(Physics.Linecast(rayStart, rayEnd, out hit))
            {
                return UnityUtill.ToNumericsVector3(hit.point);
            } 
            else
            {
                return target;
            }
        }

        public void Delay(TimeSpan deltaT, Action action)
        {
            StartCoroutine(Wait((float)deltaT.TotalSeconds, action));
        }

        IEnumerator Wait(float seconds, Action aciton)
        {
            yield return new WaitForSeconds(seconds);
            aciton.Invoke();
        }
    }
}
