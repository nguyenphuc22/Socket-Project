﻿using Project_CNPM.Model;
using Server.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace Server.Model
{
    class RequestSendFileGroupStruct : ChatStruct
    {
        string sendUserName;
        string recGroupName;
        string filePath;
        string fileName;
        byte[] fileSize;

        public string getrecGroupName()
        {
            return this.recGroupName;
        }
        public string getSend()
        {
            return this.sendUserName;
        }
        public string getfile()
        {
            return this.filePath;
        }
        public RequestSendFileGroupStruct()
        {
            this.fileName = "";
            this.filePath = "";
            this.sendUserName = "";
            this.recGroupName = "";
            this.fileSize = new byte[0];
        }
        public RequestSendFileGroupStruct(string sendusername, string recusername, string filepath, byte[] filesize)
        {
            this.sendUserName = sendusername;
            this.filePath = filepath;
            this.recGroupName = recusername;
            this.fileSize = filesize;
        }
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.RequestSendFileGroupStruct)));
            if (sendUserName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(sendUserName)));
                data.AddRange(Encoding.UTF8.GetBytes(sendUserName));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            if (recGroupName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(recGroupName)));
                data.AddRange(Encoding.UTF8.GetBytes(recGroupName));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            if (filePath != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(filePath)));
                data.AddRange(Encoding.UTF8.GetBytes(filePath));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));


            this.fileSize = File.ReadAllBytes(filePath);

            if (fileSize != null)
            {

                data.AddRange(BitConverter.GetBytes((fileSize.GetLength(0))));
                data.AddRange(fileSize);

            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            return data.ToArray();
        }


        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4; //Skip messageType
            int sendUserNameLength, recUserNameLength, filepathLength, fileSizeLength;

            sendUserNameLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset
            if (sendUserNameLength > 0)
                sendUserName = Encoding.UTF8.GetString(buff, offset, sendUserNameLength);

            offset += sendUserNameLength; //Update offset

            recUserNameLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update offset
            if (recUserNameLength > 0)
                recGroupName = Encoding.UTF8.GetString(buff, offset, recUserNameLength);

            offset += recUserNameLength;

            filepathLength = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (filepathLength > 0)
                this.filePath = Encoding.UTF8.GetString(buff, offset, filepathLength);

            //get file name
            string[] splitedPath = this.filePath.Split(@"\");
            this.fileName = splitedPath[splitedPath.Length - 1];
            offset += filepathLength;

            fileSizeLength = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (fileSizeLength > 0)
            {
                this.fileSize = new byte[fileSizeLength];
                Array.Copy(buff, offset, fileSize, 0, fileSizeLength);
            }
            return this;
        }

        public override void writeData(SQLiteConnection connectionData)
        {
            string ogpath = ServerController.getObject().path;
            ArrayList arrUser = this.readData(connectionData);
            DateTime time = DateTime.Now;
            string idBoxPath = String.Format(@"{0}{1}", ogpath, this.recGroupName.ToString()); /// '....\data\idbox
            string storePath = idBoxPath + @"\" + time.ToString("yyyy'-'MM'-'dd' 'HH'.'mm'.'ss' 'tt");  /////....\data\idbox\time
            string filepath = storePath + @"\" + fileName;//// ....\data\idbox\time\filename
            
            if (Directory.Exists(idBoxPath))
            {
                Directory.CreateDirectory(storePath);
                File.WriteAllBytes(filepath, this.fileSize);
            }
            else
            {
                Directory.CreateDirectory(idBoxPath);
                Directory.CreateDirectory(storePath);
                File.WriteAllBytes(filepath, this.fileSize);
            }
            string query = String.Format("INSERT INTO GroupMessage (nameGroup, sender, time,message) values ('{0}','{1}', '{2}', '{3}')",
                this.recGroupName, this.sendUserName, time.ToString("yyyy'-'MM'-'dd' 'HH'.'mm'.'ss' 'tt"), this.filePath);
            SQLiteCommand cmd = new SQLiteCommand(query, connectionData);
            cmd.ExecuteNonQuery();
        }

        public override ArrayList readData(SQLiteConnection connectionData)
        {
            string query = String.Format("SELECT UserName FROM GroupChat WHERE nameGroup = '{0}'",this.recGroupName);

            ArrayList array = new ArrayList();
            SQLiteCommand cmd = new SQLiteCommand(query, connectionData);
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);

            adapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                array.Add(row["UserName"]);
            }

            return array;
        }
    }
}
