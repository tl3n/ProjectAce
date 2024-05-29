using UnityEngine;
using UnityEngine.UIElements;

public class Doctor : MelleEnemy
{
    public Doctor()
    {
        enemyName = "Doctor";
        angle = 0;
    }

    /// <summary>
    /// Initialization of the doctor
    /// </summary>
    public override void Initialize()
    {
        // any unique logic to this enemy
        gameObject.name = enemyName;
        particleSystem = GetComponentInChildren<ParticleSystem>();
        particleSystem?.Stop();
        particleSystem?.Play();
    }

    // TODO: Just testing, must be deleted
    public void Move()
    {
        float startX = this.transform.parent.position.x - 2;
        float startY = this.transform.parent.position.y - 2;

        // обчислює нову позицію ворога на колі
        float x = startX + Mathf.Cos(this.angle) * 1; // радіус кола - 1
        float y = startY + Mathf.Sin(this.angle) * 1; // радіус кола - 1

        // оновлює позицію префаба ворога
        this.transform.position = new Vector2(x, y);

        // оновлює кутову позицію ворога на колі
        this.angle += Time.deltaTime; // змінюється з часом, щоб ворог рухався
    }
}