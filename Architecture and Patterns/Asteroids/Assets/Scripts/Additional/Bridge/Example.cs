using UnityEngine;

namespace Asteroids.Additional
{
    internal sealed class Example : MonoBehaviour
    {
        [SerializeField]
        private float speed;
        [SerializeField]
        private float speedAttack;
        private Enemy _enemy;
        private Timer timer;
        private bool _isAttack = false;
        private void Start()
        {
            timer = new Timer(4);
            var prefab = Instantiate(Resources.Load<GameObject>("Additional/Infantry"));
            //prefab.transform.position = new Vector3(0.0f, 5.0f, 0.0f);
            prefab.transform.position = new Vector3(-6.0f, 0.0f, 0.0f);
            //_enemy = new Enemy(new MagicalAttack(prefab.transform), new Infantry(prefab.transform, speed));
            _enemy = new Enemy(new FlatteringAttack(prefab.transform, speedAttack), new Mag(prefab.transform, speed));
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            if (timer.Tick(deltaTime))
                if(_isAttack == false)
                    _isAttack = true;
                else
                    _isAttack = false;
            if (_isAttack)
                _enemy.Attack(deltaTime);
            _enemy.Move(deltaTime);
        }
    }
}