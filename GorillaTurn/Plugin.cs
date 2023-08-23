using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BepInEx;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.XR;
using Utilla;
using Object = UnityEngine.Object;

namespace GorillaTurn
{
	// Token: 0x02000002 RID: 2
	[BepInPlugin("com.gorillaturn.marshmellow.gt", "Gorilla Turn", "1.0.0")]
	internal class Plugin : BaseUnityPlugin
	{

        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        private void Awake()
		{
            new Harmony("com.gorillaturn.marshmellow.gt").PatchAll(Assembly.GetExecutingAssembly());
		}


        // Token: 0x06000002 RID: 2 RVA: 0x00002068 File Offset: 0x00000268
        private void Update()
		{
            List<InputDevice> list = new List<InputDevice>();
            List<InputDevice> list2 = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, list2);
            InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, list);
            bool flag;
            list2[0].TryGetFeatureValue(CommonUsages.gripButton, out flag);
            bool flag2;
            list[0].TryGetFeatureValue(CommonUsages.gripButton, out flag2);
            if (flag2)
            {
                GorillaLocomotion.Player.Instance.Turn(4f);
            }
            if (flag)
            {
                GorillaLocomotion.Player.Instance.Turn(-4f);
            }
        }

        
		// Token: 0x06000005 RID: 5 RVA: 0x0000213C File Offset: 0x0000033C
		public static string getStringfromTwoPoints(string one, string two, string St)
		{
			int num = St.IndexOf(one) + one.Length;
			int num2 = St.LastIndexOf(two);
			return St.Substring(num, num2 - num);
		}

	}
}
