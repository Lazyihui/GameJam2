using UnityEngine;

namespace GJ {

    public static class EasingFunctions {

        // Linear
        public static float Linear(float t) {
            return t;
        }

        // Quad
        public static float EaseInQuad(float t) {
            return t * t;
        }

        public static float EaseOutQuad(float t) {
            return t * (2 - t);
        }

        public static float EaseInOutQuad(float t) {
            return t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t;
        }

        // Cubic
        public static float EaseInCubic(float t) {
            return t * t * t;
        }

        public static float EaseOutCubic(float t) {
            return 1f - Mathf.Pow(1f - t, 3f);
        }

        public static float EaseInOutCubic(float t) {
            return t < 0.5f ? 4 * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 3) / 2;
        }

        // Quart
        public static float EaseInQuart(float t) {
            return t * t * t * t;
        }

        public static float EaseOutQuart(float t) {
            return 1 - Mathf.Pow(1 - t, 4);
        }

        public static float EaseInOutQuart(float t) {
            return t < 0.5f ? 8 * t * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 4) / 2;
        }

        // Quint
        public static float EaseInQuint(float t) {
            return t * t * t * t * t;
        }

        public static float EaseOutQuint(float t) {
            return 1 - Mathf.Pow(1 - t, 5);
        }

        public static float EaseInOutQuint(float t) {
            return t < 0.5f ? 16 * t * t * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 5) / 2;
        }

        // Sine
        public static float EaseInSine(float t) {
            return 1 - Mathf.Cos((t * Mathf.PI) / 2);
        }

        public static float EaseOutSine(float t) {
            return Mathf.Sin((t * Mathf.PI) / 2);
        }

        public static float EaseInOutSine(float t) {
            return -(Mathf.Cos(Mathf.PI * t) - 1) / 2;
        }

        // Expo
        public static float EaseInExpo(float t) {
            return t == 0 ? 0 : Mathf.Pow(2, 10 * t - 10);
        }

        public static float EaseOutExpo(float t) {
            return t == 1 ? 1 : 1 - Mathf.Pow(2, -10 * t);
        }

        public static float EaseInOutExpo(float t) {
            return t == 0 ? 0 : t == 1 ? 1 : t < 0.5 ? Mathf.Pow(2, 20 * t - 10) / 2 : (2 - Mathf.Pow(2, -20 * t + 10)) / 2;
        }

        // Circ
        public static float EaseInCirc(float t) {
            return 1 - Mathf.Sqrt(1 - Mathf.Pow(t, 2));
        }

        public static float EaseOutCirc(float t) {
            return Mathf.Sqrt(1 - Mathf.Pow(t - 1, 2));
        }

        public static float EaseInOutCirc(float t) {
            return t < 0.5 ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * t, 2))) / 2 : (Mathf.Sqrt(1 - Mathf.Pow(-2 * t + 2, 2)) + 1) / 2;
        }

        // Back
        public static float EaseInBack(float t) {
            float c1 = 1.70158f;
            float c3 = c1 + 1;
            return c3 * t * t * t - c1 * t * t;
        }

        public static float EaseOutBack(float t) {
            float c1 = 1.70158f;
            float c3 = c1 + 1;
            return 1 + c3 * Mathf.Pow(t - 1, 3) + c1 * Mathf.Pow(t - 1, 2);
        }

        public static float EaseInOutBack(float t) {
            float c1 = 1.70158f;
            float c2 = c1 * 1.525f;
            return t < 0.5
                ? (Mathf.Pow(2 * t, 2) * ((c2 + 1) * 2 * t - c2)) / 2
                : (Mathf.Pow(2 * t - 2, 2) * ((c2 + 1) * (t * 2 - 2) + c2) + 2) / 2;
        }

        // Elastic
        public static float EaseInElastic(float t) {
            float c4 = (2 * Mathf.PI) / 3;
            return t == 0 ? 0 : t == 1 ? 1 : -Mathf.Pow(2, 10 * t - 10) * Mathf.Sin((t * 10 - 10.75f) * c4);
        }

        public static float EaseOutElastic(float t) {
            float c4 = (2 * Mathf.PI) / 3;
            return t == 0 ? 0 : t == 1 ? 1 : Mathf.Pow(2, -10 * t) * Mathf.Sin((t * 10 - 0.75f) * c4) + 1;
        }

        public static float EaseInOutElastic(float t) {
            float c5 = (2 * Mathf.PI) / 4.5f;
            return t == 0 ? 0 : t == 1 ? 1 : t < 0.5
                ? -(Mathf.Pow(2, 20 * t - 10) * Mathf.Sin((20 * t - 11.125f) * c5)) / 2
                : (Mathf.Pow(2, -20 * t + 10) * Mathf.Sin((20 * t - 11.125f) * c5)) / 2 + 1;
        }

        // Bounce
        public static float EaseInBounce(float t) {
            return 1 - EaseOutBounce(1 - t);
        }

        public static float EaseOutBounce(float t) {
            float n1 = 7.5625f;
            float d1 = 2.75f;

            if (t < 1 / d1) {
                return n1 * t * t;
            } else if (t < 2 / d1) {
                return n1 * (t -= 1.5f / d1) * t + 0.75f;
            } else if (t < 2.5 / d1) {
                return n1 * (t -= 2.25f / d1) * t + 0.9375f;
            } else {
                return n1 * (t -= 2.625f / d1) * t + 0.984375f;
            }
        }

        public static float EaseInOutBounce(float t) {
            return t < 0.5
                ? (1 - EaseOutBounce(1 - 2 * t)) / 2
                : (1 + EaseOutBounce(2 * t - 1)) / 2;
        }
    }
}