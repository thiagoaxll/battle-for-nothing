using System.Collections;
using UnityEngine;

public class Karoi : CharacterController
{
    [Header("Configuration")] [SerializeField]
    private float skillDuration;

    [SerializeField] private bool skillEnable;

    private SpriteRenderer playerSpriteRenderer;
    private Color playerColor;

    protected override void CustomStart()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void EspecialSkill()
    {
        base.EspecialSkill();
        if (skillEnable) return;
        ChangeColor(0.3f);
        transform.tag = "Untagged";
        StartCoroutine(DelayEspecialSkill());
    }

    private IEnumerator DelayEspecialSkill()
    {
        yield return new WaitForSeconds(skillDuration);
        transform.tag = "Player";
        ChangeColor(1);
        skillEnable = false;
        ResetCoolDown();
    }

    private void ChangeColor(float alpha)
    {
        playerColor = playerSpriteRenderer.color;
        playerColor.a = alpha;
        playerSpriteRenderer.color = playerColor;
    }
}