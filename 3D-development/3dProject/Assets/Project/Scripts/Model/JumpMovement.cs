using UnityEngine;

namespace Game
{
    internal sealed class JumpMovement : IJumpAir, IJumpGround
    {
        private Rigidbody _body;
        private readonly float _origGroundCheckDistance;

        public JumpMovement(Rigidbody body, float groundCheckDistance)
        {
            _body = body;
            _origGroundCheckDistance = groundCheckDistance;
        }

        public float JumpAtAir(float gravity)
        {
            var gravityForce = (Physics.gravity * gravity) - Physics.gravity;
            _body.AddForce(gravityForce);
            return _body.velocity.y < 0 ? _origGroundCheckDistance : 0.01f;
        }

        public float JumpOnGround(Vector3 direction)
        {
            _body.velocity = direction;
            return 0.1f;
        }
    }
}