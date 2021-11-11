using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager SharedInstance;

    private List<Enemy> enemigos;

    public int EnemyCount
    {
        get => enemigos.Count;
    }

    public UnityEvent onEnemyChanged;

    private void Awake() {
        if (SharedInstance == null)
        {
            SharedInstance = this;
            enemigos = new List<Enemy>();
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddEnemy(Enemy enemigo)
    {
        enemigos.Add(enemigo);
        onEnemyChanged.Invoke();
    }

    public void RemoveEnemy(Enemy enemigo)
    {
        enemigos.Remove(enemigo);
        onEnemyChanged.Invoke();
    }
}
