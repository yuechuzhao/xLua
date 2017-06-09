local pb = require 'pb';
            
local pbfile = CS.UnityEngine.Resources.Load('proto/addressbook.pb');
pb.load(pbfile.bytes);

--本地序列化
--local person = { -- 我们定义一个addressbook里的 Person 消息
--      name = 'Alice',
--      id = 12345,
 --     phone = {
 --      { number = '1301234567' },
 --     { number = '87654321', type = 'WORK' },
 --    }
--}

        -- 序列化成二进制数据
--local data = assert(pb.encode('tutorial.Person', person))

--读取protobuf-net序列化好的信息
local pbbyteFile = CS.UnityEngine.Resources.Load('proto/personData');
local data = pbbyteFile.bytes;

-- 从二进制数据解析出实际消息
local result = pb.decode('tutorial.Person', data);
print(result.phone[1].number);