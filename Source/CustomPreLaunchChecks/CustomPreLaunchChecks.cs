using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Reflection;

namespace CustomPreLaunchChecks
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class CustomPreLaunchChecks : MonoBehaviour
    {

        public static CustomPreLaunchChecks instance;


        internal static AsmUtils.Detour preFlightCheckDetour;

        internal static List<Func<string, PreFlightTests.IPreFlightTest>> allChecks = new List<Func<string, PreFlightTests.IPreFlightTest>>();


        public void Awake()
        {
            instance = this;
            DontDestroyOnLoad(this);
        }


        public void Start()
        {

            PrepareSystem();

        }

        internal static void PrepareSystem()
        {

            MethodBase oldCheckFunction = typeof(EditorLogic).GetMethod("GetStockPreFlightCheck", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodBase newCheckFunction = typeof(CPLCFunctions).GetMethod("NewPreflightCheck", BindingFlags.Instance | BindingFlags.Public);

            preFlightCheckDetour = new AsmUtils.Detour(oldCheckFunction, newCheckFunction);
            preFlightCheckDetour.Install();
        }

    }
}
