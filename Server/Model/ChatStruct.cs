using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SQLite;

namespace Project_CNPM.Model
{
    abstract class ChatStruct
    {
        public enum MessageType
        {
            LoginNotificationStruct, RequestLogoutStruct, PrivateFileStruct, PrivateGroupMessageStruct, PublicFileGroupStruct,
            PublicGroupMessageStruct, RequestCreateGroupStruct, RequestLoginStruct, ResponseLoginStruct, ResposeCreateGroupStruct,
            ResposeProfileStruct, ResposeSignupStruct, ResquestProfileStruct, ResquestSearchStruct, ResquestSignupStruct, ResponseSignupStruct,
            ResposeSearchStruct, RequestChatStruct, ResponseChatStruct, RequestChatGroupStruct, RequestHistoryMessage, ResponseHistoryMesssage,
            RequestSendFileStruct, ResponseSendFileStruct, RequestRecFile, ResponseRecFile, RequestSendFileGroupStruct, ResponseSendFileGroupStruct,
            RequestRecFileGroup, ResponseRecFileGroup, RequestChangePass, ResponseChangePass
        }
    
        public MessageType messageType;
        public abstract byte[] pack();
        public abstract ChatStruct unpack(byte[] buff);
        public abstract void writeData(SQLiteConnection connectionData);
        public abstract ArrayList readData(SQLiteConnection connectionData);
    }
}
