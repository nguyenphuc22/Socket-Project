using Server.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;
//I'LL DO THIS TASK LATER ^^!
namespace Project_CNPM.Model
{
    class RequestSendFileStruct : ChatStruct
    {
        string sendUserName;
        string recUserName;
        string filePath;
        string fileName;
        byte[] fileSize;
        
        public string getrecUserName()
        {
            return this.recUserName;
        }
        public string getsendUserName()
        {
            return this.sendUserName;
        }
        public string getPath()
        {
            return this.filePath;
        }
        public RequestSendFileStruct()
        {
            this.fileName = "";
            this.filePath = "";
            this.sendUserName = "";
            this.recUserName = "";
            this.fileSize =new byte[0];
        }
        public RequestSendFileStruct(string sendusername, string recusername,string filepath,string filename,byte[] filesize)
        {
            this.sendUserName = sendusername;
            this.filePath = filepath;
            this.recUserName=recusername;
            this.fileName = filename;
            this.fileSize = filesize;
        }
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.RequestSendFileStruct)));
            if (sendUserName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(sendUserName)));
                data.AddRange(Encoding.UTF8.GetBytes(sendUserName));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            if (recUserName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(recUserName)));
                data.AddRange(Encoding.UTF8.GetBytes(recUserName));
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


            this.fileSize = File.ReadAllBytes( filePath);

            if (fileSize != null)
            {

                data.AddRange(BitConverter.GetBytes((fileSize.GetLength(0))));
                data.AddRange(fileSize);
                
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            return data.ToArray();
        }

        public override ArrayList readData(SQLiteConnection connectionData)
        {
            string query = String.Format("SELECT * FROM PrivateBox Where (userName1 = '{0}' or userName1='{1}') and (userName2 ='{1}' or userName2='{0}') ",
                            this.sendUserName, this.recUserName);
            ArrayList array = new ArrayList();
            SQLiteCommand cmd = new SQLiteCommand(query, connectionData);
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);

            adapter.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                string writeQuery = String.Format("INSERT INTO PrivateBox (userName1, userName2) values ('{0}','{1}')", this.sendUserName, this.recUserName);
                cmd = new SQLiteCommand(writeQuery, connectionData);
                cmd.ExecuteNonQuery();

                query = String.Format("SELECT * FROM PrivateBox Where (userName1 = '{0}' or userName2='{1}) and (userName2 ='{1}' or userName2='{0}) ",
                this.sendUserName, this.recUserName);
                array = new ArrayList();
                cmd = new SQLiteCommand(query, connectionData);
                dt = new DataTable();
                adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(dt);
            }

            foreach (DataRow row in dt.Rows)
            {
                array.Add(row["idBox"]);
            }

            return array;
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
                recUserName = Encoding.UTF8.GetString(buff, offset, recUserNameLength);

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
        // Remember to change the path( where you store the data0


        public override void writeData(SQLiteConnection connectionData)
        {
            string ogpath=ServerController.getObject().path;
            ArrayList idbox = this.readData(connectionData);
            DateTime time = DateTime.Now;
            string idBoxPath = String.Format(@"{0}{1}", ogpath, idbox[0].ToString()); /// '....\data\idbox
            string storePath =  idBoxPath + @"\" + time.ToString("yyyy'-'MM'-'dd' 'HH'.'mm'.'ss' 'tt");  /////....\data\idbox\time
            string filepath = storePath + @"\" + fileName;//// ....\data\idbox\time\filename
            if (Directory.Exists(idBoxPath))
            {
                Directory.CreateDirectory(storePath);
                File.WriteAllBytes(filepath, this.fileSize);
            }
            else {
                Directory.CreateDirectory(idBoxPath);
                Directory.CreateDirectory(storePath);
                File.WriteAllBytes(filepath, this.fileSize);
            }

        }
    }
}
