using System.Runtime.InteropServices;
using UnityEngine;
#if UNITY_IOS
using UnityEngine.iOS;
#endif
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Taptic : MonoBehaviour {

#if UNITY_IOS
        [DllImport("__Internal")]
        private static extern void _PlayTaptic(string type);
        [DllImport("__Internal")]
        private static extern void _PlayTaptic6s(string type);
#endif

        public static bool isOn = true;

        public static void Warning() {
                if (!isOn || Application.isEditor) {
                        return;
                }
#if UNITY_IOS
                if(BelowiPhone6s()){
                        Handheld.Vibrate();
                }else if (iPhone6s()) {
                        _PlayTaptic6s("warning");
                } else {
                        _PlayTaptic("warning");
                }
#elif UNITY_ANDROID
                AndroidTaptic.Haptic(HapticTypes.Warning);
#endif
        }
        public static void Failure() {
                if (!isOn || Application.isEditor) {
                        return;
                }
#if UNITY_IOS
                if(BelowiPhone6s()){
                        Handheld.Vibrate();
                }else if (iPhone6s()) {
                        _PlayTaptic6s("failure");
                } else {
                        _PlayTaptic("failure");
                }
#elif UNITY_ANDROID
                AndroidTaptic.Haptic(HapticTypes.Failure);
#endif
        }
        public static void Success() {
                if (!isOn || Application.isEditor) {
                        return;
                }
#if UNITY_IOS
                if(BelowiPhone6s()){
                        Handheld.Vibrate();
                }else if (iPhone6s()) {
                        _PlayTaptic6s("success");
                } else {
                        _PlayTaptic("success");
                }
#elif UNITY_ANDROID
                AndroidTaptic.Haptic(HapticTypes.Success);
#endif
        }
        public static void Light() {
                if (!isOn || Application.isEditor) {
                        return;
                }
#if UNITY_IOS
                if(BelowiPhone6s()){
                        Handheld.Vibrate();
                }else if (iPhone6s()) {
                        _PlayTaptic6s("light");
                } else {
                        _PlayTaptic("light");
                }
#elif UNITY_ANDROID
                AndroidTaptic.Haptic(HapticTypes.LightImpact);
#endif
        }
        public static void Medium() {
                if (!isOn || Application.isEditor) {
                        return;
                }
#if UNITY_IOS
                if(BelowiPhone6s()){
                        Handheld.Vibrate();
                }else if (iPhone6s()) {
                        _PlayTaptic6s("medium");
                } else {
                        _PlayTaptic("medium");
                }
#elif UNITY_ANDROID
                AndroidTaptic.Haptic(HapticTypes.MediumImpact);
#endif
        }
        public static void Heavy() {
                if (!isOn || Application.isEditor) {
                        return;
                }
#if UNITY_IOS
                if(BelowiPhone6s()){
                        Handheld.Vibrate();
                }else if (iPhone6s()) {
                        _PlayTaptic6s("heavy");
                } else {
                        _PlayTaptic("heavy");
                }
#elif UNITY_ANDROID
                AndroidTaptic.Haptic(HapticTypes.HeavyImpact);
#endif
        }
        public static void Default() {
                if (!isOn || Application.isEditor) {
                        return;
                }
#if UNITY_IOS || UNITY_ANDROID
                Handheld.Vibrate();
#endif
        }
        public static void Vibrate() {
                if (!isOn || Application.isEditor) {
                        return;
                }
#if UNITY_IOS
                if(BelowiPhone6s()){
                        Handheld.Vibrate();
                }else if (iPhone6s()) {
                        _PlayTaptic6s("medium");
                } else {
                        _PlayTaptic("medium");
                }
#elif UNITY_ANDROID
                AndroidTaptic.Vibrate();
#endif
        }
        public static void Selection() {
                if (!isOn || Application.isEditor) {
                        return;
                }
#if UNITY_IOS
                if(BelowiPhone6s()){
                        Handheld.Vibrate();
                }else if (iPhone6s()) {
                        _PlayTaptic6s("selection");
                } else {
                        _PlayTaptic("selection");
                }
#elif UNITY_ANDROID
                AndroidTaptic.Haptic(HapticTypes.Selection);
#endif
        }

#if UNITY_IOS
        static bool iPhone6s() {
                return SystemInfo.deviceModel == "iPhone8,1" || SystemInfo.deviceModel == "iPhone8,2";
        }

        static bool BelowiPhone6s() {
                if (Device.generation.ToString().Contains("iPad") || Device.generation.ToString().Contains("iPod")) {
                        return true;
                }
                if (Device.generation == DeviceGeneration.iPhone || Device.generation == DeviceGeneration.iPhone3G || Device.generation == DeviceGeneration.iPhone3GS || Device.generation == DeviceGeneration.iPhone4 || Device.generation == DeviceGeneration.iPhone4S || Device.generation == DeviceGeneration.iPhone5 || Device.generation == DeviceGeneration.iPhone5S || Device.generation == DeviceGeneration.iPhone5C || Device.generation == DeviceGeneration.iPhone6 || Device.generation == DeviceGeneration.iPhone6Plus || Device.generation == DeviceGeneration.iPhoneSE1Gen) {
                        return true;
                }
                return false;
        }
#endif

        public static void VibratePeek() => Taptic.Medium();

        public static void VibratePop() => Taptic.Light();
}