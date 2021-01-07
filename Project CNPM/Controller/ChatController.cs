using Project_CNPM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Project_CNPM.Controller
{
    class ChatController
    {
        // Controll Struct Model
        public static ChatStruct unpack(byte[] buff)
        {
            // Check Null
            if(buff.Length == null)
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
                        result = new RequestLogout();
                        result.messageType = ChatStruct.MessageType.LoginNotificationStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.RequestLogoutStruct:
                    {
                        result = new RequestLogout();
                        result.messageType = ChatStruct.MessageType.RequestLogoutStruct;
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
                case ChatStruct.MessageType.ResposeSearchStruct:
                    {
                        result = new ResponseSearchStruct();
                        result.messageType = ChatStruct.MessageType.ResposeSearchStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.RequestChatStruct:
                    {
                        result = new RequestChatStruct();
                        result.messageType = ChatStruct.MessageType.RequestChatStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.ResponseChatStruct:
                    {
                        result = new ResponseChatStruct();
                        result.messageType = ChatStruct.MessageType.ResponseChatStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.RequestChatGroupStruct:
                    {
                        result = new RequestChatGroupStruct();
                        result.messageType = ChatStruct.MessageType.RequestChatGroupStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.RequestHistoryMessage:
                    {
                        result = new RequestHistoryMessageStruct();
                        result.messageType = ChatStruct.MessageType.RequestHistoryMessage;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.ResponseHistoryMesssage:
                    {
                        result = new ResponseHistoryMesssageStruct();
                        result.messageType = ChatStruct.MessageType.ResponseHistoryMesssage;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.RequestSendFileStruct:
                    {
                        result = new RequestSendFileStruct();
                        result.messageType = ChatStruct.MessageType.RequestSendFileStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.ResponseSendFileStruct:
                    {
                        result = new ResponseSendFileStruct();
                        result.messageType = ChatStruct.MessageType.ResponseSendFileStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.RequestRecFile:
                    {
                        result = new RequestRecFile();
                        result.messageType = ChatStruct.MessageType.RequestRecFile;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.ResponseRecFile:
                    {
                        result = new ResponseRecFile();
                        result.messageType = ChatStruct.MessageType.ResponseRecFile;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.RequestSendFileGroupStruct:
                    {
                        result = new RequestSendFileGroupStruct();
                        result.messageType = ChatStruct.MessageType.RequestSendFileGroupStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.ResponseSendFileGroupStruct:
                    {
                        result = new ResponseSendFileGroupStruct();
                        result.messageType = ChatStruct.MessageType.ResponseSendFileGroupStruct;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.RequestRecFileGroup:
                    {
                        result = new RequestRecFileGroup();
                        result.messageType = ChatStruct.MessageType.RequestRecFileGroup;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.ResponseRecFileGroup:
                    {
                        result = new ResponseRecFileGroup();
                        result.messageType = ChatStruct.MessageType.ResponseRecFileGroup;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.RequestChangePass:
                    {
                        result = new RequestChangePass();
                        result.messageType = ChatStruct.MessageType.RequestChangePass;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.ResponseChangePass:
                    {
                        result = new ResponseChangePass();
                        result.messageType = ChatStruct.MessageType.ResponseChangePass;
                        result.unpack(buff);
                        break;
                    }
                case ChatStruct.MessageType.RequestOutGroup:
                    {
                        result = new RequestOutGroup();
                        result.messageType = ChatStruct.MessageType.RequestOutGroup;
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
