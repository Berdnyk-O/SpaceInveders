using System;

namespace Assets.Scripts
{
    public static class Actions
    {
        public static Action<float> OnEnemyKilled;
        public static Action<string> OnEndGame;
    }
}
