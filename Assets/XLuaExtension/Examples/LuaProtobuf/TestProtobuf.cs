using System.Collections;
using System.Collections.Generic;
using System.IO;
using tutorial;
using UnityEngine;
using UnityEngine.UI;
using XLua;
using XLua.LuaDLL;

public class TestProtobuf : MonoBehaviour {
    private LuaEnv _env = new LuaEnv();

    public Text ResultText;
	// Use this for initialization
	void Start () {
		_env.AddBuildin("pb", Lua.LoadPB);
		_env.AddBuildin("pb.io", Lua.LoadPB_IO);
		_env.AddBuildin("pb.conv", Lua.LoadPB_CONV);
		_env.AddBuildin("pb.buffer", Lua.LoadPB_BUFFER);
		_env.AddBuildin("pb.slice", Lua.LoadPB_SLICE);
	}

    void OnGUI() {

        if (GUI.Button(new Rect(0, 0, 120, 30), "save protobuf")) {
            SaveProtobuf();
        }

        if (GUI.Button(new Rect(0, 40, 120, 30), "load protobuf")) {
            LoadProtobuf();
        }
    }

    private void SaveProtobuf() {
        tutorial.Person alice = new Person();
        alice.test.Add(1);
        alice.email = "alice@qq.com";
        alice.name = "Alice";
        alice.phone.Add(new Person.PhoneNumber() {
            number = "12344566",
            type = Person.PhoneType.HOME
        });
        ProtoSerializer serializer = new ProtoSerializer();
        string outputPath = Application.persistentDataPath + "/personData.bytes";
        FileStream fs = new FileStream(outputPath, FileMode.OpenOrCreate);
        serializer.Serialize(fs, alice);
        fs.Close();
    }

    private void LoadProtobuf() {
        string luaScript = Resources.Load<TextAsset>("test_protobuf.lua").text;
        _env.DoString(luaScript);
        string result = _env.Global.Get<string>("resultPhone");
        ResultText.text = result;
    }
}
