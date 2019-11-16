using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpHandler : MonoBehaviour
{
    public Transform[] powerUpPositions;
    public GameObject[] powerUps;

    private CharacterController characterController;
    private int maxPowerUps;
    private int pickedPowerUps;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        maxPowerUps = powerUps.Length;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("PowerUp"))
        {
            if (pickedPowerUps < maxPowerUps)
            {
                CheckForPowerUps(other.gameObject);
                PickUpPowerUp(other.gameObject);
                pickedPowerUps++;
            }
        }
    }

    private void CheckForPowerUps(GameObject other)
    {
        var pickedPowerUp = other.transform.GetComponent<PowerUp>();
        switch (pickedPowerUp.type)
        {
            case PowerUp.PowerUpType.ImmuneScenario:
                characterController.SetMultiplyScenarioDamage(pickedPowerUp.scenario);
                break;
            case PowerUp.PowerUpType.MinusDamage:
                characterController.SetMultiplyTakeDamage(pickedPowerUp.takeDamage);
                break;
            case PowerUp.PowerUpType.PlusDamage:
                characterController.SetMultiplyShootDamage(pickedPowerUp.shootDamage);
                break;
            case PowerUp.PowerUpType.PlusJump:
                characterController.SetMultiplyJumpForce(pickedPowerUp.jump);
                break;
            case PowerUp.PowerUpType.PlusSpeed:
                characterController.SetMultiplyMoveSpeed(pickedPowerUp.speed);
                break;
            case PowerUp.PowerUpType.NoKnockBack:
                characterController.SetMultiplyKnockBack(pickedPowerUp.knockBack);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void PickUpPowerUp(GameObject other)
    {
        var tempRigidBody2D = other.GetComponent<Rigidbody2D>();
        other.GetComponent<CircleCollider2D>().enabled = false;
        tempRigidBody2D.isKinematic = true;
        tempRigidBody2D.velocity = Vector2.zero;
        tempRigidBody2D.angularVelocity = 0;
        other.transform.rotation = Quaternion.identity;
        other.transform.localScale = new Vector2(0.5f, 0.5f);
        powerUps[pickedPowerUps] = other;
        powerUps[pickedPowerUps].transform.position = powerUpPositions[pickedPowerUps].position;
        powerUps[pickedPowerUps].transform.SetParent(characterController.playerCanvas.transform);
    }

    public void DropPowerUp()
    {
        if (pickedPowerUps > 0)
        {
            for (int i = 0; i < pickedPowerUps; i++)
            {
                var tempRigidBody2D = powerUps[i].GetComponent<Rigidbody2D>();
                powerUps[i].transform.SetParent(null);
                tempRigidBody2D.isKinematic = false;
                powerUps[i].GetComponent<CircleCollider2D>().enabled = true;
                Vector3 localScale = new Vector2(1, 1);
                powerUps[i].transform.localScale = localScale;
                tempRigidBody2D.AddForce(new Vector2(Random.Range(-600f, 600f), Random.Range(-600f, 600f)));
            }
        }
    }
}