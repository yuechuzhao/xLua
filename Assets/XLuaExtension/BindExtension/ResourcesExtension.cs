using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace Client.Library {
    [LuaCallCSharp]
    public static class Resources {
        public static TextAsset LoadTextAsset(string path) {
            return UnityEngine.Resources.Load<TextAsset>(path);
        }     
    }
}