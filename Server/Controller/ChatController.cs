using Project_CNPM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Server.Controller
{
    class ChatController
    {
        // Controll Struct Model
        static ChatStruct unpack(byte[] buff)
        {
            // Check Null
            if (buff.Length == null)
            {
                return null;
            }

            ChatStruct result = null;
            //Read first 4 byte for messageType
            ChatStruct.MessageType messageType = (ChatStruct.MessageType)BitConverter.ToInt32(buff, 0);
            switch (messageType)
            {
                case ChatStruct.MessageType.LoginNotificationStruct:
                    {
                        result = new LogoutNotificationStruct();
                        result.messageType = ChatStruct.MessageType.LoginNotificationStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.LogoutNotificationStruct:
                    {
                        result = new LogoutNotificationStruct();
                        result.messageType = ChatStruct.MessageType.LogoutNotificationStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.PrivateFileStruct:
                    {
                        result = new PrivateFileStruct();
                        result.messageType = ChatStruct.MessageType.PrivateFileStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.PrivateGroupMessageStruct:
                    {
                        result = new PrivateGroupMessageStruct();
                        result.messageType = ChatStruct.MessageType.PrivateGroupMessageStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.PublicFileGroupStruct:
                    {
                        result = new PublicFileGroupStruct();
                        result.messageType = ChatStruct.MessageType.PublicFileGroupStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.PublicGroupMessageStruct:
                    {
                        result = new PublicGroupMessageStruct();
                        result.messageType = ChatStruct.MessageType.PublicGroupMessageStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.RequestCreateGroupStruct:
                    {
                        result = new RequestCreateGroupStruct();
                        result.messageType = ChatStruct.MessageType.RequestCreateGroupStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.RequestLoginStruct:
                    {
                        result = new RequestLoginStruct();
                        result.messageType = ChatStruct.MessageType.RequestLoginStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.ResponseLoginStruct:
                    {
                        result = new ResponseLoginStruct();
                        result.messageType = ChatStruct.MessageType.ResponseLoginStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.ResposeCreateGroupStruct:
                    {
                        result = new ResposeCreateGroupStruct();
                        result.messageType = ChatStruct.MessageType.ResposeCreateGroupStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.ResposeProfileStruct:
                    {
                        result = new ResposeProfileStruct();
                        result.messageType = ChatStruct.MessageType.ResposeProfileStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.ResposeSignupStruct:
                    {
                        result = new ResposeSignupStruct();
                        result.messageType = ChatStruct.MessageType.ResposeSignupStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.ResquestProfileStruct:
                    {
                        result = new ResquestProfileStruct();
                        result.messageType = ChatStruct.MessageType.ResquestProfileStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.ResquestSearchStruct:
                    {
                        result = new ResquestSearchStruct();
                        result.messageType = ChatStruct.MessageType.ResquestSearchStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.ResquestSignupStruct:
                    {
                        result = new ResquestSignupStruct();
                        result.messageType = ChatStruct.MessageType.ResquestSignupStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.ResponseSignupStruct:
                    {
                        result = new ResponseSignupStruct();
                        result.messageType = ChatStruct.MessageType.ResponseSignupStruct;
                        result.unpack(buff);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return result;
        }
    }
}
