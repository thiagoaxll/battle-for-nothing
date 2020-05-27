using System.Collections;
using UnityEngine;

namespace Characters
{
    public class Karoi : CharacterController
    {
        [Header("Configuration")] [SerializeField]
        private float skillDuration;

        [SerializeField] private bool skillEnable;

        private SpriteRenderer _playerSpriteRenderer;
        private Color _playerColor;

        protected override void CustomStart()
        {
            _playerSpriteRenderer = GetComponent<SpriteRenderer>();
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
            _playerColor = _playerSpriteRenderer.color;
            _playerColor.a = alpha;
            _playerSpriteRenderer.color = _playerColor;
        }
    }
}